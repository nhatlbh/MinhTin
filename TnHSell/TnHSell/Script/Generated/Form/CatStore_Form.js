
     

var catstoreForm = (function () {
    var seviceName = 'CatStore';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
      callService('CatBranch/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlBranchid']);
  callService('CatStoretype/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlStoretypeid']);
      numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Name: $('#txtName').val(),
Branchid: $("#ddlBranchid").data("kendoComboBox").value(),
Storetypeid: $("#ddlStoretypeid").data("kendoComboBox").value(),
Isclose: $('#chkIsclose').prop('checked') ? 1 : 0,
Description: $('#txtDescription').val(),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtCode'),$('#ddlBranchid'),$('#ddlStoretypeid')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catstoreJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Kho cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Kho này?")) {
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
$('#ddlBranchid').data('kendoComboBox').value('');
$('#ddlStoretypeid').data('kendoComboBox').value('');
$('#chkIsclose').prop('checked', false);
$('#txtDescription').val('');
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
