
     

var catproductForm = (function () {
    var seviceName = 'CatProduct';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
      callService('CatUnit/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlUnitid']);
  callService('CatColor/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlColorid']);
  callService('CatSupplier/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSupplierid']);
  callService('CatManufacture/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlManufactureid']);
  callService('CatProducttype/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlProducttypeid']);
  callService('CatProductgroup/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlProductgroupid']);
  callService('CatBranch/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlBranchid']);
          numberOnly($('#txtWarningnum'))
  numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Name: $('#txtName').val(),
Unitid: $("#ddlUnitid").data("kendoComboBox").value(),
Colorid: $("#ddlColorid").data("kendoComboBox").value(),
Supplierid: $("#ddlSupplierid").data("kendoComboBox").value(),
Manufactureid: $("#ddlManufactureid").data("kendoComboBox").value(),
Producttypeid: $("#ddlProducttypeid").data("kendoComboBox").value(),
Productgroupid: $("#ddlProductgroupid").data("kendoComboBox").value(),
Branchid: $("#ddlBranchid").data("kendoComboBox").value(),
Description: $('#txtDescription').val(),
Blocked: $('#chkBlocked').prop('checked') ? 1 : 0,
Iscomponent: $('#chkIscomponent').prop('checked') ? 1 : 0,
Barcode: $('#txtBarcode').val(),
Warningnum: getNumber( $('#txtWarningnum').val()),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtName'),$('#ddlUnitid'),$('#ddlProducttypeid'),$('#ddlProductgroupid'),$('#ddlBranchid')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catproductJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Sản phẩm cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Sản phẩm này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }
    
    var refreshInputForm = function refreshInputForm() {
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
        $('.error').removeClass('error');
    }
    
    var setFormId = function (id) { $('#hdfId').val(id); }
    var getFormId = function () { return $('#hdfId').val(); }
 
    return {
        'buildDTO':buildDTO,
        'validate':validate,
        'save': save,
        'del': del,
        'refreshInputForm': refreshInputForm,
        'initFormControl': initFormControl,
        'setFormId': setFormId,
        'getFormId': getFormId,
    }
})();
