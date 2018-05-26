
// Generated Initiate List Script

    var devCatGuaranteestatusList = (function (catguaranteestatusList) {
        cloneCatGuaranteestatus = Object.create(catguaranteestatusList);
        return cloneCatGuaranteestatus;
    })(catguaranteestatusList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Trạng thái bảo hành';
        devCatGuaranteestatusList.initSearchControl();
        devCatGuaranteestatusList.showGrid();
        $('#btnSearch').click(function () {
            devCatGuaranteestatusList.search();
        });
        $('#btnAdd').click(function () {
            devCatGuaranteestatusList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatGuaranteestatusForm = (function (catguaranteestatusForm) {
        cloneCatGuaranteestatus = Object.create(catguaranteestatusForm);
        return cloneCatGuaranteestatus;
    })(catguaranteestatusForm);


    $(document).ready(function () {
        devCatGuaranteestatusForm.initFormControl();
        $('#btnSave').click(function () { devCatGuaranteestatusForm.save(); });
        $('#btnDelete').click(function () { devCatGuaranteestatusForm.del(catguaranteestatusList.closeForm); });
        $('#btnNew').click(function () { devCatGuaranteestatusForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatGuaranteestatusForm.save(catguaranteestatusList.closeForm); });
        $('#btnClose').click(function () { catguaranteestatusList.closeForm(); });

    });
