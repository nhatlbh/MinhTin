
// Generated Initiate List Script

    var devCatStoreList = (function (catstoreList) {
        cloneCatStore = Object.create(catstoreList);
        return cloneCatStore;
    })(catstoreList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Kho';
        devCatStoreList.initSearchControl();
        devCatStoreList.showGrid();
        $('#btnSearch').click(function () {
            devCatStoreList.search();
        });
        $('#btnAdd').click(function () {
            devCatStoreList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatStoreForm = (function (catstoreForm) {
        cloneCatStore = Object.create(catstoreForm);
        return cloneCatStore;
    })(catstoreForm);


    $(document).ready(function () {
        devCatStoreForm.initFormControl();
        $('#btnSave').click(function () { devCatStoreForm.save(); });
        $('#btnDelete').click(function () { devCatStoreForm.del(catstoreList.closeForm); });
        $('#btnNew').click(function () { devCatStoreForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatStoreForm.save(catstoreList.closeForm); });
        $('#btnClose').click(function () { catstoreList.closeForm(); });

    });
