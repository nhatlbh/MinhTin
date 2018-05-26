
// Generated Initiate List Script

    var devCatProductPriceList = (function (catproductpriceList) {
        cloneCatProductPrice = Object.create(catproductpriceList);
        return cloneCatProductPrice;
    })(catproductpriceList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devCatProductPriceList.initSearchControl();
        devCatProductPriceList.showGrid();
        $('#btnSearch').click(function () {
            devCatProductPriceList.search();
        });
        $('#btnAdd').click(function () {
            devCatProductPriceList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProductPriceForm = (function (catproductpriceForm) {
        cloneCatProductPrice = Object.create(catproductpriceForm);
        return cloneCatProductPrice;
    })(catproductpriceForm);


    $(document).ready(function () {
        devCatProductPriceForm.initFormControl();
        $('#btnSave').click(function () { devCatProductPriceForm.save(); });
        $('#btnDelete').click(function () { devCatProductPriceForm.del(catproductpriceList.closeForm); });
        $('#btnNew').click(function () { devCatProductPriceForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProductPriceForm.save(catproductpriceList.closeForm); });
        $('#btnClose').click(function () { catproductpriceList.closeForm(); });

    });
