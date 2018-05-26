
// Generated Initiate List Script

    var devCatManufactureList = (function (catmanufactureList) {
        cloneCatManufacture = Object.create(catmanufactureList);
        return cloneCatManufacture;
    })(catmanufactureList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhà sản xuất';
        devCatManufactureList.initSearchControl();
        devCatManufactureList.showGrid();
        $('#btnSearch').click(function () {
            devCatManufactureList.search();
        });
        $('#btnAdd').click(function () {
            devCatManufactureList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatManufactureForm = (function (catmanufactureForm) {
        cloneCatManufacture = Object.create(catmanufactureForm);
        return cloneCatManufacture;
    })(catmanufactureForm);


    $(document).ready(function () {
        devCatManufactureForm.initFormControl();
        $('#btnSave').click(function () { devCatManufactureForm.save(); });
        $('#btnDelete').click(function () { devCatManufactureForm.del(catmanufactureList.closeForm); });
        $('#btnNew').click(function () { devCatManufactureForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatManufactureForm.save(catmanufactureList.closeForm); });
        $('#btnClose').click(function () { catmanufactureList.closeForm(); });

    });
