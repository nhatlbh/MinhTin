var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none', 'btnAdd': 'none' },
    gridColumnDisplay: { product: false, amount: false, vat: true, price: true, total: true },
    changed: detailChanged,
    priceEditable: true,
};
var guarRetDetail = (function (guarRetDetail) {
    return guarRetDetail;
}(invoiceDetail));
// Generated Initiate List Script

var devGuarReturnList = (function (guarreturnList) {
    cloneGuarReturn = Object.create(guarreturnList);
    return cloneGuarReturn;
})(guarreturnList);

var sessionKey;
$(document).ready(function () {
    sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Tình\Thành phố';
    devGuarReturnList.initSearchControl();
    devGuarReturnList.showGrid();
    $('#btnSearch').click(function () {
        devGuarReturnList.search();
    });
    $('#btnAdd').click(function () {
        devGuarReturnList.openForm();
        guarRetDetail.clearForm();
        enableForm();
    });
    if (devGuarReturnList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devGuarReturnList.getGrid(), function (dataItem) {
            var formId = devGuarReturnList.getFormId();
            devGuarReturnList.openForm(formId);
            guarRetDetail.bindGrid("GuarReturnOvr/GetDetail?guarReturnId=" + formId);
            disableForm();
        });
    guarRetDetail.init(invDetailSetting);
    disableControlArr([$('#dedCreatedate'), $('#btnDelete'), $('#txtCode'), $('#txtTotaldebt')])
});

// Generated Initiate Form Script

var devGuarReturnForm = (function (guarreturnForm) {
    cloneGuarReturn = Object.create(guarreturnForm);
    return cloneGuarReturn;
})(guarreturnForm);


$(document).ready(function () {
    devGuarReturnForm.initFormControl({ 'guaranteeChanged': guaranteeChanged, 'customerChanged': customerChanged });
    $('#btnSave').click(function () { save(); });
    $('#btnDelete').click(function () { devGuarReturnForm.del(guarreturnList.closeForm); });
    $('#btnNew').click(function () { devGuarReturnForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { save(guarreturnList.closeForm); });
    $('#btnClose').click(function () { guarreturnList.closeForm(); });

});
function guaranteeChanged(e) {
    callService('BuyGuarantee/GetByID?id=' + this.value(), function (data) {
        data = JSON.parse(data);
        var ddlSupplier = $('#ddlCustomerid').data("kendoComboBox");
        if (data.length > 0)
            ddlSupplier.value(data[0].CustomerID);
    });
    guarRetDetail.bindGrid('BuyGuaranteeOvr/GetDetail?guaranteeId=' + this.value(), [detailChanged, ], true);
}
function customerChanged(e) {
    var guarFilter = this.value() && this.value() != '' ? 'CustomerID=' + this.value() : '';
    callService('BuyGuarantee/GetComboboxData?sessionKey=' + sessionKey + '&cond=' + guarFilter, loadCombobox, ['ddlGuaranteeid', guaranteeChanged]);
}
function save(ftnAfterSave) {
    var guarReturnDTO = devGuarReturnForm.buildDTO();
    var guarReturnDetails = [];
    $.each(guarRetDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        guarReturnDetails.push(detailDTO);
    });
    if (validForm(guarReturnDetails))
        callService('GuarReturnOvr/Save?guarReturnJson=' + JSON.stringify(guarReturnDTO) + '&guarReturnDetailsJson=' + JSON.stringify(guarReturnDetails),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devGuarReturnForm.setFormId(result);
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
function detailChanged() {

}
function disableForm() {
    disableControlArr([$('#txtDescription'), $('#txtOrdernum'),
                       $('#txtTotaldebt'), $('#dedCreatedate'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlGuaranteeid').data("kendoComboBox").enable(false);
    $('#ddlCustomerid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlGuaranteeid').data("kendoComboBox").enable(true);
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