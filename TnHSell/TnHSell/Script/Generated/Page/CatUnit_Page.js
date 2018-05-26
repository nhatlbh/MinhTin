
// Generated Initiate List Script

    var devCatUnitList = (function (catunitList) {
        cloneCatUnit = Object.create(catunitList);
        return cloneCatUnit;
    })(catunitList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Đơn vị tính';
        devCatUnitList.initSearchControl();
        devCatUnitList.showGrid();
        $('#btnSearch').click(function () {
            devCatUnitList.search();
        });
        $('#btnAdd').click(function () {
            devCatUnitList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatUnitForm = (function (catunitForm) {
        cloneCatUnit = Object.create(catunitForm);
        return cloneCatUnit;
    })(catunitForm);


    $(document).ready(function () {
        devCatUnitForm.initFormControl();
        $('#btnSave').click(function () { devCatUnitForm.save(); });
        $('#btnDelete').click(function () { devCatUnitForm.del(catunitList.closeForm); });
        $('#btnNew').click(function () { devCatUnitForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatUnitForm.save(catunitList.closeForm); });
        $('#btnClose').click(function () { catunitList.closeForm(); });

    });
