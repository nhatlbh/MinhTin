
// Generated Initiate List Script

    var devCatManagementgroupList = (function (catmanagementgroupList) {
        cloneCatManagementgroup = Object.create(catmanagementgroupList);
        return cloneCatManagementgroup;
    })(catmanagementgroupList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhóm quản lý';
        devCatManagementgroupList.initSearchControl();
        devCatManagementgroupList.showGrid();
        $('#btnSearch').click(function () {
            devCatManagementgroupList.search();
        });
        $('#btnAdd').click(function () {
            devCatManagementgroupList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatManagementgroupForm = (function (catmanagementgroupForm) {
        cloneCatManagementgroup = Object.create(catmanagementgroupForm);
        return cloneCatManagementgroup;
    })(catmanagementgroupForm);


    $(document).ready(function () {
        devCatManagementgroupForm.initFormControl();
        $('#btnSave').click(function () { devCatManagementgroupForm.save(); });
        $('#btnDelete').click(function () { devCatManagementgroupForm.del(catmanagementgroupList.closeForm); });
        $('#btnNew').click(function () { devCatManagementgroupForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatManagementgroupForm.save(catmanagementgroupList.closeForm); });
        $('#btnClose').click(function () { catmanagementgroupList.closeForm(); });

    });
