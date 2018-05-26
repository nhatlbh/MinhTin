
// Generated Initiate List Script

    var devCatColorList = (function (catcolorList) {
        cloneCatColor = Object.create(catcolorList);
        return cloneCatColor;
    })(catcolorList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Màu';
        devCatColorList.initSearchControl();
        devCatColorList.showGrid();
        $('#btnSearch').click(function () {
            devCatColorList.search();
        });
        $('#btnAdd').click(function () {
            devCatColorList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatColorForm = (function (catcolorForm) {
        cloneCatColor = Object.create(catcolorForm);
        return cloneCatColor;
    })(catcolorForm);


    $(document).ready(function () {
        devCatColorForm.initFormControl();
        $('#btnSave').click(function () { devCatColorForm.save(); });
        $('#btnDelete').click(function () { devCatColorForm.del(catcolorList.closeForm); });
        $('#btnNew').click(function () { devCatColorForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatColorForm.save(catcolorList.closeForm); });
        $('#btnClose').click(function () { catcolorList.closeForm(); });

    });
