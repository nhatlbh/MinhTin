
// Generated Initiate List Script

    var devAdmServiceList = (function (admserviceList) {
        cloneAdmService = Object.create(admserviceList);
        return cloneAdmService;
    })(admserviceList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devAdmServiceList.initSearchControl();
        devAdmServiceList.showGrid();
        $('#btnSearch').click(function () {
            devAdmServiceList.search();
        });
        $('#btnAdd').click(function () {
            devAdmServiceList.openForm();
        });
    });

// Generated Initiate Form Script

    var devAdmServiceForm = (function (admserviceForm) {
        cloneAdmService = Object.create(admserviceForm);
        return cloneAdmService;
    })(admserviceForm);


    $(document).ready(function () {
        devAdmServiceForm.initFormControl();
        $('#btnSave').click(function () { devAdmServiceForm.save(); });
        $('#btnDelete').click(function () { devAdmServiceForm.del(admserviceList.closeForm); });
        $('#btnNew').click(function () { devAdmServiceForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devAdmServiceForm.save(admserviceList.closeForm); });
        $('#btnClose').click(function () { admserviceList.closeForm(); });

    });
