
// Generated Initiate List Script

    var devCatProvinceList = (function (catprovinceList) {
        cloneCatProvince = Object.create(catprovinceList);
        return cloneCatProvince;
    })(catprovinceList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Tình\Thành phố';
        devCatProvinceList.initSearchControl();
        devCatProvinceList.showGrid();
        $('#btnSearch').click(function () {
            devCatProvinceList.search();
        });
        $('#btnAdd').click(function () {
            devCatProvinceList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProvinceForm = (function (catprovinceForm) {
        cloneCatProvince = Object.create(catprovinceForm);
        return cloneCatProvince;
    })(catprovinceForm);


    $(document).ready(function () {
        devCatProvinceForm.initFormControl();
        $('#btnSave').click(function () { devCatProvinceForm.save(); });
        $('#btnDelete').click(function () { devCatProvinceForm.del(catprovinceList.closeForm); });
        $('#btnNew').click(function () { devCatProvinceForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProvinceForm.save(catprovinceList.closeForm); });
        $('#btnClose').click(function () { catprovinceList.closeForm(); });

    });
