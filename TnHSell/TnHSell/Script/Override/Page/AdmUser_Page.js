var sessionKey; 

var devAdmUserList = (function (admuserList) {
    cloneAdmUser = Object.create(admuserList);
    return cloneAdmUser;
})(admuserList);

var devAdmUserForm = (function (admuserForm) {
    cloneAdmUser = Object.create(admuserForm);
    return cloneAdmUser;
})(admuserForm);

var grdRole_User = (function (grid) {
    grid.setGrid();
    return grid;
})(Object.create(selectableGrid, {
    title: { value: 'Nhóm quyền' },
    service: { value: 'AdmRole/GetComboboxData?sessionKey=' + sessionKey }
}))

$(document).ready(function () {
    sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'người dùng';
    devAdmUserList.initSearchControl();
    devAdmUserList.showGrid();
    $('#btnSearch').click(function () {
        devAdmUserList.search();
    });
    $('#btnAdd').click(function () {
        devAdmUserList.openForm();
        grdRole_User.resetSelected(grdRole_User.grid);
    });

    if (devAdmUserList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devAdmUserList.getGrid(), function (dataItem) {
            var formId = devAdmUserList.getFormId();
            devAdmUserList.openForm(formId);
            callService("AdmUserOvr/GetRoleList?userId=" + formId, grdRole_User.setSelectedRows, grdRole_User.grid);
        });
});

// Generated Initiate Form Script



$(document).ready(function () {
    devAdmUserForm.initFormControl();
    $('#btnSave').click(function () { saveUser(); });
    $('#btnDelete').click(function () { deleteUser(); });
    $('#btnNew').click(function () { devAdmUserForm.refreshInputForm(); grdRole_User.resetSelected(grdRole_User.grid); });
    $('#btnSaveAndClose').click(function () { var saveID = saveUser(devAdmUserList.closeForm); });
    $('#btnClose').click(function () { devAdmUserList.closeForm(); });
    grdRole_User.init({});
});

function saveUser(ftnAfterSave) {
    var userDTO = devAdmUserForm.buildDTO();
    userDTO.Id = devAdmUserList.getFormId();
    var selectedRoles = grdRole_User.getSelectedRows(grdRole_User.grid);
    callService('AdmUserOvr/Save?userJson=' + JSON.stringify(userDTO) + '&roleIds=' + JSON.stringify(selectedRoles),
    function (result) {
        if (result.indexOf("Lỗi:") == -1) {
            devAdmUserForm.setFormId(result);
            if (ftnAfterSave) {
                ftnAfterSave(result);
            }
            callService("AdmUserOvr/GetRoleList?userId=" + result, grdRole_User.setSelectedRows, grdRole_User.grid);
        }
        else
            alert(result);
        if (ftnAfterSave)
            ftnAfterSave();
    });
}

function deleteUser() {
    var id = devAdmUserList.getFormId();
    if (id == '' || id == 0) {
        alert("Vui lòng chọn vai trò cần xóa");
    }
    else if (confirm("Bạn có thực sự muốn xóa người dùng này?")) {
        callService("Role/DeleteRole?roleId=" + id, devAdmUserList.closeForm);
    }
}


