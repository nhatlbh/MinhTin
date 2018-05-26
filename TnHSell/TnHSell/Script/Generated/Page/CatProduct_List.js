var catproductList = (function () {
    var seviceName = 'CatProduct';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
    sessionKey = $('#hdfSessionKey').val();
              callService('CatColor/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlColorid_S', , "Tất cả"]);
  callService('CatSupplier/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSupplierid_S', , "Tất cả"]);
        callService('CatBranch/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlBranchid_S', , "Tất cả"]);
             
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
$('#ddlUnitid').data('kendoComboBox').value(uiObj[0].UnitID ? uiObj[0].UnitID : '');
$('#ddlColorid').data('kendoComboBox').value(uiObj[0].ColorID ? uiObj[0].ColorID : '');
$('#ddlSupplierid').data('kendoComboBox').value(uiObj[0].SupplierID ? uiObj[0].SupplierID : '');
$('#ddlManufactureid').data('kendoComboBox').value(uiObj[0].ManufactureID ? uiObj[0].ManufactureID : '');
$('#ddlProducttypeid').data('kendoComboBox').value(uiObj[0].ProductTypeID ? uiObj[0].ProductTypeID : '');
$('#ddlProductgroupid').data('kendoComboBox').value(uiObj[0].ProductGroupID ? uiObj[0].ProductGroupID : '');
$('#ddlBranchid').data('kendoComboBox').value(uiObj[0].BranchID ? uiObj[0].BranchID : '');
$('#txtDescription').val(uiObj[0].Description);
$('#chkBlocked').prop('checked', uiObj[0].Blocked);
$('#chkIscomponent').prop('checked', uiObj[0].IsComponent);
$('#txtBarcode').val(uiObj[0].Barcode);
$('#txtWarningnum').val(numberFormat(uiObj[0].WarningNum));
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#txtCode').val('');
$('#txtName').val('');
$('#ddlUnitid').data('kendoComboBox').value('');
$('#ddlColorid').data('kendoComboBox').value('');
$('#ddlSupplierid').data('kendoComboBox').value('');
$('#ddlManufactureid').data('kendoComboBox').value('');
$('#ddlProducttypeid').data('kendoComboBox').value('');
$('#ddlProductgroupid').data('kendoComboBox').value('');
$('#ddlBranchid').data('kendoComboBox').value('');
$('#txtDescription').val('');
$('#chkBlocked').prop('checked', false);
$('#chkIscomponent').prop('checked', false);
$('#txtBarcode').val('');
$('#txtWarningnum').val('');
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
var colorid = $("#ddlColorid_S").data("kendoComboBox").value();
var supplierid = $("#ddlSupplierid_S").data("kendoComboBox").value();
var branchid = $("#ddlBranchid_S").data("kendoComboBox").value();
if (code != null && code != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
                                                                }
if (name != null && name != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
                                                                }
if (colorid != '0' && colorid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "ColorID = " + colorid;
                                                            }
if (supplierid != '0' && supplierid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "SupplierID = " + supplierid;
                                                            }
if (branchid != '0' && branchid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "BranchID = " + branchid;
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
{ field: 'Name', title: 'tên'},
{ field: 'Cat_Unit_Name', title: 'Đơn vị tính'},
{ field: 'Cat_Color_Name', title: 'Màu'},
{ field: 'Cat_Supplier_Name', title: 'Nhà cung cấp'},
{ field: 'Cat_Manufacture_Name', title: 'Nhà sản xuất'},
{ field: 'Cat_ProductType_Name', title: 'Loại sản phẩm'},
{ field: 'Cat_ProductGroup_Name', title: 'Nhóm sản phẩm'},
{ field: 'Cat_Branch_Name', title: 'Chi nhánh'},
{ field: 'Description', title: 'Ghi chú'},
{ field: 'Blocked', title: 'Khóa', template: "<input type='checkbox' #= Blocked ? checked='checked' : '' # disabled='disabled' ></input>" },
{ field: 'IsComponent', title: 'Là linh kiện', template: "<input type='checkbox' #= IsComponent ? checked='checked' : '' # disabled='disabled' ></input>" },
{ field: 'Barcode', title: 'Barcode'},
{ field: 'WarningNum', title: 'Định mức'},
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
$('#ddlColorid_S').data('kendoComboBox').value('0');
$('#ddlSupplierid_S').data('kendoComboBox').value('0');
$('#ddlBranchid_S').data('kendoComboBox').value('0');
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
