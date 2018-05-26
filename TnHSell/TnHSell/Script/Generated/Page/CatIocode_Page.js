
// Generated Initiate List Script

    var devCatIocodeList = (function (catiocodeList) {
        cloneCatIocode = Object.create(catiocodeList);
        return cloneCatIocode;
    })(catiocodeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Mã nhập xuất';
        devCatIocodeList.initSearchControl();
        devCatIocodeList.showGrid();
        $('#btnSearch').click(function () {
            devCatIocodeList.search();
        });
        $('#btnAdd').click(function () {
            devCatIocodeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatIocodeForm = (function (catiocodeForm) {
        cloneCatIocode = Object.create(catiocodeForm);
        return cloneCatIocode;
    })(catiocodeForm);


    $(document).ready(function () {
        devCatIocodeForm.initFormControl();
        $('#btnSave').click(function () { devCatIocodeForm.save(); });
        $('#btnDelete').click(function () { devCatIocodeForm.del(catiocodeList.closeForm); });
        $('#btnNew').click(function () { devCatIocodeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatIocodeForm.save(catiocodeList.closeForm); });
        $('#btnClose').click(function () { catiocodeList.closeForm(); });

    });
