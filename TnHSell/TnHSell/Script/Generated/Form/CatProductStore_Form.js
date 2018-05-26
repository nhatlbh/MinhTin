
     

var catproductstoreForm = (function () {
    var seviceName = 'CatProductStore';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
  callService('CatProduct/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlProductid']);
  callService('CatStore/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlStoreid']);
  $('#dedImportdate').kendoDatePicker({
                                    format: '{0:dd/MM/yyyy}',
                                    });
  numberOnly($('#txtQuantity'))
  numberOnly($('#txtInventory'))
    numberOnly($('#txtPrice'))
  numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Productid: $("#ddlProductid").data("kendoComboBox").value(),
Storeid: $("#ddlStoreid").data("kendoComboBox").value(),
Importdate: $('#dedImportdate').val(),
Quantity: getNumber( $('#txtQuantity').val()),
Inventory: getNumber( $('#txtInventory').val()),
Importcode: $('#txtImportcode').val(),
Price: getNumber( $('#txtPrice').val()),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#ddlProductid'),$('#ddlStoreid'),$('#dedImportdate'),$('#txtQuantity'),$('#txtImportcode'),$('#txtPrice')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catproductstoreJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn  cần xóa');
        }
        else if (confirm("Bạn có muốn xóa  này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }
    
    var refreshInputForm = function refreshInputForm() {
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
