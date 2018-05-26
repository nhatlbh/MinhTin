


var admuserForm = (function () {
    var seviceName = 'AdmUser';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl() {
        numberOnly($('#hdfId'))
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedExpiredate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtOrdernum'))

    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Code: $('#txtCode').val(),
            Name: $('#txtName').val(),
            Password: $('#txtPassword').val(),
            Description: $('#txtDescription').val(),
            Createdate: $('#dedCreatedate').val(),
            Expiredate: $('#dedExpiredate').val(),
            Disabled: $('#chkDisabled').prop('checked') ? 1 : 0,
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#txtName'), $('#txtPassword'), $('#dedCreatedate')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?admuserJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn người dùng cần xóa');
        }
        else if (confirm("Bạn có muốn xóa người dùng này?")) {
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
        $('#txtPassword').val('');
        $('#txtDescription').val('');
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
        $('#dedExpiredate').data('kendoDatePicker').value();
        $('#chkDisabled').prop('checked', false);
        $('#txtOrdernum').val('');
        $("#grid .k-state-selected").removeClass('k-state-selected');
        $('.error').removeClass('error');
    }

    var setFormId = function (id) { $('#hdfId').val(id); }
    var getFormId = function () { return $('#hdfId').val(); }

    return {
        'buildDTO': buildDTO,
        'validate': validate,
        'save': save,
        'del': del,
        'refreshInputForm': refreshInputForm,
        'initFormControl': initFormControl,
        'setFormId': setFormId,
        'getFormId': getFormId,
    }
})();
