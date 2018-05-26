
// Generated Initiate List Script

    var devCatProductList = (function (catproductList) {
        cloneCatProduct = Object.create(catproductList);
        return cloneCatProduct;
    })(catproductList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Sản phẩm';
        devCatProductList.initSearchControl();
        devCatProductList.showGrid();
        $('#btnSearch').click(function () {
            devCatProductList.search();
        });
        $('#btnAdd').click(function () {
            devCatProductList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProductForm = (function (catproductForm) {
        cloneCatProduct = Object.create(catproductForm);
        return cloneCatProduct;
    })(catproductForm);


    $(document).ready(function () {
        devCatProductForm.initFormControl();
        $('#btnSave').click(function () { devCatProductForm.save(); });
        $('#btnDelete').click(function () { devCatProductForm.del(catproductList.closeForm); });
        $('#btnNew').click(function () { devCatProductForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProductForm.save(catproductList.closeForm); });
        $('#btnClose').click(function () { catproductList.closeForm(); });

    });
