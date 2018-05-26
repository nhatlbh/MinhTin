
// Generated Initiate List Script

    var devAdmMapList = (function (admmapList) {
        cloneAdmMap = Object.create(admmapList);
        return cloneAdmMap;
    })(admmapList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devAdmMapList.initSearchControl();
        devAdmMapList.showGrid();
        $('#btnSearch').click(function () {
            devAdmMapList.search();
        });
        $('#btnAdd').click(function () {
            devAdmMapList.openForm();
        });
    });

// Generated Initiate Form Script

    var devAdmMapForm = (function (admmapForm) {
        cloneAdmMap = Object.create(admmapForm);
        return cloneAdmMap;
    })(admmapForm);


    $(document).ready(function () {
        devAdmMapForm.initFormControl();
        $('#btnSave').click(function () { devAdmMapForm.save(); });
        $('#btnDelete').click(function () { devAdmMapForm.del(admmapList.closeForm); });
        $('#btnNew').click(function () { devAdmMapForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devAdmMapForm.save(admmapList.closeForm); });
        $('#btnClose').click(function () { admmapList.closeForm(); });

    });
