
// Generated Initiate List Script

    var devCatProducttypeList = (function (catproducttypeList) {
        cloneCatProducttype = Object.create(catproducttypeList);
        return cloneCatProducttype;
    })(catproducttypeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Loại sản phẩm';
        devCatProducttypeList.initSearchControl();
        devCatProducttypeList.showGrid();
        $('#btnSearch').click(function () {
            devCatProducttypeList.search();
        });
        $('#btnAdd').click(function () {
            devCatProducttypeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProducttypeForm = (function (catproducttypeForm) {
        cloneCatProducttype = Object.create(catproducttypeForm);
        return cloneCatProducttype;
    })(catproducttypeForm);


    $(document).ready(function () {
        devCatProducttypeForm.initFormControl();
        $('#btnSave').click(function () { devCatProducttypeForm.save(); });
        $('#btnDelete').click(function () { devCatProducttypeForm.del(catproducttypeList.closeForm); });
        $('#btnNew').click(function () { devCatProducttypeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProducttypeForm.save(catproducttypeList.closeForm); });
        $('#btnClose').click(function () { catproducttypeList.closeForm(); });

    });
