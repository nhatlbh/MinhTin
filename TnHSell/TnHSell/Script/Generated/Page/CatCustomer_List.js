var catcustomerList = (function () {
    var seviceName = 'CatCustomer';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
    sessionKey = $('#hdfSessionKey').val();
            callService('CatManagementgroup/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlManagementgroupid_S', , "Tất cả"]);
  callService('CatDistrict/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlDistrictid_S', , "Tất cả"]);
  callService('CatProvince/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlProvinceid_S', , "Tất cả"]);
  callService('CatSalestaff/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSalestaffid_S', , "Tất cả"]);
                             
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
            $('#txtCode').val(uiObj[0].Code);
$('#txtName').val(uiObj[0].Name);
$('#ddlManagementgroupid').data('kendoComboBox').value(uiObj[0].ManagementGroupID ? uiObj[0].ManagementGroupID : '');
$('#ddlDistrictid').data('kendoComboBox').value(uiObj[0].DistrictID ? uiObj[0].DistrictID : '');
$('#ddlProvinceid').data('kendoComboBox').value(uiObj[0].ProvinceID ? uiObj[0].ProvinceID : '');
$('#ddlSalestaffid').data('kendoComboBox').value(uiObj[0].SaleStaffID ? uiObj[0].SaleStaffID : '');
$('#dedCreatedate').data('kendoDatePicker').value(uiObj[0].CreateDate);
$('#txtAddress').val(uiObj[0].Address);
$('#txtDiliveraddress').val(uiObj[0].DiliverAddress);
$('#txtTaxcode').val(uiObj[0].TaxCode);
$('#txtPhone').val(uiObj[0].Phone);
$('#txtFax').val(uiObj[0].Fax);
$('#txtEmail').val(uiObj[0].Email);
$('#txtContact').val(uiObj[0].Contact);
$('#txtContactphone').val(uiObj[0].ContactPhone);
$('#txtContactemail').val(uiObj[0].ContactEmail);
$('#txtMaxalloweddebt').val(numberFormat(uiObj[0].MaxAllowedDebt));
$('#chkBlocked').prop('checked', uiObj[0].Blocked);
$('#txtDescription').val(uiObj[0].Description);
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#txtCode').val('');
$('#txtName').val('');
$('#ddlManagementgroupid').data('kendoComboBox').value('');
$('#ddlDistrictid').data('kendoComboBox').value('');
$('#ddlProvinceid').data('kendoComboBox').value('');
$('#ddlSalestaffid').data('kendoComboBox').value('');
$('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
$('#txtAddress').val('');
$('#txtDiliveraddress').val('');
$('#txtTaxcode').val('');
$('#txtPhone').val('');
$('#txtFax').val('');
$('#txtEmail').val('');
$('#txtContact').val('');
$('#txtContactphone').val('');
$('#txtContactemail').val('');
$('#txtMaxalloweddebt').val('');
$('#chkBlocked').prop('checked', false);
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
var managementgroupid = $("#ddlManagementgroupid_S").data("kendoComboBox").value();
var districtid = $("#ddlDistrictid_S").data("kendoComboBox").value();
var provinceid = $("#ddlProvinceid_S").data("kendoComboBox").value();
var salestaffid = $("#ddlSalestaffid_S").data("kendoComboBox").value();
if (code != null && code != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
                                                                }
if (name != null && name != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Name) like lower('%" + removeSQLInject(name) + "%')";
                                                                }
if (managementgroupid != '0' && managementgroupid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "ManagementGroupID = " + managementgroupid;
                                                            }
if (districtid != '0' && districtid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "DistrictID = " + districtid;
                                                            }
if (provinceid != '0' && provinceid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "ProvinceID = " + provinceid;
                                                            }
if (salestaffid != '0' && salestaffid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "SaleStaffID = " + salestaffid;
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
{ field: 'Cat_ManagementGroup_Name', title: 'Nhóm quản lý'},
{ field: 'Cat_District_Name', title: 'Quận-Huyện'},
{ field: 'Cat_Province_Name', title: 'Tỉnh'},
{ field: 'Cat_SaleStaff_Name', title: 'Nhân viên sale'},
{ field: 'CreateDate', title: 'Ngày tạo'},
{ field: 'Address', title: 'Địa chỉ'},
{ field: 'DiliverAddress', title: 'Địa chỉ giao hàng'},
{ field: 'TaxCode', title: 'MST'},
{ field: 'Phone', title: 'Điện thoại'},
{ field: 'Fax', title: 'Fax'},
{ field: 'Email', title: 'Email'},
{ field: 'Contact', title: 'Người liên hệ'},
{ field: 'ContactPhone', title: 'SĐT liên hệ'},
{ field: 'ContactEmail', title: 'Email liên hệ'},
{ field: 'Blocked', title: 'Khóa', template: "<input type='checkbox' #= Blocked ? checked='checked' : '' # disabled='disabled' ></input>" },
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
$('#ddlManagementgroupid_S').data('kendoComboBox').value('0');
$('#ddlDistrictid_S').data('kendoComboBox').value('0');
$('#ddlProvinceid_S').data('kendoComboBox').value('0');
$('#ddlSalestaffid_S').data('kendoComboBox').value('0');
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
