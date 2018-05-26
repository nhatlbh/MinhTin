
// Generated Initiate List Script

    var devCatConvresultList = (function (catconvresultList) {
        cloneCatConvresult = Object.create(catconvresultList);
        return cloneCatConvresult;
    })(catconvresultList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhà sản xuất';
        devCatConvresultList.initSearchControl();
        devCatConvresultList.showGrid();
        $('#btnSearch').click(function () {
            devCatConvresultList.search();
        });
        $('#btnAdd').click(function () {
            devCatConvresultList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatConvresultForm = (function (catconvresultForm) {
        cloneCatConvresult = Object.create(catconvresultForm);
        return cloneCatConvresult;
    })(catconvresultForm);


    $(document).ready(function () {
        devCatConvresultForm.initFormControl();
        $('#btnSave').click(function () { devCatConvresultForm.save(); });
        $('#btnDelete').click(function () { devCatConvresultForm.del(catconvresultList.closeForm); });
        $('#btnNew').click(function () { devCatConvresultForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatConvresultForm.save(catconvresultList.closeForm); });
        $('#btnClose').click(function () { catconvresultList.closeForm(); });

    });
