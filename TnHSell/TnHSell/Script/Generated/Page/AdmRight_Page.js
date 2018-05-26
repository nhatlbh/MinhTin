
// Generated Initiate List Script

    var devAdmRightList = (function (admrightList) {
        cloneAdmRight = Object.create(admrightList);
        return cloneAdmRight;
    })(admrightList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devAdmRightList.initSearchControl();
        devAdmRightList.showGrid();
        $('#btnSearch').click(function () {
            devAdmRightList.search();
        });
        $('#btnAdd').click(function () {
            devAdmRightList.openForm();
        });
    });

// Generated Initiate Form Script

    var devAdmRightForm = (function (admrightForm) {
        cloneAdmRight = Object.create(admrightForm);
        return cloneAdmRight;
    })(admrightForm);


    $(document).ready(function () {
        devAdmRightForm.initFormControl();
        $('#btnSave').click(function () { devAdmRightForm.save(); });
        $('#btnDelete').click(function () { devAdmRightForm.del(admrightList.closeForm); });
        $('#btnNew').click(function () { devAdmRightForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devAdmRightForm.save(admrightList.closeForm); });
        $('#btnClose').click(function () { admrightList.closeForm(); });

    });
