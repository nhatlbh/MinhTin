var receiptDetail = (function (receiptDetail) {
    cloneReceiptDetail = Object.create(receiptDetail);
    return cloneReceiptDetail;
})(receiptDetail);


// Generated Initiate List Script

var devFinReceiptList = (function (finreceiptList) {
    cloneFinReceipt = Object.create(finreceiptList);
    return cloneFinReceipt;
})(finreceiptList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu thu';
    devFinReceiptList.initSearchControl();
    devFinReceiptList.showGrid();
    $('#btnSearch').click(function () {
        devFinReceiptList.search();
    });
    $('#btnAdd').click(function () {
        devFinReceiptList.openForm();
        receiptDetail.clearForm();
        enableForm();
    });
    receiptDetail.init({ changed: detailChange, editable: true, });
    receiptDetail.bindGrid([]);
    if (devFinReceiptList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devFinReceiptList.getGrid(), function (dataItem) {
            var formId = devFinReceiptList.getFormId();
            devFinReceiptList.openForm(formId);
            disableForm();
            receiptDetail.readOnly();
            callService("FinReceiptOvr/GetDetail?receiptId=" + formId, receiptDetail.bindGrid);
        });
    disableControlArr([$('#txtCode'), $('#dedCreatedate'), $('#btnDelete'), ]);
});

// Generated Initiate Form Script

var devFinReceiptForm = (function (finreceiptForm) {
    cloneFinReceipt = Object.create(finreceiptForm);
    return cloneFinReceipt;
})(finreceiptForm);


$(document).ready(function () {
    devFinReceiptForm.initFormControl();
    $('#btnSave').click(function () { save(); });
    $('#btnDelete').click(function () { devFinReceiptForm.del(finreceiptList.closeForm); });
    $('#btnNew').click(function () {
        devFinReceiptForm.refreshInputForm();
        receiptDetail.clearForm();
        enableForm();
    });
    $('#btnSaveAndClose').click(function () { save(finreceiptList.closeForm); });
    $('#btnClose').click(function () { finreceiptList.closeForm(); });
});

function save(ftnAfterSave) {
    var receiptDTO = devFinReceiptForm.buildDTO();
    receiptDTO.Type = 0;
    var details = [];
    var detailInfo = receiptDetail.getDetail();
    $.each(detailInfo.receiptDetail, function (idx, val) {
        var detail = {};
        if (val.Total > 0) {
            if (detailInfo.type == 'SellInvoice') {
                receiptDTO.Type = 1;
                detail.Customerid = detailInfo.objectId;
                detail.Invoiceid = val.ID;
            }
            else if (detailInfo.type == 'SuppReturn') {
                receiptDTO.Type = 2;
                detail.Supplierid = detailInfo.objectId;
                detail.Supplierreturnid = val.ID;
            }
            detail.Total = val.Total
            detail.Incomedate = receiptDTO.CreateDate;
            details.push(detail);
        }
    });
    if (validForm()) {
        callService('FinReceiptOvr/Save?type=' + detailInfo.type + '&receiptJson=' + JSON.stringify(receiptDTO) + '&receiptDetailJson=' + JSON.stringify(details),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devFinReceiptForm.setFormId(result);
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
    var arrDetail = receiptDetail.getDetail().receiptDetail, totalPay = 0;
    $.each(arrDetail, function (idx, val) {
        totalPay += getNumber(val.Total);
    });
    $('#txtTotalpay').val(numberFormat(totalPay));
}
function validForm() {
    return true;
}
function enableForm() {
    enableControlArr([$('#txtTotalpay'), $('#txtDescription'), $('#txtOrdernum'), $('#btnSaveAndClose'), $('#btnSave')]);
    $('#ddlReceipttypeid').data("kendoComboBox").enable(true);
}
function disableForm() {
    disableControlArr([$('#txtTotalpay'), $('#txtDescription'), $('#txtOrdernum'), $('#btnSaveAndClose'), $('#btnSave')]);
    $('#ddlReceipttypeid').data("kendoComboBox").enable(false);
}