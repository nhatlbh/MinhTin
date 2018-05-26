


var selreceiveproductForm = (function () {
    var seviceName = 'SelReceiveproduct';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(setting) {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('SelInvoice/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlInvoiceid', setting.sellInvChanged]);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid']);
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid']);
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtTotal'))
        numberOnly($('#txtTotalreturn'))
        numberOnly($('#txtDiscount'))
        numberOnly($('#txtOrdernum'))

    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Invoiceid: $("#ddlInvoiceid").data("kendoComboBox").value(),
            Customerid: $("#ddlCustomerid").data("kendoComboBox").value(),
            Storeid: $("#ddlStoreid").data("kendoComboBox").value(),
            Createdate: $('#dedCreatedate').val(),
            Description: $('#txtDescription').val(),
            Total: getNumber($('#txtTotal').val()),
            Totalreturn: getNumber($('#txtTotalreturn').val()),
            Discount: getNumber($('#txtDiscount').val()),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#txtCode'), $('#ddlInvoiceid'), $('#ddlCustomerid'), $('#ddlStoreid'), $('#dedCreatedate'), $('#txtTotal')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?selreceiveproductJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Phiếu nhận hàng trả cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Phiếu nhận hàng trả này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('SelReceiveproductOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#ddlInvoiceid').data('kendoComboBox').value('');
        $('#ddlCustomerid').data('kendoComboBox').value('');
        $('#ddlStoreid').data('kendoComboBox').value('');
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
        $('#txtDescription').val('');
        $('#txtTotal').val('');
        $('#txtTotalreturn').val('');
        $('#txtDiscount').val('');
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
