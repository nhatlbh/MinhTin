


var selinvoiceForm = (function () {
    var seviceName = 'SelInvoice';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(setting) {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('CatStore/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlStoreid', setting.storeChanged]);
        callService('CatCustomer/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlCustomerid',setting.customerChanged]);
        callService('CatIocode/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlIocodeid', setting.ioCodeChanged]);
        $('#dedIncomedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtPercentdiscount'))
        numberOnly($('#txtValuediscount'))
        numberOnly($('#txtTotaldiscount'))
        numberOnly($('#txtTotal'))
        numberOnly($('#txtTotaldebt'))
        numberOnly($('#txtOrdernum'))
        $('#dedDeliverdate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });

    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Storeid: $("#ddlStoreid").data("kendoComboBox").value(),
            Customerid: $("#ddlCustomerid").data("kendoComboBox").value(),
            Iocodeid: $("#ddlIocodeid").data("kendoComboBox").value(),
            Deliveryaddress: $('#txtDeliveryaddress').val(),
            Financefilenum: $('#txtFinancefilenum').val(),
            Filenum: $('#txtFilenum').val(),
            Receiptnum: $('#txtReceiptnum').val(),
            Incomedate: $('#dedIncomedate').val(),
            Description: $('#txtDescription').val(),
            Percentdiscount: getNumber($('#txtPercentdiscount').val()),
            Valuediscount: getNumber($('#txtValuediscount').val()),
            Totaldiscount: getNumber($('#txtTotaldiscount').val()),
            Total: getNumber($('#txtTotal').val()),
            Totaldebt: getNumber($('#txtTotaldebt').val()),
            Ordernum: getNumber($('#txtOrdernum').val()),
            Isdelivered: $('#chkIsdelivered').prop('checked') ? 1 : 0,
            Deliverdate: $('#dedDeliverdate').val(),
            Createdate: $('#dedCreatedate').val()
        };
    }
    var validate = function () {
        return notEmpty([$('#ddlSalestaffid'), $('#txtCode'), $('#ddlStoreid'), $('#ddlCustomerid'), $('#ddlIocodeid'), $('#txtDeliveryaddress'), $('#txtTotaldebt'), $('#dedCreatedate')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?selinvoiceJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Phiếu bán hàng cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Phiếu bán hàng này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('SelInvoiceOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#ddlStoreid').data('kendoComboBox').value('');
        $('#ddlCustomerid').data('kendoComboBox').value('');
        $('#ddlIocodeid').data('kendoComboBox').value('');
        $('#txtDeliveryaddress').val('');
        $('#txtFinancefilenum').val('');
        $('#txtFilenum').val('');
        $('#txtReceiptnum').val('');
        $('#dedIncomedate').data('kendoDatePicker').value(getCurDate());
        $('#txtDescription').val('');
        $('#txtPercentdiscount').val('');
        $('#txtValuediscount').val('');
        $('#txtTotaldiscount').val('');
        $('#txtTotal').val('');
        $('#txtTotaldebt').val('');
        $('#txtOrdernum').val('');
        $('#chkIsdelivered').prop('checked', false);
        $('#dedDeliverdate').data('kendoDatePicker').value(getCurDate());
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
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
