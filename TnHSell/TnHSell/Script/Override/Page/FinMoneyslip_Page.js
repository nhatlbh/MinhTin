var paymentDetail = (function (paymentDetail) {
    clonePaymentDetail = Object.create(paymentDetail);
    return clonePaymentDetail;
})(paymentDetail);


// Generated Initiate List Script

var devFinMoneyslipList = (function (finmoneyslipList) {
    cloneFinMoneyslip = Object.create(finmoneyslipList);
    return cloneFinMoneyslip;
})(finmoneyslipList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu chi';
    devFinMoneyslipList.initSearchControl();
    devFinMoneyslipList.showGrid();
    $('#btnSearch').click(function () {
        devFinMoneyslipList.search();
    });
    $('#btnAdd').click(function () {
        devFinMoneyslipList.openForm();
        paymentDetail.clearForm();
        enableForm();
    });
    paymentDetail.init({ changed: detailChange, editable: true, });
    paymentDetail.bindGrid([]);
    if (devFinMoneyslipList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devFinMoneyslipList.getGrid(), function (dataItem) {
            var formId = devFinMoneyslipList.getFormId();
            devFinMoneyslipList.openForm(formId);
            disableForm();
            paymentDetail.readOnly();
            callService("FinMoneyslipOvr/GetDetail?moneyslipId=" + formId, paymentDetail.bindGrid);
        });
    disableControlArr([$('#txtCode'), $('#dedCreatedate'), $('#btnDelete'), ]);
});

// Generated Initiate Form Script

var devFinMoneyslipForm = (function (finmoneyslipForm) {
    cloneFinMoneyslip = Object.create(finmoneyslipForm);
    return cloneFinMoneyslip;
})(finmoneyslipForm);


$(document).ready(function () {
    devFinMoneyslipForm.initFormControl();
    $('#btnSave').click(function () { save(); });
    $('#btnDelete').click(function () { devFinMoneyslipForm.del(finmoneyslipList.closeForm); });
    $('#btnNew').click(function () { devFinMoneyslipForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { save(finmoneyslipList.closeForm); });
    $('#btnClose').click(function () { finmoneyslipList.closeForm(); });
});

function save(ftnAfterSave) {
    var paymentDTO = devFinMoneyslipForm.buildDTO();
    paymentDTO.Type = 0;
    var details = [];
    var detailInfo = paymentDetail.getDetail();
    $.each(detailInfo.paymentDetail, function (idx, val) {
        var detail = {};
        if (val.Total > 0) {
            if (detailInfo.type == 'ImportInvoice') {
                paymentDTO.Type = 1;
                detail.Supplierid = detailInfo.objectId;
                detail.Importinvoiceid = val.ID;
            }
            else if (detailInfo.type == 'ReceiveProduct') {
                paymentDTO.Type = 2;
                detail.Customerid = detailInfo.objectId;
                detail.Receiveproductid = val.ID;
            }
            detail.Total = val.Total
            detail.Paydate = paymentDTO.Createdate;
            details.push(detail);
        }
    });
    if (validForm()) {
        callService('FinMoneyslipOvr/Save?moneyslipJson=' + JSON.stringify(paymentDTO) + '&moneyslipDetailJson=' + JSON.stringify(details),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devFinMoneyslipForm.setFormId(result);
                if (ftnAfterSave) {
                    ftnAfterSave(result);
                }
            }
            else
                msgBox.alert(result);
            if (ftnAfterSave)
                ftnAfterSave();
        });
    }
}

function detailChange() {
    var arrDetail = paymentDetail.getDetail().paymentDetail, totalPay = 0;
    $.each(arrDetail, function (idx, val) {
        totalPay += getNumber(val.Total);
    });
    $('#txtTotalpay').val(numberFormat(totalPay));
}
function validForm() {
    if (!devFinMoneyslipForm.validate())
        return false;
    return true;
}
function enableForm() {
    enableControlArr([$('#txtTotalpay'), $('#txtDescription'), $('#txtOrdernum'), $('#btnSaveAndClose'), $('#btnSave')]);
    $('#ddlPaymenttypeid').data("kendoComboBox").enable(true);
}
function disableForm() {
    disableControlArr([$('#txtTotalpay'), $('#txtDescription'), $('#txtOrdernum'), $('#btnSaveAndClose'), $('#btnSave')]);
    $('#ddlPaymenttypeid').data("kendoComboBox").enable(false);
}