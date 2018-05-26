var catproductstoreList = (function () {
    var seviceName = 'CatProductStore';
    var sessionKey = $('#hdfSessionKey').val();
    var popupForm;
    var grid;
    var curId;
    var initSearchControl = function initSearchControl(){
    sessionKey = $('#hdfSessionKey').val();
                       
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
            $('#ddlProductid').data('kendoComboBox').value(uiObj[0].ProductID ? uiObj[0].ProductID : '');
$('#ddlStoreid').data('kendoComboBox').value(uiObj[0].StoreID ? uiObj[0].StoreID : '');
$('#dedImportdate').data('kendoDatePicker').value(uiObj[0].ImportDate);
$('#txtQuantity').val(numberFormat(uiObj[0].Quantity));
$('#txtInventory').val(numberFormat(uiObj[0].Inventory));
$('#txtImportcode').val(uiObj[0].ImportCode);
$('#txtPrice').val(numberFormat(uiObj[0].Price));
$('#txtOrdernum').val(numberFormat(uiObj[0].OrderNum));
        });
        }
        else
        {
            $('#hdfId').val('');
            $('#ddlProductid').data('kendoComboBox').value('');
$('#ddlStoreid').data('kendoComboBox').value('');
$('#dedImportdate').data('kendoDatePicker').value(getCurDate());
$('#txtQuantity').val('');
$('#txtInventory').val('');
$('#txtImportcode').val('');
$('#txtPrice').val('');
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
{ field: 'Cat_Product_Name', title: 'ProductID'},
{ field: 'Cat_Store_Name', title: 'StoreID'},
{ field: 'ImportDate', title: 'ImportDate'},
{ field: 'Quantity', title: 'Quantity'},
{ field: 'Inventory', title: 'Inventory'},
{ field: 'ImportCode', title: 'ImportCode'},
{ field: 'Price', title: 'Price'},
{ field: 'OrderNum', title: 'OrderNum'},
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
