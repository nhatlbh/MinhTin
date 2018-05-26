var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none', 'inventory': 'block' },
    gridColumnDisplay: { product: false, amount: false, vat: true, price: true, total: true },
    changed: detailChanged,
};
var storeExchangeDetail = (function (storeExchangeDetail) {
    return storeExchangeDetail;
}(invoiceDetail));
// Generated Initiate List Script

var devStoExchangeList = (function (stoexchangeList) {
    cloneStoExchange = Object.create(stoexchangeList);
    return cloneStoExchange;
})(stoexchangeList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu chuyển kho';
    devStoExchangeList.initSearchControl();
    devStoExchangeList.showGrid();
    $('#btnSearch').click(function () {
        devStoExchangeList.search();
    });
    $('#btnAdd').click(function () {
        devStoExchangeList.openForm();
        storeExchangeDetail.clearForm(invDetailSetting);
        enableForm();
    });
    storeExchangeDetail.init(invDetailSetting);
    if (devStoExchangeList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devStoExchangeList.getGrid(), function (dataItem) {
            var formId = devStoExchangeList.getFormId();
            devStoExchangeList.openForm(formId);
            storeExchangeDetail.bindGrid("StoExchangeOvr/GetDetail?exchangeId=" + formId);
            disableForm();
        });
    disableControlArr([$('#dedCreatedate'), $('#txtCode'), $('#btnDelete')]);
});

// Generated Initiate Form Script

var devStoExchangeForm = (function (stoexchangeForm) {
    cloneStoExchange = Object.create(stoexchangeForm);
    return cloneStoExchange;
})(stoexchangeForm);


$(document).ready(function () {
    var formSetting = { 'fromStoreChanged': fromStoreChanged ,}
    devStoExchangeForm.initFormControl(formSetting);
    $('#btnSave').click(function () { saveStoreExchange(); });
    $('#btnDelete').click(function () { devStoExchangeForm.del(stoexchangeList.closeForm); });
    $('#btnNew').click(function () { devStoExchangeForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { saveStoreExchange(stoexchangeList.closeForm); });
    $('#btnClose').click(function () { stoexchangeList.closeForm(); });

});
function saveStoreExchange(ftnAfterSave) {
    var exchangeDTO = devStoExchangeForm.buildDTO();
    var exchangeDetails = [];
    $.each(storeExchangeDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        exchangeDetails.push(detailDTO);
    });
    if (validForm(exchangeDetails)) {
        callService('StoExchangeOvr/Save?exchangeJson=' + JSON.stringify(exchangeDTO) + '&exchangeDetailsJson=' + JSON.stringify(exchangeDetails),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devStoExchangeForm.setFormId(result);
                if (ftnAfterSave) {
                    ftnAfterSave(result);
                }
                //callService("AdmUserOvr/GetRoleList?userId=" + result, grdRole_User.setSelectedRows, grdRole_User.grid);
            }
            else
                msgBox.alert(result);
            if (ftnAfterSave)
                ftnAfterSave();
        });
    }
}
function fromStoreChanged() {
    storeId = $('#ddlFromstoreid').data('kendoComboBox').value();
    if (storeId && storeId > 0) {
        storeExchangeDetail.setStore(storeId);
    }
    else {
        storeExchangeDetail.setStore(0);
    }
}
function detailChanged() {

}
function disableForm() {
    disableControlArr([$('#txtDescription'), $('#txtOrdernum'),
                       $('#dedCreatedate'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlFromstoreid').data("kendoComboBox").enable(false);
    $('#ddlTostoreid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
    $('#ddlFromstoreid').data("kendoComboBox").enable(true);
    $('#ddlTostoreid').data("kendoComboBox").enable(true);
}

function validForm(detailArr) {
    if (!devStoExchangeForm.validate()) {
        return false;
    }
    if (detailArr.length <= 0) {
        msgBox.alert("Chưa chọn sản phẩm chuyển kho.");
        return false;
    }
    return true;
}