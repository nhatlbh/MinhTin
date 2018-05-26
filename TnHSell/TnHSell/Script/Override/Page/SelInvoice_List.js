var selinvoiceList = (function () {
    var seviceName = 'SelInvoice';
    var sessionKey;
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
        sessionKey = $('#hdfSessionKey').val();
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid_S', , "Tất cả"]);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid_S', , "Tất cả"]);
        callService('CatIocode/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlIocodeid_S', , "Tất cả"]);
        $('#dedDeliverdate_SF').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedDeliverdate_ST').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedCreatedate_SF').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedCreatedate_ST').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });

        popupForm = $('#popup').popupForm(
                {
                    open: formOpened,
                    close: formClosed,
                });
    }

    var openForm = function openForm(id) {
        setFormId(id);
        popupForm.popup.open();
    }

    function formOpened(e) {
        var id = popupForm.id;
        $('#ddlSalestaffid').data('kendoComboBox').enable(false);
        if (id > 0) {
            callService(seviceName + "/GetByID?id=" + id, function (data) {
                var uiObj = JSON.parse(data);
                $('#hdfId').val(id);
                $('#ddlSalestaffid').data('kendoComboBox').value(uiObj[0].SaleStaffID ? uiObj[0].SaleStaffID : '');
                $('#txtCode').val(uiObj[0].Code);
                $('#ddlStoreid').data('kendoComboBox').value(uiObj[0].StoreID ? uiObj[0].StoreID : '');
                $('#ddlCustomerid').data('kendoComboBox').value(uiObj[0].CustomerID ? uiObj[0].CustomerID : '');
                $('#ddlIocodeid').data('kendoComboBox').value(uiObj[0].IOCodeID ? uiObj[0].IOCodeID : '');
                $('#txtDeliveryaddress').val(uiObj[0].DeliveryAddress);
                $('#txtFinancefilenum').val(uiObj[0].FinanceFileNum);
                $('#txtFilenum').val(uiObj[0].FileNum);
                $('#txtReceiptnum').val(uiObj[0].ReceiptNum);
                $('#dedIncomedate').data('kendoDatePicker').value(uiObj[0].IncomeDate);
                $('#txtDescription').val(uiObj[0].Description);
                $('#txtPercentdiscount').val(numberFormat(uiObj[0].PercentDiscount));
                $('#txtValuediscount').val(numberFormat(uiObj[0].ValueDiscount));
                $('#txtTotaldiscount').val(numberFormat(uiObj[0].TotalDiscount));
                $('#txtTotal').val(numberFormat(uiObj[0].Total));
                $('#txtTotaldebt').val(numberFormat(uiObj[0].TotalDebt));
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
                $('#chkIsdelivered').prop('checked', uiObj[0].IsDelivered);
                $('#dedDeliverdate').data('kendoDatePicker').value(uiObj[0].DeliverDate);
                $('#dedCreatedate').data('kendoDatePicker').value(uiObj[0].CreateDate);
            });
        }
        else {
            $('#hdfId').val('');
            $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
            callService('SelInvoiceOvr/GetCode', function (data) { $('#txtCode').val(data) });
            $('#ddlStoreid').data('kendoComboBox').value('');
            $('#ddlCustomerid').data('kendoComboBox').value('');
            $('#ddlIocodeid').data('kendoComboBox').value('');
            $('#txtDeliveryaddress').val('');
            $('#txtFinancefilenum').val('');
            $('#txtFilenum').val('');
            $('#txtReceiptnum').val('');
            $('#dedIncomedate').data('kendoDatePicker').value(getCurDate());
            $('#txtDescription').val('');
            $('#txtPercentdiscount').val('');
            $('#txtValuediscount').val('');
            $('#txtTotaldiscount').val('');
            $('#txtTotal').val('');
            $('#txtTotaldebt').val('');
            $('#txtOrdernum').val('');
            $('#chkIsdelivered').prop('checked', false);
            $('#dedDeliverdate').data('kendoDatePicker').value(getCurDate());
            $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
            $("#grid .k-state-selected").removeClass('k-state-selected');
        }
        $('.error').removeClass('error');
    }

    var closeForm = function closeForm() {
        popupForm.popup.close();
        $('#hdfId').val('');
    }

    var formClosed = function formClosed() {
        showGrid();
    }

    var search = function search(action) {
        var cond = '';
        var code = $('#txtCode_S').val();
        var storeid = $("#ddlStoreid_S").data("kendoComboBox").value();
        var customerid = $("#ddlCustomerid_S").data("kendoComboBox").value();
        var iocodeid = $("#ddlIocodeid_S").data("kendoComboBox").value();
        var isdelivered = $('#chkIsdelivered_S').prop('checked') ? 1 : 0;
        var deliverdateF = $('#dedDeliverdate_SF').val();
        var deliverdateT = $('#dedDeliverdate_ST').val();
        var createdateF = $('#dedCreatedate_SF').val();
        var createdateT = $('#dedCreatedate_ST').val();
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
        }
        if (storeid != '0' && storeid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "StoreID = " + storeid;
        }
        if (customerid != '0' && customerid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "CustomerID = " + customerid;
        }
        if (iocodeid != '0' && iocodeid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "IOCodeID = " + iocodeid;
        }
        if (typeof isdelivered !== 'undefined' && isdelivered !== '') {
            cond += cond != '' ? ' and ' : '';
            cond += "IsDelivered=" + isdelivered;
        }
        if (deliverdateF != '' || deliverdateT != '') {
            deliverdateF = deliverdateF == '' ? '01/01/1900' : deliverdateF;
            deliverdateT = deliverdateT == '' ? '30/12/9999' : deliverdateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,DeliverDate,103) between convert(datetime,'" + deliverdateF + "',103) and convert(datetime,'" + deliverdateT + "',103) ";
        }
        if (createdateF != '' || createdateT != '') {
            createdateF = createdateF == '' ? '01/01/1900' : createdateF;
            createdateT = createdateT == '' ? '30/12/9999' : createdateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,CreateDate,103) between convert(datetime,'" + createdateF + "',103) and convert(datetime,'" + createdateT + "',103) ";
        }
        callService(seviceName + '/GetGridData?sessionKey=' + sessionKey + '&cond=' + cond, bindGrid);
    }

    var showGrid = function showGrid() {
        callService(seviceName + '/GetGridData?sessionKey=' + sessionKey, bindGrid);
    }

    function bindGrid(data) {
        var curItem;
        var grid = $('#grid').kendoGrid({
            scrollable: true,
            dataSource: {
                type: 'odata',
                data: JSON.parse(data),
                pageSize: 20,
                schema: {
                    model: {
                        id: 'ID',
                    }
                },
            },
            columns: [
            { field: 'ID', hidden: true },
            { field: 'Cat_SaleStaff_Name', title: 'Nhân viên', width:200, },
            { field: 'Code', title: 'Mã', width: 200, },
            { field: 'CreateDate', title: 'Ngày tạo', width: 200, },
            { field: 'Cat_Store_Name', title: 'Kho', width: 200, },
            { field: 'Cat_Customer_Name', title: 'Khách hàng', width: 200, },
            { field: 'Cat_IOCode_Name', title: 'Mã nhập xuất', width: 200, },
            { field: 'DeliveryAddress', title: 'ĐC giao hàng', width: 250, },
            { field: 'Description', title: 'Ghi chú', width: 300, },
            { field: 'TotalDiscount', title: 'Tổng tiền giảm giá', template: '#: numeral(TotalDiscount).format("0,0") #', width: 150, },
            { field: 'Total', title: 'Tổng tiền', template: '#: numeral(Total).format("0,0") #', width: 200, },
            { field: 'TotalDebt', title: 'Tổng nợ', template: '#: numeral(TotalDebt).format("0,0") #', width: 200, },
            { field: 'IsDelivered', title: 'Đã giao hàng', template: "<input type='checkbox' #= IsDelivered ? checked='checked' : '' # disabled='disabled' ></input>", width: 120, },
            ],
            selectable: 'row',
            scrollable: true,
            change: gridRowChange,
            pageable: {
                buttonCount: 5
            },
            filterable: {
                mode: "row"
            },
        }).data("kendoGrid");


        function gridRowChange(arg) {
            curId = this.select().find("td:first").html();
        }
        kendoHelpers.grid.eventRowDoubleClick(grid,
            function (dataItem) {
                openForm(curId);
            });
    }

    var refreshSearchForm = function refreshSearchForm() {
        $('#txtCode_S').val('');
        $('#ddlStoreid_S').data('kendoComboBox').value('0');
        $('#ddlCustomerid_S').data('kendoComboBox').value('0');
        $('#ddlIocodeid_S').data('kendoComboBox').value('0');
        $('#chkIsdelivered_S').prop('checked', false);
        $('#dedDeliverdate_SF').data('kendoDatePicker').value('');
        $('#dedDeliverdate_ST').data('kendoDatePicker').value('');
        $('#dedCreatedate_SF').data('kendoDatePicker').value('');
        $('#dedCreatedate_ST').data('kendoDatePicker').value('');
    }

    var getGrid = function () {
        if (grid)
            return grid;
        else
            return $('#grid').kendoGrid().data("kendoGrid");
    }

    var getFormId = function () { return curId; }

    var setFormId = function (id) {
        popupForm.id = id;
        $('#hdfId').val(id);
    }

    return {
        'search': search,
        'showGrid': showGrid,
        'refreshSearchForm': refreshSearchForm,
        'initSearchControl': initSearchControl,
        'openForm': openForm,
        'closeForm': closeForm,
        'getGrid': getGrid,
        'getFormId': getFormId,
        'setFormId': setFormId,
    }
})();
