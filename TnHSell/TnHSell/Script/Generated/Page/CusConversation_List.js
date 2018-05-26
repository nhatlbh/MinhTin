var cusconversationList = (function () {
    var seviceName = 'CusConversation';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
    sessionKey = $('#hdfSessionKey').val();
            callService('CatSalestaff/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSalestaffid_S', , "Tất cả"]);
  callService('CatCustomer/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlCustomerid_S', , "Tất cả"]);
             
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
$('#txtTitle').val(uiObj[0].Title);
$('#ddlSalestaffid').data('kendoComboBox').value(uiObj[0].SaleStaffID ? uiObj[0].SaleStaffID : '');
$('#ddlCustomerid').data('kendoComboBox').value(uiObj[0].CustomerID ? uiObj[0].CustomerID : '');
$('#txtConvContent').val(uiObj[0].Conv_Content);
$('#ddlChanelid').data('kendoComboBox').value(uiObj[0].ChanelID ? uiObj[0].ChanelID : '');
$('#ddlConvresultid').data('kendoComboBox').value(uiObj[0].ConvResultID ? uiObj[0].ConvResultID : '');
$('#dedCreatedon').data('kendoDatePicker').value(uiObj[0].CreatedOn);
$('#txtNote').val(uiObj[0].Note);
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#txtCode').val('');
$('#txtTitle').val('');
$('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
$('#ddlCustomerid').data('kendoComboBox').value('');
$('#txtConvContent').val('');
$('#ddlChanelid').data('kendoComboBox').value('');
$('#ddlConvresultid').data('kendoComboBox').value('');
$('#dedCreatedon').data('kendoDatePicker').value(getCurDate());
$('#txtNote').val('');
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
var title = $('#txtTitle_S').val();
var salestaffid = $("#ddlSalestaffid_S").data("kendoComboBox").value();
var customerid = $("#ddlCustomerid_S").data("kendoComboBox").value();
if (code != null && code != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Code) like lower('%" + removeSQLInject(code) + "%')";
                                                                }
if (title != null && title != '') {
                                                                    cond += cond != '' ? ' and ' : '';
                                                                    cond += "lower(Title) like lower('%" + removeSQLInject(title) + "%')";
                                                                }
if (salestaffid != '0' && salestaffid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "SaleStaffID = " + salestaffid;
                                                            }
if (customerid != '0' && customerid != '') {
                                                                cond += cond != '' ? ' and ' : '';
                                                                cond += "CustomerID = " + customerid;
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
{ field: 'Cat_SaleStaff_Name', title: 'Nhân viên'},
{ field: 'Cat_Customer_Name', title: 'Khách hàng'},
{ field: 'Conv_Content', title: 'Nội dung'},
{ field: 'Cat_Chanel_Name', title: 'Kênh liên hệ'},
{ field: 'Cat_ConvResult_Name', title: 'Kết quả'},
{ field: 'CreatedOn', title: 'Ngày cập nhật'},
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
$('#txtTitle_S').val('');
$('#ddlSalestaffid_S').data('kendoComboBox').value('0');
$('#ddlCustomerid_S').data('kendoComboBox').value('0');
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
