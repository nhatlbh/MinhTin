
// Generated Initiate List Script

    var devCatCustomerList = (function (catcustomerList) {
        cloneCatCustomer = Object.create(catcustomerList);
        return cloneCatCustomer;
    })(catcustomerList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Khách hàng';
        devCatCustomerList.initSearchControl();
        devCatCustomerList.showGrid();
        $('#btnSearch').click(function () {
            devCatCustomerList.search();
        });
        $('#btnAdd').click(function () {
            devCatCustomerList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatCustomerForm = (function (catcustomerForm) {
        cloneCatCustomer = Object.create(catcustomerForm);
        return cloneCatCustomer;
    })(catcustomerForm);


    $(document).ready(function () {
        devCatCustomerForm.initFormControl();
        $('#btnSave').click(function () { devCatCustomerForm.save(); });
        $('#btnDelete').click(function () { devCatCustomerForm.del(catcustomerList.closeForm); });
        $('#btnNew').click(function () { devCatCustomerForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatCustomerForm.save(catcustomerList.closeForm); });
        $('#btnClose').click(function () { catcustomerList.closeForm(); });

    });
