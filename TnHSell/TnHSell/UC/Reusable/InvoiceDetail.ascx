<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvoiceDetail.ascx.cs" Inherits="TnHSell.UC.InvoiceDetail" %>
<script type="text/javascript">
    var invoiceDetail = (function () {
        var detailSetting, rdlVAT, storeId, ioCodeId, curUnit;
        var arrProduct = [], arrUnit = [];
        var sessionKey = $('#hdfSessionKey').val();
        var init = function init(setting) {
            detailSetting = setting;
            $('#ddlProduct').svcCombobox({
                service: 'CatProduct/GetComboboxData?sessionKey=' + sessionKey,
                change: productChanged,
            });
            $('#vat').find("input[value='10']").prop("checked", true);
            var numberTextboxs = [$('#txtQuantity'), $('#txtPrice')];
            var notEmptyControls = [$('#txtQuantity'), $('#txtPrice')];
            var formArea = $.extend({ 'price': 'block', 'vat': 'block', 'inventory': 'none' }, setting.formArea);
            if (formArea.price === 'none') {
                notEmptyControls.splice(1, 2)
            }
            if (formArea.vat === 'none' && notEmptyControls.length > 2) {
                notEmptyControls.splice(2, 1)
            }
            numberOnlyArr(numberTextboxs); 22
            $('#price').css('display', formArea.price);
            $('#vat').css('display', formArea.vat);
            $('#divInventory').css('display', formArea.inventory);
            $('#btnProductAdd').css('display', formArea.btnAdd);
            callService('CatUnit/GetComboboxData?sessionKey=' + sessionKey, function (data) {
                data = JSON.parse(data);
                $.each(data, function (idx, val) { arrUnit.push({ 'id': val.ID, 'name': val.Name }) });
            });
            showProductGrid([]);
            $('#txtQuantity').change(function () {
                if (detailSetting.formArea.inventory == 'block') {
                    var quantity = getNumber($('#txtQuantity').val());
                    var inventory = getNumber($('#txtInventory').val());
                    if (quantity > inventory) {
                        msgBox.alert('Số lượng xuất không được lớn hơn số lượng tồn kho');
                        $('#txtQuantity').focus();
                    }
                }
            })
            $('#btnProductAdd').click(function () {
                if (notEmpty(notEmptyControls) && validForm()) {
                    data = getDetailInfo();
                    if (!checkExistAdd(data))
                        arrProduct.push(data);
                    updateGrid();
                }
                if (detailSetting.changed)
                    detailSetting.changed();
            });
            $('#btnProductSub').click(function () {
                data = getDetailInfo();
                checkExistSub(data);
                updateGrid();
                if (detailSetting.changed)
                    detailSetting.changed();
            });

            rdlVAT = $('#testRadioList').radioList({
                name: 'VAT',
                items: [{ value: '0', text: '0%' }, { value: '5', text: '5%', checked: true }, { value: '10', text: '10%' }, { value: '20', text: '20%' }],
                defaultValue: '10'
            });
        }

        function productChanged() {
            clearFormInfo();
            showPrice();
            if (detailSetting.formArea.inventory == 'block') {
                showInventory();
            }
            var productId = $('#ddlProduct').data("kendoComboBox").value();
            setProductUnit(productId);
        }
        /// Lấy tên Đơn vị tính của sản phẩm.
        function setProductUnit(productId) {
            callService('CatProduct/GetByID?id=' + productId, function (data) {
                data = JSON.parse(data)[0];
                $.each(arrUnit, function (idx, val) {
                    if (val.id == data.UnitID) {
                        curUnit = val.name;
                        return false;
                    }
                });
            });
        }
        /// Cập nhật grid chi tiết khi thêm hoặc xóa sản phẩm.
        function updateGrid(data) {
            var gridProduct;
            if (data)
                gridProduct = showProductGrid(data);
            else
                gridProduct = showProductGrid(arrProduct);
            arrProduct = gridProduct.data().kendoGrid.dataSource.view();
        }

        /// Bind dữ liệu từ service vào grid
        function bindGrid(service, callbacks, allowChange) {
            if (callbacks && Array.isArray(callbacks))
                callbacks.unshift(updateGrid);
            else
                callbacks = [updateGrid];
            callServiceMultiCallback(service, callbacks);
            if (!allowChange)
                readOnly();
        }
        function readOnly() {
            $('#controls').hide();
        }
        function clearForm() {
            clearFormInfo();
            showProductGrid([]);
            arrProduct = [];
            $('#txtInventory').val('');
            $('#ddlProduct').data("kendoComboBox").value('');
        }
        function showProductGrid(data) {
            var totalExpr = data.length > 0 ? 'numeral(Quantity * Price).format("0,0")' : '0';
            data = typeof data == 'string' ? JSON.parse(data) : data;


            var grid = $('#gridInvoiceDetail').kendoGrid({
                dataSource: {
                    type: 'odata',
                    data: data,
                    schema: {
                        model: {
                            id: 'ProductID',
                            fields: {
                                ProductID: { editable: false, },
                                Product_Name: { editable: false, },
                                Unit_Name: { editable: false, },
                                Quantity: { editable: false, },
                                Price: { editable: detailSetting.priceEditable, type: 'number' },
                                VAT: { editable: false, },
                                Total: { editable: false, },
                            },
                        }
                    },
                    change: function (e) {
                        if (e.action === "itemchange") {
                            var model = e.items[0];
                            var currentValue = model.Quantity * model.Price;
                            if (currentValue !== model.Total) {
                                model.Total = currentValue;
                                $("#gridInvoiceDetail").find("tr[data-uid='" + model.uid + "'] td:eq(5)").text(numberFormat(currentValue));
                                if (detailSetting.changed)
                                    detailSetting.changed();
                            }
                        }
                    },
                },
                editable: true,
                columns: [
                { field: 'ProductID', hidden: true },
                { field: 'Product_Name', title: 'Sản phẩm', hidden: detailSetting.gridColumnDisplay.product },
                { field: 'Unit_Name', title: 'ĐVT', width: 50 },
                { field: 'Quantity', title: 'Số lượng', hidden: detailSetting.gridColumnDisplay.Quantity },
                { field: 'Price', title: 'Đơn giá', template: '#: numeral(Price).format("0,0") #', hidden: detailSetting.gridColumnDisplay.price },
                { field: 'VAT', title: 'VAT', hidden: detailSetting.gridColumnDisplay.vat },
                { field: 'Total', title: 'Thành tiền', template: '#:' + totalExpr + '#', hidden: detailSetting.gridColumnDisplay.total },
                ],
                selectable: 'row',
                change: gridRowSelected,
                pageable: {
                    buttonCount: 5
                },
            });
            arrProduct = grid.data().kendoGrid.dataSource.view();
            return grid;
        }
        function gridRowSelected(arg) {
            var grid = arg.sender;
            var currentDataItem = grid.dataItem(this.select());
            fillFormInfo(currentDataItem);
        }
        function productSelectedChanged() {
            clearFormInfo();
        }
        function fillFormInfo(data) {
            if (data) {
                $('#ddlProduct').data('kendoComboBox').value(data.ProductID);
                $('#txtQuantity').val(data.Quantity);
                $('#txtPrice').val(numberFormat(data.Price));
                rdlVAT.setValue(data.VAT);
            }
        }
        function clearFormInfo() {
            $('#controls').show();
            //$('#ddlProduct').value('');
            $('#txtQuantity').val('');
            $('#txtPrice').val('');
            rdlVAT.setValue('10');
        }
        function getDetailInfo() {
            var cbbProduct = $('#ddlProduct').data("kendoComboBox");
            return {
                ProductID: cbbProduct.value(),
                Product_Name: cbbProduct.text(),
                Unit_Name: curUnit,
                Quantity: $("#txtQuantity").val(),
                Price: getNumber($('#txtPrice').val()),
                VAT: rdlVAT.getValue(),
            }
        }
        function checkExistAdd(product) {
            for (var i = 0; i < arrProduct.length ; i++)
                if (product.ProductID == arrProduct[i].ProductID) {
                    arrProduct[i].Quantity = parseFloat(arrProduct[i].Quantity) + parseFloat(product.Quantity);
                    arrProduct[i].Price = product.Price;
                    return true;
                }
            return false;
        }
        function checkExistSub(product) {
            for (var i = 0; i < arrProduct.length ; i++)
                if (product.ProductID == arrProduct[i].ProductID) {
                    if (parseFloat(arrProduct[i].Quantity) > parseFloat(product.Quantity)) {
                        arrProduct[i].Quantity = parseFloat(arrProduct[i].Quantity) - parseFloat(product.Quantity);
                        arrProduct[i].Price = product.Price;
                    }
                    else {
                        arrProduct.splice(i, 1);
                    }
                    return true;
                }
            return false;
        }
        function getDetail() {
            return arrProduct;
        }

        function setStore(Id) {
            storeId = Id;
            showInventory();
        }
        function showInventory() {
            var productId = $('#ddlProduct').data("kendoComboBox").value();
            if (storeId && storeId > 0) {
                if (productId && productId > 0) {
                    callService('SelInvoiceOvr/GetInventory?storeId=' + storeId + '&productId=' + productId, function (data) { $('#txtInventory').val(data) });
                }
                else
                    $('#txtInventory').val('');

            }
            else {
                $('#txtInventory').val('');
                msgBox.alert('Vui lòng chọn kho xuất hàng.');
            }
        }
        function setIOCode(id) {
            ioCodeId = id;
            clearForm();
        }
        function showPrice() {
            var productId = $('#ddlProduct').data("kendoComboBox").value();
            if (ioCodeId && ioCodeId > 0 && productId && productId > 0) {
                callService('SelInvoiceOvr/GetProductPrice?productId=' + productId + '&ioCodeId=' + ioCodeId, function (data) {
                    data = JSON.parse(data);
                    $('#txtPrice').val(numberFormat(data[0].Price));
                });
            }
            else {
                $('#txtPrice').val('');
            }
        }
        function validForm() {
            if (detailSetting.formArea.inventory == 'block') {
                var quantity = getNumber($('#txtQuantity').val());
                var inventory = getNumber($('#txtInventory').val());
                if (quantity > inventory) {
                    msgBox.alert('Số lượng xuất không được lớn hơn số lượng tồn kho');
                    $('#txtQuantity').focus();
                    return false;
                }
            }
            return true;
        }
        return {
            'getDetail': getDetail,
            'init': init,
            'clearForm': clearForm,
            'bindGrid': bindGrid,
            'setStore': setStore,
            'setIOCode': setIOCode,
        }
    })();
    //var poDetail = (function (poDetail) {
    //    return poDetail;
    //}(invoiceDetail));
    //$(document).ready(function () {
    //    var setting = {
    //        formArea: { 'price': 'none', 'vat':'none' },
    //        gridColumnDisplay: { product: false, Quantity: false, vat: true, price: false, total: false },
    //    };
    //    poDetail.init(setting);
    //});
