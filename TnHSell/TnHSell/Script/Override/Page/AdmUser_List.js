var admuserList = (function () {
    var seviceName = 'AdmUser';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl() {
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
        if (id > 0) {
            callService(seviceName + "/GetByID?id=" + id, function (data) {
                var uiObj = JSON.parse(data);
                $('#hdfId').val(id);
                $('#txtCode').val(uiObj[0].Code);
                $('#txtName').val(uiObj[0].Name);
                $('#txtPassword').val(uiObj[0].Password);
                $('#txtDescription').val(uiObj[0].Description);
                $('#dedCreatedate').data('kendoDatePicker').value(uiObj[0].CreateDate);
                $('#dedExpiredate').data('kendoDatePicker').value(uiObj[0].ExpireDate);
                $('#chkDisabled').prop('checked', uiObj[0].Disabled);
                $('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
            });
        }
        else {
            $('#hdfId').val('');
            $('#txtCode').val('');
            $('#txtName').val('');
            $('#txtPassword').val('');
            $('#txtDescription').val('');
            $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
            $('#dedExpiredate').data('kendoDatePicker').value();
            $('#chkDisabled').prop('checked', false);
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
        var createdateF = $('#dedCreatedate_SF').val();
        var createdateT = $('#dedCreatedate_ST').val();
        var disabled = $('#chkDisabled_S').prop('checked') ? 1 : 0;
        if (code != null && code != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
        }
        if (name != null && name != '') {
            cond += cond != '' ? ' and ' : '';
            cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
        }
        if (createdateF != '' || createdateT != '') {
            createdateF = createdateF == '' ? '01/01/1900' : createdateF;
            createdateT = createdateT == '' ? '30/12/9999' : createdateT;
            cond += cond != '' ? ' and ' : '';
            cond += "convert(datetime,CreateDate,103) between convert(datetime,'" + createdateF + "',103) and convert(datetime,'" + createdateT + "',103) ";
        }
        if (typeof disabled !== 'undefined' && disabled !== '') {
            cond += cond != '' ? ' and ' : '';
            cond += "Disabled=" + disabled;
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
{ field: 'Description', title: 'Mô tả' },
{ field: 'CreateDate', title: 'Ngày tạo' },
{ field: 'ExpireDate', title: 'Ngày hết hạn' },
{ field: 'Disabled', title: 'Đã khóa', template: "<input type='checkbox' #= Disabled ? checked='checked' : '' # disabled='disabled' ></input>" },
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
        $('#dedCreatedate_SF').data('kendoDatePicker').value('');
        $('#dedCreatedate_ST').data('kendoDatePicker').value('');
        $('#chkDisabled_S').prop('checked', false);
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
