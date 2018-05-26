
// Generated Initiate List Script

    var devCatSupplierList = (function (catsupplierList) {
        cloneCatSupplier = Object.create(catsupplierList);
        return cloneCatSupplier;
    })(catsupplierList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhà cung cấp';
        devCatSupplierList.initSearchControl();
        devCatSupplierList.showGrid();
        $('#btnSearch').click(function () {
            devCatSupplierList.search();
        });
        $('#btnAdd').click(function () {
            devCatSupplierList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatSupplierForm = (function (catsupplierForm) {
        cloneCatSupplier = Object.create(catsupplierForm);
        return cloneCatSupplier;
    })(catsupplierForm);


    $(document).ready(function () {
        devCatSupplierForm.initFormControl();
        $('#btnSave').click(function () { devCatSupplierForm.save(); });
        $('#btnDelete').click(function () { devCatSupplierForm.del(catsupplierList.closeForm); });
        $('#btnNew').click(function () { devCatSupplierForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatSupplierForm.save(catsupplierList.closeForm); });
        $('#btnClose').click(function () { catsupplierList.closeForm(); });

    });
