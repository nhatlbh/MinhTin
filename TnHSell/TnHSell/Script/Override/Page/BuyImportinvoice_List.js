﻿var buyimportinvoiceList = (function () {
    var seviceName = 'BuyImportinvoice';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCatStoreid_S', , "Tất cả"]);
        callService('CatSupplier/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCatSupplierid_S', , "Tất cả"]);
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
                $('#ddlCatStoreid').data('kendoComboBox').value(uiObj[0].Cat_StoreID ? uiObj[0].Cat_StoreID : '');
                $('#ddlCatSupplierid').data('kendoComboBox').value(uiObj[0].Cat_SupplierID ? uiObj[0].Cat_SupplierID : '');
                $('#dedCreatedate').data('kendoDatePicker').value(uiObj[0].CreateDate);
                $('#txtDescription').val(uiObj[0].Description);
                $('#txtTotaldebt').val(numberFormat(uiObj[0].TotalDebt));
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
            });
        }
        else {
            $('#hdfId').val('');
            $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
            callService('BuyImportinvoiceOvr/GetCode', function (data) { $('#txtCode').val(data) });
            $('#ddlCatStoreid').data('kendoComboBox').value('');
            $('#ddlCatSupplierid').data('kendoComboBox').value('');
            $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
            $('#txtDescription').val('');
            $('#txtTotaldebt').val('');
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
        var catstoreid = $("#ddlCatStoreid_S").data("kendoComboBox").value();
        var catsupplierid = $("#ddlCatSupplierid_S").data("kendoComboBox").value();
        var createdateF = $('#dedCreatedate_SF').val();
        var createdateT = $('#dedCreatedate_ST').val();
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
        }
        if (catstoreid != '0' && catstoreid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "Cat_StoreID = " + catstoreid;
        }
        if (catsupplierid != '0' && catsupplierid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "Cat_SupplierID = " + catsupplierid;
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
{ field: 'Cat_SaleStaff_Name', title: 'Nhân viên' },
{ field: 'Code', title: 'Mã' },
{ field: 'Cat_Store_Name', title: 'Kho' },
{ field: 'Cat_Supplier_Name', title: 'Nhà cung cấp' },
{ field: 'CreateDate', title: 'Ngày tạo' },
{ field: 'Description', title: 'Ghi chú' },
{ field: 'TotalDebt', title: 'Tổng nợ' },
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
        $('#txtCode_S').val('');
        $('#ddlCatStoreid_S').data('kendoComboBox').value('0');
        $('#ddlCatSupplierid_S').data('kendoComboBox').value('0');
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
