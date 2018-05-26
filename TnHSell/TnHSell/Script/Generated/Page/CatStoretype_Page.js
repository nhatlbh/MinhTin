
// Generated Initiate List Script

    var devCatStoretypeList = (function (catstoretypeList) {
        cloneCatStoretype = Object.create(catstoretypeList);
        return cloneCatStoretype;
    })(catstoretypeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Loại kho';
        devCatStoretypeList.initSearchControl();
        devCatStoretypeList.showGrid();
        $('#btnSearch').click(function () {
            devCatStoretypeList.search();
        });
        $('#btnAdd').click(function () {
            devCatStoretypeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatStoretypeForm = (function (catstoretypeForm) {
        cloneCatStoretype = Object.create(catstoretypeForm);
        return cloneCatStoretype;
    })(catstoretypeForm);


    $(document).ready(function () {
        devCatStoretypeForm.initFormControl();
        $('#btnSave').click(function () { devCatStoretypeForm.save(); });
        $('#btnDelete').click(function () { devCatStoretypeForm.del(catstoretypeList.closeForm); });
        $('#btnNew').click(function () { devCatStoretypeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatStoretypeForm.save(catstoretypeList.closeForm); });
        $('#btnClose').click(function () { catstoretypeList.closeForm(); });

    });
