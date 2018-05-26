
     

var finimportpaymentForm = (function () {
    var seviceName = 'FinImportpayment';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
             numberOnly($('#hdfId'))
  callService('FinMoneyslip/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlMoneyslipid']);
  callService('BuyImportinvoice/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlImportinvoiceid']);
  callService('CatSupplier/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSupplierid']);
  $('#dedPaydate').kendoDatePicker({
                                    format: '{0:dd/MM/yyyy}',
                                    });
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Moneyslipid: $("#ddlMoneyslipid").data("kendoComboBox").value(),
Importinvoiceid: $("#ddlImportinvoiceid").data("kendoComboBox").value(),
Supplierid: $("#ddlSupplierid").data("kendoComboBox").value(),
Paydate: $('#dedPaydate').val()
        };
  }
  var validate = function () {
        return notEmpty([$('#ddlMoneyslipid'),$('#ddlImportinvoiceid'),$('#ddlSupplierid')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?finimportpaymentJson=' + JSON.stringify(data), function (id) {
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
        $('#ddlMoneyslipid').data('kendoComboBox').value('');
$('#ddlImportinvoiceid').data('kendoComboBox').value('');
$('#ddlSupplierid').data('kendoComboBox').value('');
$('#dedPaydate').data('kendoDatePicker').value(getCurDate());
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