</script>
<div class="row invoice-detail">
    <div class="col-md-11">
        <div id="controls">
            <div class="row">
                <div class="col-md-6 nopadding">
                    <div class="row">
                        <div class="col-md-2 label">Sản phẩm:</div>
                        <div class="col-md-7 input">
                            <input type="text" id="ddlProduct" style="width: 100%" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3 nopadding">
                    <div class="row">
                        <div class="col-md-2 label">Số lượng:</div>
                        <div class="col-md-6 input">
                            <input type="text" id="txtQuantity" style="width: 100%" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3 nopadding" id="divInventory">
                    <div class="row">
                        <div class="col-md-2 label">Tồn kho:</div>
                        <div class="col-md-6 input">
                            <input type="text" id="txtInventory" style="width: 100%" disabled="disabled" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 nopadding" id="price">
                    <div class="row">
                        <div class="col-md-2 label">Đơn giá:</div>
                        <div class="col-md-6 input">
                            <input type="text" id="txtPrice" style="width: 100%" />
                        </div>
                    </div>
                </div>
                <div class="col-md-5 nopadding" id="vat">
                    <div class="row">
                        <div class="col-md-2 label">VAT:</div>
                        <div class="col-md-7" id="testRadioList">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 5px">
                <div id="btnProductAdd" class="col-md-1 btn btn-sm btn-default">Thêm</div>
                <div id="btnProductSub" class="col-md-1 btn btn-sm btn-default">Xóa</div>
            </div>
        </div>
        <div class="row">
            <div id="gridInvoiceDetail"></div>
        </div>
    </div>
</div>
