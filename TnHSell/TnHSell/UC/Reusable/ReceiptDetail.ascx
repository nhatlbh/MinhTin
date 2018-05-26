<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiptDetail.ascx.cs" Inherits="TnHSell.UC.Reusable.ReceiptDetail" %>
<script type="text/javascript">

    var receiptDetail = (function () {
        var setting, sessionKey = $('#hdfSessionKey').val(), arrReceiptDetail = [];
        var init = function (option) {
            setting = $.extend(setting, option);
            $('#ddlCustomer').svcCombobox({ service: 'CatCustomer/GetComboboxData?sessionKey=' + sessionKey, change: customerChanged, enable: false });
            $('#ddlSupplier').svcCombobox({ service: 'CatSupplier/GetComboboxData?sessionKey=' + sessionKey, change: supplierChanged, enable: false });
            $('#chkSelInvoice').change(function () { receiptTypeChanged('sell'); });
            $('#chkSuppReturn').change(function () { receiptTypeChanged('suppReturn'); });
        }
        var bindGrid = function (data) {
            data = typeof data == 'string' ? JSON.parse(data) : data;
            var grid = $('#grdReceiptDetail').kendoGrid({
                dataSource: {
                    type: 'odata',
                    data: data,
                    schema: {
                        model: {
                            id: 'ID',
                            fields: {
                                ID: { editable: false, },
                                Code: { editable: false, },
                                CreateDate: { editable: false, },
                                TotalDebt: { editable: false, },
                                Pay: { type: 'boolean' },
                                Total: { editable: setting.editable, },
                            },
                        }
                    },
                    change: function (e) {
                        if (e.action === "itemchange") {
                            //var model = e.items[0];
                            //model.Total = model.TotalDebt;
                            //$("#grdReceiptDetail").find("tr[data-uid='" + model.uid + "'] td:eq(4)").text(numberFormat(model.TotalDebt));
                            setting.changed();
                        }
                    },
                },
                editable: true,
                columns: [
                { field: 'ID', hidden: true },
                { field: 'Code', title: 'Mã CT', },
                { field: 'CreateDate', title: 'Ngày' },
                { field: 'TotalDebt', title: 'Còn nợ', template: '#: numeral(TotalDebt).format("0,0")#', },
                {
                    field: 'Pay', title: 'Trả', template: '<input type="checkbox" #= Pay ? \'checked="checked"\' : "" # class="chkbx" style="width:100%;" />', width: 50, attributes: {
                        style: "padding:0px !important;"
                    }
                },
                { field: 'Total', title: 'Đã trả', template: '#: numeral(Total).format("0,0") #', },
                ],
                // change: gridRowSelected,
                pageable: {
                    buttonCount: 5
                },
                persistSelection: true,
            });
            arrReceiptDetail = grid.data().kendoGrid.dataSource.view();
            $("#grdReceiptDetail .k-grid-content").on("change", "input.chkbx", function (e) {
                if (setting.editable) {
                    var grid = $("#grdReceiptDetail").data("kendoGrid"),
                       dataItem = grid.dataItem($(e.target).closest("tr"));
                    if (dataItem)
                        if (this.checked) {
                            dataItem.set("Total", dataItem.get('TotalDebt'));
                            dataItem.set("Pay", this.checked);
                        }
                        else {
                            dataItem.set("Total", 0);
                            dataItem.set("Pay", this.checked);
                        }
                }
            });
            return grid;
        }
        setting = function (option) {
            setting = $.extend(setting, option);
        }
        function getDetail() {
            var type = '';
            var objectId;
            if ($('#chkSelInvoice').prop('checked')) {
                type = 'SellInvoice';
                objectId = $('#ddlCustomer').data("kendoComboBox").value();
            }
            else if ($('#chkSelInvoice').prop('checked')) {
                type = 'SuppReturn';
                objectId = $('#ddlSupplier').data("kendoComboBox").value();
            }
            return {
                'type': type,
                'objectId': objectId,
                'receiptDetail': arrReceiptDetail,
            };
        }
        function readOnly() {
            disableControlArr([$('#chkSuppReturn'), $('#chkSelInvoice'), ]);
            $('#ddlCustomer').data("kendoComboBox").enable(false);
            $('#ddlSupplier').data("kendoComboBox").enable(false);
            setting.editable = false;
        }
        function clearForm() {
            enableControlArr([$('#chkSuppReturn'), $('#chkSelInvoice'), ]);
            $('#chkSelInvoice').prop('checked', false);
            $('#chkSuppReturn').prop('checked', false);
            $('#ddlCustomer').data("kendoComboBox").value('');
            $('#ddlCustomer').data("kendoComboBox").enable(false);
            $('#ddlSupplier').data("kendoComboBox").value('');
            $('#ddlSupplier').data("kendoComboBox").enable(false);
            setting.editable = true;
            bindGrid([]);
        }
        return {
            'init': init,
            'bindGrid': bindGrid,
            'setting': setting,
            'getDetail': getDetail,
            'clearForm': clearForm,
            'readOnly': readOnly,
        }

        function receiptTypeChanged(receiptType) {
            if (receiptType == 'sell') {
                var checked = $('#chkSelInvoice').prop('checked');
                if (checked) {
                    $('#chkSuppReturn').prop('checked', false);
                    $('#ddlCustomer').data("kendoComboBox").enable(true);
                    $('#ddlSupplier').data("kendoComboBox").enable(false);
                    $('#ddlSupplier').data("kendoComboBox").value('');
                }
                else {
                    $('#ddlCustomer').data("kendoComboBox").enable(false);
                }
            }
            else {
                var checked = $('#chkSuppReturn').prop('checked');
                if (checked) {
                    $('#chkSelInvoice').prop('checked', false);
                    $('#ddlCustomer').data("kendoComboBox").enable(false);
                    $('#ddlCustomer').data("kendoComboBox").value('');
                    $('#ddlSupplier').data("kendoComboBox").enable(true);
                }
                else {
                    $('#ddlSupplier').data("kendoComboBox").enable(false);
                }
            }
            bindGrid([]);
        }
        function customerChanged() {
            var customerId = $('#ddlCustomer').data("kendoComboBox").value();
            if (getNumber(customerId) > 0)
                callService('FinReceiptOvr/GetSellInvoice?customerId=' + customerId, bindGrid);
        }
        function supplierChanged() {
            var supplierId = $('#ddlSupplier').data("kendoComboBox").value();
            if (getNumber(supplierId) > 0)
                callService('FinReceiptOvr/GetSuppReturn?supplierId=' + supplierId, bindGrid);
        }
    })();
</script>
<div class="row">
    <div class="col-md-1 label">Thu từ:</div>
    <div class="col-md-2 label">Phiếu bán hàng</div>
    <div class="col-md-1" style="margin-top: 8px; padding-left: 0px;">
        <input type="checkbox" id="chkSelInvoice" />
    </div>
    <div class="col-md-2 label">Phiếu trả hàng NCC</div>
    <div class="col-md-1" style="margin-top: 8px;">
        <input type="checkbox" id="chkSuppReturn" />
    </div>
</div>
<div class="row">
    <div class="col-md-1 label">Khách hàng:</div>
    <div class="input col-md-4">
        <input placeholder="--- Chọn ---" id="ddlCustomer" />
    </div>
    <div class="col-md-1 label">Nhà cung cấp:</div>
    <div class="input col-md-4">
        <input placeholder="--- Chọn ---" id="ddlSupplier" />
    </div>
</div>
<div class="row">
    <div id="grdReceiptDetail"></div>
</div>

