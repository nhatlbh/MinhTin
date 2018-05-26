var buyguaranteeList = (function () {
    var seviceName = 'BuyGuarantee';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid_S', , "Tất cả"]);
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid_S', , "Tất cả"]);
        $('#dedReceivedate_SF').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedReceivedate_ST').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedExpectreturndate_SF').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedExpectreturndate_ST').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedReturndate_SF').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedReturndate_ST').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        callService('CatGuaranteestatus/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlGuarstatusid_S', , "Tất cả"]);

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
                $('#txtName').val(uiObj[0].Name);
                $('#ddlCustomerid').data('kendoComboBox').value(uiObj[0].CustomerID ? uiObj[0].CustomerID : '');
                $('#ddlStoreid').data('kendoComboBox').value(uiObj[0].StoreID ? uiObj[0].StoreID : '');
                $('#dedReceivedate').data('kendoDatePicker').value(uiObj[0].ReceiveDate);
                $('#dedExpectreturndate').data('kendoDatePicker').value(uiObj[0].ExpectReturnDate);
                $('#dedReturndate').data('kendoDatePicker').value(uiObj[0].ReturnDate);
                $('#txtNotifydates').val(numberFormat(uiObj[0].NotifyDates));
                $('#txtDescription').val(uiObj[0].Description);
                $('#ddlGuarstatusid').data('kendoComboBox').value(uiObj[0].GuarStatusID ? uiObj[0].GuarStatusID : '');
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
            });
        }
        else {
            $('#hdfId').val('');
            $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
            callService('BuyGuaranteeOvr/GetCode', function (data) { $('#txtCode').val(data) });
            $('#txtName').val('');
            $('#ddlCustomerid').data('kendoComboBox').value('');
            $('#ddlStoreid').data('kendoComboBox').value('');
            $('#dedReceivedate').data('kendoDatePicker').value(getCurDate());
            $('#dedExpectreturndate').data('kendoDatePicker').value(getCurDate());
            $('#dedReturndate').data('kendoDatePicker').value(getCurDate());
            $('#txtNotifydates').val('');
            $('#txtDescription').val('');
            $('#ddlGuarstatusid').data('kendoComboBox').value('');
            $('#txtOrdernum').val('');
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
        var name = $('#txtName_S').val();
        var customerid = $("#ddlCustomerid_S").data("kendoComboBox").value();
        var storeid = $("#ddlStoreid_S").data("kendoComboBox").value();
        var receivedateF = $('#dedReceivedate_SF').val();
        var receivedateT = $('#dedReceivedate_ST').val();
        var expectreturndateF = $('#dedExpectreturndate_SF').val();
        var expectreturndateT = $('#dedExpectreturndate_ST').val();
        var returndateF = $('#dedReturndate_SF').val();
        var returndateT = $('#dedReturndate_ST').val();
        var guarstatusid = $("#ddlGuarstatusid_S").data("kendoComboBox").value();
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
        }
        if (name != null && name != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
        }
        if (customerid != '0' && customerid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "CustomerID = " + customerid;
        }
        if (storeid != '0' && storeid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "StoreID = " + storeid;
        }
        if (receivedateF != '' || receivedateT != '') {
            receivedateF = receivedateF == '' ? '01/01/1900' : receivedateF;
            receivedateT = receivedateT == '' ? '30/12/9999' : receivedateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,ReceiveDate,103) between convert(datetime,'" + receivedateF + "',103) and convert(datetime,'" + receivedateT + "',103) ";
        }
        if (expectreturndateF != '' || expectreturndateT != '') {
            expectreturndateF = expectreturndateF == '' ? '01/01/1900' : expectreturndateF;
            expectreturndateT = expectreturndateT == '' ? '30/12/9999' : expectreturndateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,ExpectReturnDate,103) between convert(datetime,'" + expectreturndateF + "',103) and convert(datetime,'" + expectreturndateT + "',103) ";
        }
        if (returndateF != '' || returndateT != '') {
            returndateF = returndateF == '' ? '01/01/1900' : returndateF;
            returndateT = returndateT == '' ? '30/12/9999' : returndateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,ReturnDate,103) between convert(datetime,'" + returndateF + "',103) and convert(datetime,'" + returndateT + "',103) ";
        }
        if (guarstatusid != '0' && guarstatusid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "GuarStatusID = " + guarstatusid;
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
            { field: 'Cat_SaleStaff_Name', title: 'Nhân viên' },
            { field: 'Code', title: 'Mã' },
            { field: 'Cat_Customer_Name', title: 'Khách hàng' },
            { field: 'ReceiveDate', title: 'Ngày nhận' },
            { field: 'ExpectReturnDate', title: 'Ngày hẹn trả' },
            { field: 'ReturnDate', title: 'Ngày trả' },
            { field: 'NotifyDates', title: 'Số ngày báo trước' },
            { field: 'Description', title: 'Ghi chú' },
            { field: 'Cat_GuaranteeStatus_Name', title: 'Trạng thái' },
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
        $('#txtName_S').val('');
        $('#ddlCustomerid_S').data('kendoComboBox').value('0');
        $('#ddlStoreid_S').data('kendoComboBox').value('0');
        $('#dedReceivedate_SF').data('kendoDatePicker').value('');
        $('#dedReceivedate_ST').data('kendoDatePicker').value('');
        $('#dedExpectreturndate_SF').data('kendoDatePicker').value('');
        $('#dedExpectreturndate_ST').data('kendoDatePicker').value('');
        $('#dedReturndate_SF').data('kendoDatePicker').value('');
        $('#dedReturndate_ST').data('kendoDatePicker').value('');
        $('#ddlGuarstatusid_S').data('kendoComboBox').value('0');
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
