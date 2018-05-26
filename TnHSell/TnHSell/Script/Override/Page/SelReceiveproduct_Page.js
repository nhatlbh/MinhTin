
var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none', 'btnAdd': 'none' },
    gridColumnDisplay: { product: false, amount: false, vat: false, price: false, total: false },
    changed: detailChanged,
    priceEditable: false,
};
var recvProductDetail = (function (recvProductDetail) {
    return recvProductDetail;
}(invoiceDetail));

// Generated Initiate List Script

var devSelReceiveproductList = (function (selreceiveproductList) {
    cloneSelReceiveproduct = Object.create(selreceiveproductList);
    return cloneSelReceiveproduct;
})(selreceiveproductList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu nhận hàng trả';
    devSelReceiveproductList.initSearchControl();
    devSelReceiveproductList.showGrid();
    $('#btnSearch').click(function () {
        devSelReceiveproductList.search();
    });
    $('#btnAdd').click(function () {
        devSelReceiveproductList.openForm();
        recvProductDetail.clearForm();
        enableForm();
    });
    if (devSelReceiveproductList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devSelReceiveproductList.getGrid(), function (dataItem) {
            var formId = devSelReceiveproductList.getFormId();
            devSelReceiveproductList.openForm(formId);
            recvProductDetail.bindGrid("SelReceiveproductOvr/GetDetail?recvProductId=" + formId);
            disableForm();
        });
    recvProductDetail.init(invDetailSetting);
    disableControlArr([$('#dedCreatedate'), $('#btnDelete'), $('#txtCode'), $('#txtTotal')])
});

// Generated Initiate Form Script

var devSelReceiveproductForm = (function (selreceiveproductForm) {
    cloneSelReceiveproduct = Object.create(selreceiveproductForm);
    return cloneSelReceiveproduct;
})(selreceiveproductForm);


$(document).ready(function () {
    devSelReceiveproductForm.initFormControl({ 'sellInvChanged': sellInvChanged, });
    $('#btnSave').click(function () { saveRecvProduct(); });
    $('#btnDelete').click(function () { devSelReceiveproductForm.del(selreceiveproductList.closeForm); });
    $('#btnNew').click(function () { devSelReceiveproductForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { saveRecvProduct(selreceiveproductList.closeForm); });
    $('#btnClose').click(function () { selreceiveproductList.closeForm(); });

});

function sellInvChanged(e) {
    callService('SelInvoice/GetByID?id=' + this.value(), function (data) {
        data = JSON.parse(data);
        var ddlSupplier = $('#ddlCustomerid').data("kendoComboBox");
        if (data.length > 0)
            ddlSupplier.value(data[0].CustomerID);
    });
    recvProductDetail.bindGrid('SelInvoiceOvr/GetDetail?invoiceId=' + this.value(), [detailChanged, ], true);
}

function saveRecvProduct(ftnAfterSave) {
    var recvProductDTO = devSelReceiveproductForm.buildDTO();
    var recvProductDetails = [];
    $.each(recvProductDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        recvProductDetails.push(detailDTO);
    });
    if (validForm()) {
        callService('SelReceiveproductOvr/Save?recvProductJson=' + JSON.stringify(recvProductDTO) + '&recvProductDetailsJson=' + JSON.stringify(recvProductDetails),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devBuyImportinvoiceForm.setFormId(result);
                if (ftnAfterSave) {
                    ftnAfterSave(result);
                }
            }
            else
                alert(result);
            if (ftnAfterSave)
                ftnAfterSave();
        });
    }
}
function detailChanged() {
    var total = 0;
    $.each(recvProductDetail.getDetail(), function (idx, val) {
        total += val.Quantity * val.Price;
    })
    $('#txtTotal').val(numberFormat(total));
}
function disableForm() {
    disableControlArr([$('#txtDescription'), $('#txtOrdernum'),
                       $('#txtTotaldebt'), $('#dedCreatedate'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlInvoiceid').data("kendoComboBox").enable(false);
    $('#ddlCustomerid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'),$('#txtTotaldebt'), ]);
    $('#ddlInvoiceid').data("kendoComboBox").enable(true);
}
function validForm() {
    if (!devSelReceiveproductForm.validate()) {
        alert("Vui lòng điền đầy đủ thông tin vào các ô có dấu '*'.");
        return false;
    }
    return true;
}
