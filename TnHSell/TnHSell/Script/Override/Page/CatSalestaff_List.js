var catsalestaffList = (function () {
    var seviceName = 'CatSalestaff';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
        sessionKey = $('#hdfSessionKey').val();
        callService('CatBranch/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlBranchid_S', , "Tất cả"]);
        loadCombobox(JSON.stringify([{ ID: 1, Name: 'Nam' }, { ID: 2, Name: 'Nữ' }]), 'ddlSex_S', '', 'Tất cả');
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
        if (id > 0) {
            callService(seviceName + "/GetByID?id=" + id, function (data) {
                var uiObj = JSON.parse(data);
                $('#hdfId').val(id);
                $('#txtCode').val(uiObj[0].Code);
                $('#txtName').val(uiObj[0].Name);
                $('#ddlBranchid').data('kendoComboBox').value(uiObj[0].BranchID ? uiObj[0].BranchID : '');
                $('#ddlUserid').data('kendoComboBox').value(uiObj[0].UserID ? uiObj[0].UserID : '');
                $('#txtAddress').val(uiObj[0].Address);
                $('#txtPhone').val(uiObj[0].Phone);
                $('#txtEmail').val(uiObj[0].Email);
                $('#txtMobile').val(uiObj[0].Mobile);
                $('#txtSocialnum').val(uiObj[0].SocialNum);
                $('#ddlSex').data('kendoComboBox').value(uiObj[0].Sex ? uiObj[0].Sex : '');
                $('#dedBirthdate').data('kendoDatePicker').value(uiObj[0].BirthDate);
                $('#chkIsquit').prop('checked', uiObj[0].IsQuit);
                $('#txtDescription').val(uiObj[0].Description);
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
            });
        }
        else {
            $('#hdfId').val('');
            $('#txtCode').val('');
            $('#txtName').val('');
            $('#ddlBranchid').data('kendoComboBox').value('');
            $('#ddlUserid').data('kendoComboBox').value('');
            $('#txtAddress').val('');
            $('#txtPhone').val('');
            $('#txtEmail').val('');
            $('#txtMobile').val('');
            $('#txtSocialnum').val('');
            $('#ddlSex').data('kendoComboBox').value('');
            $('#dedBirthdate').data('kendoDatePicker').value();
            $('#chkIsquit').prop('checked', false);
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
        var code = $('#txtCode_S').val();
        var name = $('#txtName_S').val();
        var branchid = $("#ddlBranchid_S").data("kendoComboBox").value();
        var sex = $("#ddlSex_S").data("kendoComboBox").value();
        var isquit = $('#chkIsquit_S').prop('checked') ? 1 : 0;
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
        }
        if (name != null && name != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
        }
        if (branchid != '0' && branchid != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "BranchID = " + branchid;
        }
        if (sex != '0' && sex != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "Sex = " + sex;
        }
        if (typeof isquit !== 'undefined' && isquit !== '') {
            cond += cond != '' ? ' and ' : '';
            cond += "IsQuit=" + isquit;
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
{ field: 'Code', title: 'Mã' },
{ field: 'Name', title: 'Tên' },
{ field: 'Cat_Branch_Name', title: 'Chi nhánh' },
{ field: 'Adm_User_Name', title: 'Người dùng' },
{ field: 'Address', title: 'Địa chỉ' },
{ field: 'Phone', title: 'Điện thoại' },
{ field: 'Email', title: 'Email' },
{ field: 'Mobile', title: 'Di động' },
{ field: 'BirthDate', title: 'Ngày sinh' },
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
        $('#ddlBranchid_S').data('kendoComboBox').value('0');
        $('#ddlSex_S').data('kendoComboBox').value('0');
        $('#chkIsquit_S').prop('checked', false);
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
