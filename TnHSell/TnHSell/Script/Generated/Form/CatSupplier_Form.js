
     

var catsupplierForm = (function () {
    var seviceName = 'CatSupplier';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
                      numberOnly($('#txtMaxalloweddebt'))
      numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Name: $('#txtName').val(),
Address: $('#txtAddress').val(),
Taxcode: $('#txtTaxcode').val(),
Phone: $('#txtPhone').val(),
Fax: $('#txtFax').val(),
Email: $('#txtEmail').val(),
Contact: $('#txtContact').val(),
Contactphone: $('#txtContactphone').val(),
Contactemail: $('#txtContactemail').val(),
Maxalloweddebt: getNumber( $('#txtMaxalloweddebt').val()),
Blocked: $('#chkBlocked').prop('checked') ? 1 : 0,
Description: $('#txtDescription').val(),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtCode'),$('#txtName'),$('#txtAddress')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?catsupplierJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Nhà cung cấp cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Nhà cung cấp này?")) {
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
$('#txtAddress').val('');
$('#txtTaxcode').val('');
$('#txtPhone').val('');
$('#txtFax').val('');
$('#txtEmail').val('');
$('#txtContact').val('');
$('#txtContactphone').val('');
$('#txtContactemail').val('');
$('#txtMaxalloweddebt').val('');
$('#chkBlocked').prop('checked', false);
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
