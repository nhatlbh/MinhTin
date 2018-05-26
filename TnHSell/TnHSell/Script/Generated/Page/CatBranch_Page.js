
// Generated Initiate List Script

    var devCatBranchList = (function (catbranchList) {
        cloneCatBranch = Object.create(catbranchList);
        return cloneCatBranch;
    })(catbranchList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = '';
        devCatBranchList.initSearchControl();
        devCatBranchList.showGrid();
        $('#btnSearch').click(function () {
            devCatBranchList.search();
        });
        $('#btnAdd').click(function () {
            devCatBranchList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatBranchForm = (function (catbranchForm) {
        cloneCatBranch = Object.create(catbranchForm);
        return cloneCatBranch;
    })(catbranchForm);


    $(document).ready(function () {
        devCatBranchForm.initFormControl();
        $('#btnSave').click(function () { devCatBranchForm.save(); });
        $('#btnDelete').click(function () { devCatBranchForm.del(catbranchList.closeForm); });
        $('#btnNew').click(function () { devCatBranchForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatBranchForm.save(catbranchList.closeForm); });
        $('#btnClose').click(function () { catbranchList.closeForm(); });

    });
