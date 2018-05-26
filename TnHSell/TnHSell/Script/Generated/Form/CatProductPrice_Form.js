
     

var catproductpriceForm = (function () {
    var seviceName = 'CatProductPrice';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
  callService('CatProduct/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlProductid']);
  callService('CatIocode/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlIocodeid']);
  numberOnly($('#txtPrice'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Productid: $("#ddlProductid").data("kendoComboBox").value(),
Iocodeid: $("#ddlIocodeid").data("kendoComboBox").value(),
Price: getNumber( $('#txtPrice').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#ddlProductid'),$('#ddlIocodeid'),$('#txtPrice')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catproductpriceJson=' + JSON.stringify(data), function (id) {
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
$('#ddlIocodeid').data('kendoComboBox').value('');
$('#txtPrice').val('');
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
