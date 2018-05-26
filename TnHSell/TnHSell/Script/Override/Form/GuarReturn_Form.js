


var guarreturnForm = (function () {
    var seviceName = 'GuarReturn';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(setting) {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid', setting.customerChanged]);
        callService('BuyGuarantee/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlGuaranteeid', setting.guaranteeChanged]);
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtOrdernum'))
    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Customerid: $("#ddlCustomerid").data("kendoComboBox").value(),
            Guaranteeid: $("#ddlGuaranteeid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Createdate: $('#dedCreatedate').val(),
            Description: $('#txtDescription').val(),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#ddlCustomerid'), $('#ddlGuaranteeid'), $('#txtCode')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?guarreturnJson=' + JSON.stringify(data), function (id) {
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
        $('#ddlCustomerid').data('kendoComboBox').value('');
        $('#ddlGuaranteeid').data('kendoComboBox').value('');
        callService('GuarReturnOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
        $('#txtDescription').val('');
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
