
     

var admmapForm = (function () {
    var seviceName = 'AdmMap';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
             numberOnly($('#hdfId'))
        callService('AdmMap/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlParentid']);
  numberOnly($('#txtPathlevel'))
  numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Name: $('#txtName').val(),
Path: $('#txtPath').val(),
Parentid: $("#ddlParentid").data("kendoComboBox").value(),
Pathlevel: getNumber( $('#txtPathlevel').val()),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtName')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?admmapJson=' + JSON.stringify(data), function (id) {
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
        $('#txtCode').val('');
$('#txtName').val('');
$('#txtPath').val('');
$('#ddlParentid').data('kendoComboBox').value('');
$('#txtPathlevel').val('');
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
