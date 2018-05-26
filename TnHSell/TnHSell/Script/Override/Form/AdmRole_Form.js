
     

var admroleForm = (function () {
    var seviceName = 'AdmRole';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
             numberOnly($('#hdfId'))
            numberOnly($('#txtOrdernum'))
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Name: $('#txtName').val(),
Code: $('#txtCode').val(),
Description: $('#txtDescription').val(),
Disabled: $('#chkDisabled').prop('checked') ? 1 : 0,
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtName'),$('#txtCode')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?admroleJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn nhóm cần xóa');
        }
        else if (confirm("Bạn có muốn xóa nhóm này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }
    
    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#txtName').val('');
$('#txtCode').val('');
$('#txtDescription').val('');
$('#chkDisabled').prop('checked', false);
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
