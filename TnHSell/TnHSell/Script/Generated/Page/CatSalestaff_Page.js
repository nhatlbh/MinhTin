
// Generated Initiate List Script

    var devCatSalestaffList = (function (catsalestaffList) {
        cloneCatSalestaff = Object.create(catsalestaffList);
        return cloneCatSalestaff;
    })(catsalestaffList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhân viên Sale';
        devCatSalestaffList.initSearchControl();
        devCatSalestaffList.showGrid();
        $('#btnSearch').click(function () {
            devCatSalestaffList.search();
        });
        $('#btnAdd').click(function () {
            devCatSalestaffList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatSalestaffForm = (function (catsalestaffForm) {
        cloneCatSalestaff = Object.create(catsalestaffForm);
        return cloneCatSalestaff;
    })(catsalestaffForm);


    $(document).ready(function () {
        devCatSalestaffForm.initFormControl();
        $('#btnSave').click(function () { devCatSalestaffForm.save(); });
        $('#btnDelete').click(function () { devCatSalestaffForm.del(catsalestaffList.closeForm); });
        $('#btnNew').click(function () { devCatSalestaffForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatSalestaffForm.save(catsalestaffList.closeForm); });
        $('#btnClose').click(function () { catsalestaffList.closeForm(); });

    });
