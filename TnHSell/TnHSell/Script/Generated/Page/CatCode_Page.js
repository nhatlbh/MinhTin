
// Generated Initiate List Script

    var devCatCodeList = (function (catcodeList) {
        cloneCatCode = Object.create(catcodeList);
        return cloneCatCode;
    })(catcodeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'DM mã phiếu';
        devCatCodeList.initSearchControl();
        devCatCodeList.showGrid();
        $('#btnSearch').click(function () {
            devCatCodeList.search();
        });
        $('#btnAdd').click(function () {
            devCatCodeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatCodeForm = (function (catcodeForm) {
        cloneCatCode = Object.create(catcodeForm);
        return cloneCatCode;
    })(catcodeForm);


    $(document).ready(function () {
        devCatCodeForm.initFormControl();
        $('#btnSave').click(function () { devCatCodeForm.save(); });
        $('#btnDelete').click(function () { devCatCodeForm.del(catcodeList.closeForm); });
        $('#btnNew').click(function () { devCatCodeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatCodeForm.save(catcodeList.closeForm); });
        $('#btnClose').click(function () { catcodeList.closeForm(); });

    });
