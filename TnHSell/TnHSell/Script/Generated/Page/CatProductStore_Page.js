
// Generated Initiate List Script

    var devCatProductStoreList = (function (catproductstoreList) {
        cloneCatProductStore = Object.create(catproductstoreList);
        return cloneCatProductStore;
    })(catproductstoreList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devCatProductStoreList.initSearchControl();
        devCatProductStoreList.showGrid();
        $('#btnSearch').click(function () {
            devCatProductStoreList.search();
        });
        $('#btnAdd').click(function () {
            devCatProductStoreList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProductStoreForm = (function (catproductstoreForm) {
        cloneCatProductStore = Object.create(catproductstoreForm);
        return cloneCatProductStore;
    })(catproductstoreForm);


    $(document).ready(function () {
        devCatProductStoreForm.initFormControl();
        $('#btnSave').click(function () { devCatProductStoreForm.save(); });
        $('#btnDelete').click(function () { devCatProductStoreForm.del(catproductstoreList.closeForm); });
        $('#btnNew').click(function () { devCatProductStoreForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProductStoreForm.save(catproductstoreList.closeForm); });
        $('#btnClose').click(function () { catproductstoreList.closeForm(); });

    });
