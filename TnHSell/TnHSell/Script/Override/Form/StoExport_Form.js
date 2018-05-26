


var stoexportForm = (function () {
    var seviceName = 'StoExport', rdlReason;
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(setting) {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid', setting.storeChanged]);
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtOrdernum'))
        rdlReason = $('#rdlReason').radioList({
            name: 'reason',
            items: [{ value: '1', text: 'Xuất hư' }, { value: '2', text: 'Xuất mất', }, ],
            defaultValue: '1',
            itemClass:'col-md-2'
        });
    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Storeid: $("#ddlStoreid").data("kendoComboBox").value(),
            Reason: getNumber(rdlReason.getValue()),
            Description: $('#txtDescription').val(),
            Createdate: $('#dedCreatedate').val(),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#txtCode'), $('#ddlStoreid')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?stoexportJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Phiếu xuất kho cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Phiếu xuất kho này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('StoExportOvr/GetCode', function (data) { $('#txtCode').val(data) }); $('#ddlStoreid').data('kendoComboBox').value('');;
        $('#ddlStoreid').data('kendoComboBox').value('');
        rdlReason.setValue('1');
        $('#txtDescription').val('');
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
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
