﻿var guarreturnList = (function () {
    var seviceName = 'GuarReturn';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid_S', , "Tất cả"]);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid_S', , "Tất cả"]);
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
                $('#ddlCustomerid').data('kendoComboBox').value(uiObj[0].CustomerID ? uiObj[0].CustomerID : '');
                $('#ddlGuaranteeid').data('kendoComboBox').value(uiObj[0].GuaranteeID ? uiObj[0].GuaranteeID : '');
                $('#txtCode').val(uiObj[0].Code);
                $('#dedCreatedate').data('kendoDatePicker').value(uiObj[0].CreateDate);
                $('#txtDescription').val(uiObj[0].Description);
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
            });
        }
        else {
            $('#hdfId').val('');
            $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
            $('#ddlCustomerid').data('kendoComboBox').value('');
            $('#ddlGuaranteeid').data('kendoComboBox').value('');
            callService('GuarReturnOvr/GetCode', function (data) { $('#txtCode').val(data) });
            $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
            $('#txtDescription').val('');
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
        var salestaffid = $("#ddlSalestaffid_S").data("kendoComboBox").value();
        var customerid = $("#ddlCustomerid_S").data("kendoComboBox").value();
        var code = $('#txtCode_S').val();
        var createdateF = $('#dedCreatedate_SF').val();
        var createdateT = $('#dedCreatedate_ST').val();
        if (salestaffid != '0' && salestaffid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "SaleStaffID = " + salestaffid;
        }
        if (customerid != '0' && customerid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "CustomerID = " + customerid;
        }
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
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
{ field: 'Cat_SaleStaff_Name', title: 'Nhân viên tạo' },
{ field: 'Cat_Customer_Name', title: 'Khách hàng' },
{ field: 'Buy_Guarantee_Name', title: 'Phiếu bảo hành' },
{ field: 'Code', title: 'Mã' },
{ field: 'CreateDate', title: 'Ngày tạo' },
{ field: 'Description', title: 'Ghi chú' },
{ field: 'OrderNum', title: 'Thứ tự' },
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
        $('#ddlSalestaffid_S').data('kendoComboBox').value('0');
        $('#ddlCustomerid_S').data('kendoComboBox').value('0');
        $('#txtCode_S').val('');
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
