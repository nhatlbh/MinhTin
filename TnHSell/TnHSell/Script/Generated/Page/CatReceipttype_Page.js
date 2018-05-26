
// Generated Initiate List Script

    var devCatReceipttypeList = (function (catreceipttypeList) {
        cloneCatReceipttype = Object.create(catreceipttypeList);
        return cloneCatReceipttype;
    })(catreceipttypeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Loại thu';
        devCatReceipttypeList.initSearchControl();
        devCatReceipttypeList.showGrid();
        $('#btnSearch').click(function () {
            devCatReceipttypeList.search();
        });
        $('#btnAdd').click(function () {
            devCatReceipttypeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatReceipttypeForm = (function (catreceipttypeForm) {
        cloneCatReceipttype = Object.create(catreceipttypeForm);
        return cloneCatReceipttype;
    })(catreceipttypeForm);


    $(document).ready(function () {
        devCatReceipttypeForm.initFormControl();
        $('#btnSave').click(function () { devCatReceipttypeForm.save(); });
        $('#btnDelete').click(function () { devCatReceipttypeForm.del(catreceipttypeList.closeForm); });
        $('#btnNew').click(function () { devCatReceipttypeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatReceipttypeForm.save(catreceipttypeList.closeForm); });
        $('#btnClose').click(function () { catreceipttypeList.closeForm(); });

    });
