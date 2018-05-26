﻿


var buysupplierreturnForm = (function () {
    var seviceName = 'BuySupplierreturn';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(setting) {
        numberOnly($('#hdfId'))
        callService('CatSalestaff/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSalestaffid']);
        callService('BuyImportinvoice/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlImportinvoiceid', setting.impInvChanged]);
        callService('CatSupplier/GetComboboxData?sessionKey=' + sessionKey, loadCombobox, ['ddlSupplierid']);
        $('#dedCreatedate').kendoDatePicker({
            format: '{0:dd/MM/yyyy}',
        });
        numberOnly($('#txtTotaldebt'))
        numberOnly($('#txtOrdernum'))
    }

    var buildDTO = function () {
        return {
            Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
            Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
            Code: $('#txtCode').val(),
            Importinvoiceid: $("#ddlImportinvoiceid").data("kendoComboBox").value(),
            Supplierid: $("#ddlSupplierid").data("kendoComboBox").value(),
            Createdate: $('#dedCreatedate').val(),
            Description: $('#txtDescription').val(),
            Totaldebt: getNumber($('#txtTotaldebt').val()),
            Ordernum: getNumber($('#txtOrdernum').val())
        };
    }
    var validate = function () {
        return notEmpty([$('#txtCode'), $('#ddlSupplierid'), $('#dedCreatedate'), $('#txtTotaldebt')]);
    }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?buysupplierreturnJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if (ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }

    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Phiếu trả hàng nhà cung cấp cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Phiếu trả hàng nhà cung cấp này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }

    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
        callService('BuySupplierReturnOvr/GetCode', function (data) { $('#txtCode').val(data) });
        $('#ddlImportinvoiceid').data('kendoComboBox').value('');
        $('#ddlSupplierid').data('kendoComboBox').value('');
        $('#dedCreatedate').data('kendoDatePicker').value(getCurDate());
        $('#txtDescription').val('');
        $('#txtTotaldebt').val('');
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
