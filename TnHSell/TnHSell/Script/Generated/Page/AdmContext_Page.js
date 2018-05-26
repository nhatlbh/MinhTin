
// Generated Initiate List Script

    var devAdmContextList = (function (admcontextList) {
        cloneAdmContext = Object.create(admcontextList);
        return cloneAdmContext;
    })(admcontextList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devAdmContextList.initSearchControl();
        devAdmContextList.showGrid();
        $('#btnSearch').click(function () {
            devAdmContextList.search();
        });
        $('#btnAdd').click(function () {
            devAdmContextList.openForm();
        });
    });

// Generated Initiate Form Script

    var devAdmContextForm = (function (admcontextForm) {
        cloneAdmContext = Object.create(admcontextForm);
        return cloneAdmContext;
    })(admcontextForm);


    $(document).ready(function () {
        devAdmContextForm.initFormControl();
        $('#btnSave').click(function () { devAdmContextForm.save(); });
        $('#btnDelete').click(function () { devAdmContextForm.del(admcontextList.closeForm); });
        $('#btnNew').click(function () { devAdmContextForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devAdmContextForm.save(admcontextList.closeForm); });
        $('#btnClose').click(function () { admcontextList.closeForm(); });

    });
