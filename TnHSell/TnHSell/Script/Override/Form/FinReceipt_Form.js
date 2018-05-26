


var finreceiptForm = (function () {
    var seviceName = 'FinReceipt';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl() {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('CatReceipttype/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlReceipttypeid']);
        numberOnly($('#txtTotalpay'))
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtOrdernum'))

    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Receipttypeid: $("#ddlReceipttypeid").data("kendoComboBox").value(),
            Totalpay: getNumber($('#txtTotalpay').val()),
            Createdate: $('#dedCreatedate').val(),
            Description: $('#txtDescription').val(),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#txtCode'), $('#ddlReceipttypeid'), $('#txtTotalpay'), $('#dedCreatedate')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?finreceiptJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Phiếu thu cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Phiếu thu này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('FinReceiptOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#ddlReceipttypeid').data('kendoComboBox').value('');
        $('#txtTotalpay').val('');
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
