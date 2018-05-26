


var buyguaranteeForm = (function () {
    var seviceName = 'BuyGuarantee';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl() {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid']);
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid']);
        $('#dedReceivedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedExpectreturndate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedReturndate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtNotifydates'))
        callService('CatGuaranteestatus/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlGuarstatusid']);
        numberOnly($('#txtOrdernum'))

    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Name: $('#txtName').val(),
            Customerid: $("#ddlCustomerid").data("kendoComboBox").value(),
            Storeid: $("#ddlStoreid").data("kendoComboBox").value(),
            Receivedate: $('#dedReceivedate').val(),
            Expectreturndate: $('#dedExpectreturndate').val(),
            Returndate: $('#dedReturndate').val(),
            Notifydates: getNumber($('#txtNotifydates').val()),
            Description: $('#txtDescription').val(),
            Guarstatusid: $("#ddlGuarstatusid").data("kendoComboBox").value(),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#txtCode'), $('#ddlCustomerid'), $('#dedReceivedate'), $('#dedExpectreturndate')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?buyguaranteeJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Tình\Thành phố cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Tình\Thành phố này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('BuyGuaranteeOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#txtName').val('');
        $('#ddlCustomerid').data('kendoComboBox').value('');
        $('#ddlStoreid').data('kendoComboBox').value('');
        $('#dedReceivedate').data('kendoDatePicker').value(getCurDate());
        $('#dedExpectreturndate').data('kendoDatePicker').value(getCurDate());
        $('#dedReturndate').data('kendoDatePicker').value(getCurDate());
        $('#txtNotifydates').val('');
        $('#txtDescription').val('');
        $('#ddlGuarstatusid').data('kendoComboBox').value('');
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
