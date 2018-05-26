
// Generated Initiate List Script

    var devCatDistrictList = (function (catdistrictList) {
        cloneCatDistrict = Object.create(catdistrictList);
        return cloneCatDistrict;
    })(catdistrictList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Quận\Huyện';
        devCatDistrictList.initSearchControl();
        devCatDistrictList.showGrid();
        $('#btnSearch').click(function () {
            devCatDistrictList.search();
        });
        $('#btnAdd').click(function () {
            devCatDistrictList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatDistrictForm = (function (catdistrictForm) {
        cloneCatDistrict = Object.create(catdistrictForm);
        return cloneCatDistrict;
    })(catdistrictForm);


    $(document).ready(function () {
        devCatDistrictForm.initFormControl();
        $('#btnSave').click(function () { devCatDistrictForm.save(); });
        $('#btnDelete').click(function () { devCatDistrictForm.del(catdistrictList.closeForm); });
        $('#btnNew').click(function () { devCatDistrictForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatDistrictForm.save(catdistrictList.closeForm); });
        $('#btnClose').click(function () { catdistrictList.closeForm(); });

    });
