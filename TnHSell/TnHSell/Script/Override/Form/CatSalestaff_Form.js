
     

var catsalestaffForm = (function () {
    var seviceName = 'CatSalestaff';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
             numberOnly($('#hdfId'))
      callService('CatBranch/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlBranchid']);
  callService('AdmUser/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlUserid']);
            loadCombobox(JSON.stringify([{ID:1,Name:'Nam'},{ID:2,Name:'Nữ'}]), ['ddlSex']);  $('#dedBirthdate').kendoDatePicker({
                                    format: '{0:dd/MM/yyyy}',
                                    });
      numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Name: $('#txtName').val(),
Branchid: $("#ddlBranchid").data("kendoComboBox").value(),
Userid: $("#ddlUserid").data("kendoComboBox").value(),
Address: $('#txtAddress').val(),
Phone: $('#txtPhone').val(),
Email: $('#txtEmail').val(),
Mobile: $('#txtMobile').val(),
Socialnum: $('#txtSocialnum').val(),
Sex: getNumber( $('#ddlSex').val()),
Birthdate: $('#dedBirthdate').val(),
Isquit: $('#chkIsquit').prop('checked') ? 1 : 0,
Description: $('#txtDescription').val(),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtCode'),$('#ddlBranchid')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catsalestaffJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Nhân viên Sale cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Nhân viên Sale này?")) {
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
$('#ddlUserid').data('kendoComboBox').value('');
$('#txtAddress').val('');
$('#txtPhone').val('');
$('#txtEmail').val('');
$('#txtMobile').val('');
$('#txtSocialnum').val('');
$('#ddlSex').data('kendoComboBox').value('');
$('#dedBirthdate').data('kendoDatePicker').value();
$('#chkIsquit').prop('checked', false);
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
