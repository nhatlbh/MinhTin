
var invDetailSetting = {
    formArea: { 'price': 'none', 'vat': 'none', 'inventory': 'block' },
    gridColumnDisplay: { product: false, amount: false, vat: true, price: true, total: true },
    changed: detailChanged,
};
var storeExportDetail = (function (storeExportDetail) {
    return storeExportDetail;
}(invoiceDetail));

// Generated Initiate List Script

    var devStoExportList = (function (stoexportList) {
        cloneStoExport = Object.create(stoexportList);
        return cloneStoExport;
    })(stoexportList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Phiếu xuất kho';
        devStoExportList.initSearchControl();
        devStoExportList.showGrid();
        $('#btnSearch').click(function () {
            devStoExportList.search();
        });
        $('#btnAdd').click(function () {
            devStoExportList.openForm();
            storeExportDetail.clearForm(invDetailSetting);
            enableForm();
        });
        storeExportDetail.init(invDetailSetting);
        if (devStoExportList.getGrid())
            kendoHelpers.grid.eventRowDoubleClick(devStoExportList.getGrid(), function (dataItem) {
                var formId = devStoExportList.getFormId();
                devStoExportList.openForm(formId);
                storeExportDetail.bindGrid("StoExportOvr/GetDetail?exportId=" + formId);
                disableForm();
            });
        disableControlArr([$('#dedCreatedate'), $('#txtCode'), $('#btnDelete')]);
    });

// Generated Initiate Form Script

    var devStoExportForm = (function (stoexportForm) {
        cloneStoExport = Object.create(stoexportForm);
        return cloneStoExport;
    })(stoexportForm);


    $(document).ready(function () {
        var formSetting = { 'storeChanged': storeChanged };
        devStoExportForm.initFormControl(formSetting);
        $('#btnSave').click(function () { saveStoreExport(); });
        $('#btnDelete').click(function () { devStoExportForm.del(stoexportList.closeForm); });
        $('#btnNew').click(function () { devStoExportForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { saveStoreExport(stoexportList.closeForm); });
        $('#btnClose').click(function () { stoexportList.closeForm(); });

    });
    function saveStoreExport(ftnAfterSave) {
        var exportDTO = devStoExportForm.buildDTO();
        var exportDetails = [];
        $.each(storeExportDetail.getDetail(), function (idx, val) {
            var detailDTO = {
                'ProductID': val.ProductID,
                'Quantity': val.Quantity,
                'VAT': val.VAT,
                'Price': val.Price,
                'OrderNum': idx,
            };
            exportDetails.push(detailDTO);
        });
        if (validForm(exportDetails)) {
            callService('StoExportOvr/Save?exportJson=' + JSON.stringify(exportDTO) + '&exportDetailsJson=' + JSON.stringify(exportDetails),
            function (result) {
                if (result.indexOf("Lỗi:") == -1) {
                    devStoExportForm.setFormId(result);
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
    function storeChanged() {
        storeId = $('#ddlStoreid').data('kendoComboBox').value();
        if (storeId && storeId > 0) {
            storeExportDetail.setStore(storeId);
        }
        else {
            storeExportDetail.setStore(0);
        }
    }
    function detailChanged() {

    }
    function disableForm() {
        disableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
        $('#ddlStoreid').data("kendoComboBox").enable(false);
    }
    function enableForm() {
        enableControlArr([$('#txtDescription'), $('#txtOrdernum'), $('#btnSave'), $('#btnSaveAndClose'), ]);
        $('#ddlStoreid').data("kendoComboBox").enable(true);
    }

    function validForm(detailArr) {
        if (!devStoExportForm.validate()) {
            return false;
        }
        if (detailArr.length <= 0) {
            msgBox.alert("Chưa chọn sản phẩm xuất kho.");
            return false;
        }
        return true;
    }