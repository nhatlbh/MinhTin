var catstoreList = (function () {
    var seviceName = 'CatStore';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
    sessionKey = $('#hdfSessionKey').val();
            callService('CatBranch/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlBranchid_S', , "Tất cả"]);
  callService('CatStoretype/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlStoretypeid_S', , "Tất cả"]);
       
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
$('#ddlStoretypeid').data('kendoComboBox').value(uiObj[0].StoreTypeID ? uiObj[0].StoreTypeID : '');
$('#chkIsclose').prop('checked', uiObj[0].IsClose);
$('#txtDescription').val(uiObj[0].Description);
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#txtCode').val('');
$('#txtName').val('');
$('#ddlBranchid').data('kendoComboBox').value('');
$('#ddlStoretypeid').data('kendoComboBox').value('');
$('#chkIsclose').prop('checked', false);
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
var storetypeid = $("#ddlStoretypeid_S").data("kendoComboBox").value();
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
if (storetypeid != '0' && storetypeid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "StoreTypeID = " + storetypeid;
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
{ field: 'Code', title: 'Mã'},
{ field: 'Name', title: 'Tên'},
{ field: 'Cat_Branch_Name', title: 'Chi nhánh'},
{ field: 'Cat_StoreType_Name', title: 'Loại kho'},
{ field: 'IsClose', title: 'Đóng kho', template: "<input type='checkbox' #= IsClose ? checked='checked' : '' # disabled='disabled' ></input>" },
{ field: 'Description', title: 'Ghi chú'},
{ field: 'OrderNum', title: 'Thứ tự'},
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
        $('#txtCode_S').val('');
$('#txtName_S').val('');
$('#ddlBranchid_S').data('kendoComboBox').value('0');
$('#ddlStoretypeid_S').data('kendoComboBox').value('0');
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
