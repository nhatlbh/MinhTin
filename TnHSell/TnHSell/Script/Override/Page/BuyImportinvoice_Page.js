
// Generated Initiate List Script
var invDetailSetting = {
    formArea: { 'price': 'block', 'vat': 'block' },
    gridColumnDisplay: { product: false, amount: false, vat: false, price: false, total: false },
    changed: detailChanged,
};
var impInvDetail = (function (impInvDetail) {
    return impInvDetail;
}(invoiceDetail));
var devBuyImportinvoiceList = (function (buyimportinvoiceList) {
    cloneBuyImportinvoice = Object.create(buyimportinvoiceList);
    return cloneBuyImportinvoice;
})(buyimportinvoiceList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu nhập';
    devBuyImportinvoiceList.initSearchControl();
    devBuyImportinvoiceList.showGrid();
    $('#btnSearch').click(function () {
        devBuyImportinvoiceList.search();
    });

    impInvDetail.init(invDetailSetting);
    $('#btnAdd').click(function () {
        devBuyImportinvoiceList.openForm();
        impInvDetail.clearForm(invDetailSetting);
        enableForm();
    });
    if (devBuyImportinvoiceList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devBuyImportinvoiceList.getGrid(), function (dataItem) {
            var formId = devBuyImportinvoiceList.getFormId();
            devBuyImportinvoiceList.openForm(formId);
            impInvDetail.bindGrid("BuyImportinvoiceOvr/GetDetail?invoiceId=" + formId);
            disableForm();
        });
    disableControlArr([$('#txtTotaldebt'), $('#dedCreatedate'), $('#txtCode'), $('#btnDelete')]);
});

// Generated Initiate Form Script

var devBuyImportinvoiceForm = (function (buyimportinvoiceForm) {
    cloneBuyImportinvoice = Object.create(buyimportinvoiceForm);
    return cloneBuyImportinvoice;
})(buyimportinvoiceForm);


$(document).ready(function () {
    devBuyImportinvoiceForm.initFormControl();
    $('#btnSave').click(function () { if (devBuyImportinvoiceForm.validate()) saveImportInvoice(); });
    $('#btnDelete').click(function () { devBuyImportinvoiceForm.del(buyimportinvoiceList.closeForm); });
    $('#btnNew').click(function () { devBuyImportinvoiceForm.refreshInputForm(); impInvDetail.clearForm(invDetailSetting); enableForm(); });
    $('#btnSaveAndClose').click(function () { saveImportInvoice(buyimportinvoiceList.closeForm); });
    $('#btnClose').click(function () { buyimportinvoiceList.closeForm(); });
});
function saveImportInvoice(ftnAfterSave) {
    var importInvoiceDTO = devBuyImportinvoiceForm.buildDTO();
    var invoiceDetails = [];
    $.each(impInvDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        invoiceDetails.push(detailDTO);
    });
    callService('BuyImportinvoiceOvr/Save?importInvoceJson=' + JSON.stringify(importInvoiceDTO) + '&invoiceDetailsJson=' + JSON.stringify(invoiceDetails),
    function (result) {
        if (result.indexOf("Lỗi:") == -1) {
            devBuyImportinvoiceForm.setFormId(result);
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
function detailChanged() {
    var total = 0;
    $.each(impInvDetail.getDetail(), function (idx, val) {
        total += val.Quantity * val.Price;
    })
    $('#txtTotaldebt').val(numberFormat(total));
}
function disableForm() {
    disableControlArr([$('#txtDescription'), $('#txtOrdernum'),
                       $('#txtTotaldebt'), $('#dedCreatedate'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlCatStoreid').data("kendoComboBox").enable(false);
    $('#ddlCatSupplierid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlCatStoreid').data("kendoComboBox").enable(true);
    $('#ddlCatSupplierid').data("kendoComboBox").enable(true);
}