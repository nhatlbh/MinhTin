
// Generated Initiate List Script

    var devCatProductgroupList = (function (catproductgroupList) {
        cloneCatProductgroup = Object.create(catproductgroupList);
        return cloneCatProductgroup;
    })(catproductgroupList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhóm sản phẩm';
        devCatProductgroupList.initSearchControl();
        devCatProductgroupList.showGrid();
        $('#btnSearch').click(function () {
            devCatProductgroupList.search();
        });
        $('#btnAdd').click(function () {
            devCatProductgroupList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatProductgroupForm = (function (catproductgroupForm) {
        cloneCatProductgroup = Object.create(catproductgroupForm);
        return cloneCatProductgroup;
    })(catproductgroupForm);


    $(document).ready(function () {
        devCatProductgroupForm.initFormControl();
        $('#btnSave').click(function () { devCatProductgroupForm.save(); });
        $('#btnDelete').click(function () { devCatProductgroupForm.del(catproductgroupList.closeForm); });
        $('#btnNew').click(function () { devCatProductgroupForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatProductgroupForm.save(catproductgroupList.closeForm); });
        $('#btnClose').click(function () { catproductgroupList.closeForm(); });

    });
