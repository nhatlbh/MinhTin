var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none' },
    gridColumnDisplay: { product: false, amount: false, vat: true, price: true, total: true },
    priceEditable: true,
};
var guarProductDetail = (function (guarProductDetail) {
    return guarProductDetail;
}(invoiceDetail));
// Generated Initiate List Script

var devBuyGuaranteeList = (function (buyguaranteeList) {
    cloneBuyGuarantee = Object.create(buyguaranteeList);
    return cloneBuyGuarantee;
})(buyguaranteeList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu bảo hành';
    devBuyGuaranteeList.initSearchControl();
    devBuyGuaranteeList.showGrid();
    $('#btnSearch').click(function () {
        devBuyGuaranteeList.search();
    });
    $('#btnAdd').click(function () {
        devBuyGuaranteeList.openForm();
        guarProductDetail.clearForm();
        enableForm();
    });
    if (devBuyGuaranteeList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devBuyGuaranteeList.getGrid(), function (dataItem) {
            var formId = devBuyGuaranteeList.getFormId();
            devBuyGuaranteeList.openForm(formId);
            guarProductDetail.bindGrid("BuyGuaranteeOvr/GetDetail?guaranteeId=" + formId,[],true);
            disableForm();
        });
    guarProductDetail.init(invDetailSetting);
    disableControlArr([$('#dedReceivedate'), $('#btnDelete'), $('#txtCode')])
});

// Generated Initiate Form Script

var devBuyGuaranteeForm = (function (buyguaranteeForm) {
    cloneBuyGuarantee = Object.create(buyguaranteeForm);
    return cloneBuyGuarantee;
})(buyguaranteeForm);


$(document).ready(function () {
    devBuyGuaranteeForm.initFormControl();
    $('#btnSave').click(function () { save(); });
    $('#btnDelete').click(function () { devBuyGuaranteeForm.del(buyguaranteeList.closeForm); });
    $('#btnNew').click(function () { devBuyGuaranteeForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { save(buyguaranteeList.closeForm); });
    $('#btnClose').click(function () { buyguaranteeList.closeForm(); });

});

function save(ftnAfterSave) {
    var guaranteeDTO = devBuyGuaranteeForm.buildDTO();
    var guaranteeDetails = [];
    $.each(guarProductDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        guaranteeDetails.push(detailDTO);
    });
    if (validForm(guaranteeDetails)) {
        callService('BuyGuaranteeOvr/Save?guaranteeJson=' + JSON.stringify(guaranteeDTO) + '&guaranteeDetailsJson=' + JSON.stringify(guaranteeDetails),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devBuyGuaranteeForm.setFormId(result);
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
function disableForm() {
    $('#ddlCustomerid').data("kendoComboBox").enable(false);
    $('#ddlStoreid').data("kendoComboBox").enable(false);
}
function enableForm() {
    $('#ddlCustomerid').data("kendoComboBox").enable(true);
    $('#ddlStoreid').data("kendoComboBox").enable(true);
}
function validForm(detail) {
    if (!devBuyGuaranteeForm.validate()) {
        alert("Vui lòng điền đầy đủ thông tin vào các ô có dấu '*'.");
        return false;
    }
    if (detail && detail.length == 0) {
        alert("Vui lòng nhập sản phẩm bảo hành.")
        return false;
    }
    return true;
}