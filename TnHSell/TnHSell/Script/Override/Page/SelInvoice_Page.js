var invDetailSetting = {
    formArea: { 'price': 'block', 'vat': 'block', 'inventory': 'block' },
    gridColumnDisplay: { product: false, amount: false, vat: false, price: false, total: false },
    changed: detailChanged,
};
var sellInvDetail = (function (sellInvDetail) {
    return sellInvDetail;
}(invoiceDetail));

// Generated Initiate List Script

var devSelInvoiceList = (function (selinvoiceList) {
    cloneSelInvoice = Object.create(selinvoiceList);
    return cloneSelInvoice;
})(selinvoiceList);


$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Phiếu bán hàng';
    devSelInvoiceList.initSearchControl();
    devSelInvoiceList.showGrid();
    $('#btnSearch').click(function () {
        devSelInvoiceList.search();
    });
    $('#btnAdd').click(function () {
        devSelInvoiceList.openForm();
        sellInvDetail.clearForm();
        enableForm();
        if ($.inArray("4", userInfo.rights) >= 0)
            disableControlArr([$('#txtCode'), $('#txtTotal'), $('#dedCreatedate'), $('#txtTotaldebt')]);
        else
            disableControlArr([$('#txtCode'), $('#txtTotal'), $('#dedCreatedate'), $('#btnDelete'), $('#txtTotaldebt')]);
    });
    sellInvDetail.init(invDetailSetting);
    if (devSelInvoiceList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devSelInvoiceList.getGrid(), function (dataItem) {
            var formId = devSelInvoiceList.getFormId();
            devSelInvoiceList.openForm(formId);
            sellInvDetail.bindGrid("SelInvoiceOvr/GetDetail?invoiceId=" + formId,null, ($.inArray("4", userInfo.rights) >= 0));
            disableForm();
        });
});

// Generated Initiate Form Script

var devSelInvoiceForm = (function (selinvoiceForm) {
    cloneSelInvoice = Object.create(selinvoiceForm);
    return cloneSelInvoice;
})(selinvoiceForm);


$(document).ready(function () {
    formSetting = { 'storeChanged': storeChanged, 'ioCodeChanged': ioCodeChanged, 'customerChanged': customerChanged };
    devSelInvoiceForm.initFormControl(formSetting);
    $('#btnSave').click(function () { saveSellInvoice(); });
    $('#btnDelete').click(function () { del(selinvoiceList.closeForm); });
    $('#btnNew').click(function () { devSelInvoiceForm.refreshInputForm(); sellInvDetail.clearForm(); enableForm(); });
    $('#btnSaveAndClose').click(function () { saveSellInvoice(selinvoiceList.closeForm); });
    $('#btnClose').click(function () { selinvoiceList.closeForm(); });

});
function saveSellInvoice(ftnAfterSave) {
    var sellInvoiceDTO = devSelInvoiceForm.buildDTO();
    var invoiceDetails = [];
    $.each(sellInvDetail.getDetail(), function (idx, val) {
        var detailDTO = {
            'ProductID': val.ProductID,
            'Quantity': val.Quantity,
            'VAT': val.VAT,
            'Price': val.Price,
            'OrderNum': idx,
        };
        invoiceDetails.push(detailDTO);
    });
    if (validForm(invoiceDetails)) {
        callService('SelInvoiceOvr/Save?sellInvoceJson=' + JSON.stringify(sellInvoiceDTO) + '&invoiceDetailsJson=' + JSON.stringify(invoiceDetails),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devSelInvoiceForm.setFormId(result);
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
function del(fnAfterDel) {
    var id = $('#hdfId').val();
    if (id == '' || id == '0') {
        alert('Chưa chọn Phiếu bán hàng cần xóa');
    }
    else if (confirm("Bạn có muốn xóa Phiếu bán hàng này?")) {
        callService('SelInvoiceOvr/Delete?id=' + id, function (data) {
            if (data.indexOf("Lỗi:") > -1) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            }
            else {
                alert(data);
            }
        })
    }
}
function storeChanged() {
    storeId = $('#ddlStoreid').data('kendoComboBox').value();
    if (storeId && storeId > 0) {
        sellInvDetail.setStore(storeId);
    }
    else {
        sellInvDetail.setStore(0);
    }
}

function ioCodeChanged() {
    ioCodeId = $('#ddlIocodeid').data('kendoComboBox').value();
    if (ioCodeId && ioCodeId > 0) {
        sellInvDetail.setIOCode(ioCodeId);
    }
    else {
        sellInvDetail.setIOCode(0);
    }
}

function customerChanged() {
    var customerID = $('#ddlCustomerid').data('kendoComboBox').value();
    callService('CatCustomer/GetByID?id=' + customerID, function (data) {
        data = JSON.parse(data)[0];
        if (data.DiliverAddress.length > 0) {
            $('#txtDeliveryaddress').val(data.DiliverAddress);
        }
        else {
            $('#txtDeliveryaddress').val(data.Address);
        }
    });
}

function detailChanged() {
    var total = 0;
    $.each(sellInvDetail.getDetail(), function (idx, val) {
        total += val.Quantity * val.Price;
    })
    $('#txtTotal').val(numberFormat(total));
    discountChanged();
}


function disableForm() {
    if ($.inArray("4", userInfo.rights) <= 0)
        disableControlArr([$('#txtDeliveryaddress'), $('#txtFinancefilenum'),
                           $('#txtFilenum'), $('#txtReceiptnum'), $('#txtTotal'), $('#btnSaveAndClose'), $('#btnSave'), ]);
    $('#ddlStoreid').data("kendoComboBox").enable(false);
    $('#ddlCustomerid').data("kendoComboBox").enable(false);
    $('#ddlIocodeid').data("kendoComboBox").enable(false);
}
function enableForm() {
    enableControlArr([$('#txtDeliveryaddress'), $('#txtFinancefilenum'),
                       $('#txtFilenum'), $('#txtReceiptnum'), $('#btnSaveAndClose'), $('#btnSave'), ]);
    $('#ddlStoreid').data("kendoComboBox").enable(true);
    $('#ddlCustomerid').data("kendoComboBox").enable(true);
    $('#ddlIocodeid').data("kendoComboBox").enable(true);
}

function validForm(detailArr) {
    if (!devSelInvoiceForm.validate()) {
        return false;
    }
    if (detailArr.length <= 0) {
        msgBox.alert("Chưa chọn sản phẩm bán.");
        return false;
    }
    return true;
}
