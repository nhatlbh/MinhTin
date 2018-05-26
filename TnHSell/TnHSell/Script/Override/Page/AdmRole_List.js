var admroleList = (function () {
    var seviceName = 'AdmRole';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
                   
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
            $('#txtName').val(uiObj[0].Name);
$('#txtCode').val(uiObj[0].Code);
$('#txtDescription').val(uiObj[0].Description);
$('#chkDisabled').prop('checked', uiObj[0].Disabled);
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#txtName').val('');
$('#txtCode').val('');
$('#txtDescription').val('');
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
        var name = $('#txtName_S').val();
var code = $('#txtCode_S').val();
var disabled = $('#chkDisabled_S').prop('checked') ? 1 : 0;
if (name != null && name != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
                                                                }
if (code != null && code != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
                                                                }
if (typeof disabled !== 'undefined' && disabled !== '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "Disabled=" + disabled;
                                                                }
        callService(seviceName + '/GetGridData?sessionKey='+sessionKey+'&cond=' + cond, bindGrid);
    }
    
    var showGrid = function showGrid() {
        callService(seviceName + '/GetGridData?sessionKey='+sessionKey, bindGrid);
    }
    
    function bindGrid(data) {
        var curItem;
       var grid = $('#grid').kendoGrid({
        scrollable:true,
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
{ field: 'Name', title: 'Tên'},
{ field: 'Code', title: 'Mã'},
{ field: 'Description', title: 'Mô tả'},
{ field: 'Disabled', title: 'Đã khóa', template: "<input type='checkbox' #= Disabled ? checked='checked' : '' # disabled='disabled' ></input>" },
            ],
            selectable: 'row',
            scrollable:true,
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
        $('#txtName_S').val('');
$('#txtCode_S').val('');
$('#chkDisabled_S').prop('checked', false);
    }
    
    var getGrid = function(){
        if(grid)
        return grid;
        else
        return $('#grid').kendoGrid().data("kendoGrid");
    }
    
    var getFormId = function(){return curId;}
    
    var setFormId = function (id) {
        popupForm.id = id;
        $('#hdfId').val(id);
    }
    
    return {
        'search': search,
        'showGrid': showGrid,
        'refreshSearchForm': refreshSearchForm,
        'initSearchControl' : initSearchControl,
        'openForm':openForm,
        'closeForm': closeForm,
        'getGrid':getGrid,
        'getFormId':getFormId,
        'setFormId': setFormId,
    }
})();
