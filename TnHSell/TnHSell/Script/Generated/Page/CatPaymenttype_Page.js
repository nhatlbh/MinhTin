
// Generated Initiate List Script

    var devCatPaymenttypeList = (function (catpaymenttypeList) {
        cloneCatPaymenttype = Object.create(catpaymenttypeList);
        return cloneCatPaymenttype;
    })(catpaymenttypeList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Loại chi';
        devCatPaymenttypeList.initSearchControl();
        devCatPaymenttypeList.showGrid();
        $('#btnSearch').click(function () {
            devCatPaymenttypeList.search();
        });
        $('#btnAdd').click(function () {
            devCatPaymenttypeList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatPaymenttypeForm = (function (catpaymenttypeForm) {
        cloneCatPaymenttype = Object.create(catpaymenttypeForm);
        return cloneCatPaymenttype;
    })(catpaymenttypeForm);


    $(document).ready(function () {
        devCatPaymenttypeForm.initFormControl();
        $('#btnSave').click(function () { devCatPaymenttypeForm.save(); });
        $('#btnDelete').click(function () { devCatPaymenttypeForm.del(catpaymenttypeList.closeForm); });
        $('#btnNew').click(function () { devCatPaymenttypeForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatPaymenttypeForm.save(catpaymenttypeList.closeForm); });
        $('#btnClose').click(function () { catpaymenttypeList.closeForm(); });

    });
