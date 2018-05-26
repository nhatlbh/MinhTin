
var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none', 'btnAdd': 'none' },
    gridColumnDisplay: { product: false, amount: false, vat: false, price: false, total: false },
    changed: detailChanged,
    priceEditable: true,
};
var suppRetDetail = (function (suppRetDetail) {
    return suppRetDetail;
}(invoiceDetail));

// Generated Initiate List Script

var devBuySupplierreturnList = (function (buysupplierreturnList) {
    cloneBuySupplierreturn = Object.create(buysupplierreturnList);
    return cloneBuySupplierreturn;
})(buysupplierreturnList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu trả hàng nhà cung cấp';
    devBuySupplierreturnList.initSearchControl();
    devBuySupplierreturnList.showGrid();
    $('#btnSearch').click(function () {
        devBuySupplierreturnList.search();
    });
    $('#btnAdd').click(function () {
        devBuySupplierreturnList.openForm();
        suppRetDetail.clearForm();
        enableForm();
    });
    if (devBuySupplierreturnList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devBuySupplierreturnList.getGrid(), function (dataItem) {
            var formId = devBuySupplierreturnList.getFormId();
            devBuySupplierreturnList.openForm(formId);
            suppRetDetail.bindGrid("BuySupplierReturnOvr/GetDetail?suppReturnId=" + formId);
            disableForm();
        });
    suppRetDetail.init(invDetailSetting);
    disableControlArr([$('#dedCreatedate'), $('#btnDelete'), $('#txtCode'), $('#txtTotaldebt')])
});

// Generated Initiate Form Script

var devBuySupplierreturnForm = (function (buysupplierreturnForm) {
    cloneBuySupplierreturn = Object.create(buysupplierreturnForm);
    return cloneBuySupplierreturn;
})(buysupplierreturnForm);


$(document).ready(function () {
    devBuySupplierreturnForm.initFormControl({ 'impInvChanged': impInvChanged });
    $('#btnSave').click(function () { saveSuppReturn(); });
    $('#btnDelete').click(function () { devBuySupplierreturnForm.del(buysupplierreturnList.closeForm); });
    $('#btnNew').click(function () { devBuySupplierreturnForm.refreshInputForm(); suppRetDetail.clearForm(); enableForm(); });
    $('#btnSaveAndClose').click(function () { saveSuppReturn(buysupplierreturnList.closeForm); });
    $('#btnClose').click(function () { buysupplierreturnList.closeForm(); });

});
function impInvChanged(e) {

    callService('BuyImportinvoice/GetByID?id=' + this.value(), function (data) {
        data = JSON.parse(data);
        var ddlSupplier = $('#ddlSupplierid').data("kendoComboBox");
        if (data.length > 0)
            ddlSupplier.value(data[0].Cat_SupplierID);
    });
    suppRetDetail.bindGrid('BuyImportinvoiceOvr/GetDetail?invoiceId=' + this.value(), [detailChanged, ], true);
}

function saveSuppReturn(ftnAfterSave) {
    var suppReturnDTO = devBuySupplierreturnForm.buildDTO();
    var suppReturnDetails = [];
    $.each(suppRetDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        suppReturnDetails.push(detailDTO);
    });
    callService('BuySupplierReturnOvr/Save?suppReturnJson=' + JSON.stringify(suppReturnDTO) + '&suppReturnDetailsJson=' + JSON.stringify(suppReturnDetails),
    function (result) {
        if (result.indexOf("Lỗi:") == -1) {
            devBuyImportinvoiceForm.setFormId(result);
            if (ftnAfterSave) {
                ftnAfterSave(result);
            }
            //callService("AdmUserOvr/GetRoleList?userId=" + result, grdRole_User.setSelectedRows, grdRole_User.grid);
        }
        else
            alert(result);
        if (ftnAfterSave)
            ftnAfterSave();
    });
}
function detailChanged() {
    var total = 0;
    $.each(suppRetDetail.getDetail(), function (idx, val) {
        total += val.Quantity * val.Price;
    })
    $('#txtTotaldebt').val(numberFormat(total));
}
function disableForm() {
    disableControlArr([$('#txtDescription'), $('#txtOrdernum'),
                       $('#txtTotaldebt'), $('#dedCreatedate'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlImportinvoiceid').data("kendoComboBox").enable(false);
    $('#ddlSupplierid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlImportinvoiceid').data("kendoComboBox").enable(true);
}