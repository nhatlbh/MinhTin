var devAdmRoleList = (function (admroleList) {
    cloneAdmRole = Object.create(admroleList);
    return cloneAdmRole;
})(admroleList);
var devRoleRight = (function (roleRight) {
    return Object.create(roleRight);
})(roleRight);

$(document).ready(function () {
    var sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'nhóm';
    devAdmRoleList.initSearchControl();
    devAdmRoleList.showGrid();
    $('#btnSearch').click(function () {
        devAdmRoleList.search();
    });
    $('#btnAdd').click(function () {
        devAdmRoleList.openForm();
        mapTree.setCheckedNodes('');
        devRoleRight.init();
    });
    if (devAdmRoleList.getGrid())
        kendoHelpers.grid.eventRowDoubleClick(devAdmRoleList.getGrid(), function (dataItem) {
            var formId = devAdmRoleList.getFormId();
            devAdmRoleList.openForm(formId);
            callService("Role/GetContexts?roleId=" + formId, mapTree.setCheckedNodes);
            callService("Role/GetRights?roleId=" + formId, devRoleRight.setRights);
        });
});

var mapTree = (function (mapTree) { return Object.create(checkboxTree); }(checkboxTree));

$(document).ready(function () {
    $.ajax({
        url: domain + "TreeData/CreateTreeMap",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var options = { filterId: 100000, data: $.parseJSON(data), };
            mapTree.initTree(options);
        },
        error: function (XHR, textStatus, errorThrown) {
            console.log(textStatus + ":" + errorThrown);
        },
    });
});

var devAdmRoleForm = (function (admroleForm) {
    cloneAdmRole = Object.create(admroleForm);
    return cloneAdmRole;
})(admroleForm);

$(document).ready(function () {
    devAdmRoleForm.initFormControl();
    $('#btnSave').click(function () { saveRole(); });
    $('#btnDelete').click(function () { deleteRole(); });
    $('#btnNew').click(function () { devAdmRoleForm.refreshInputForm(); mapTree.setCheckedNodes(''); devRoleRight.init(); });
    $('#btnSaveAndClose').click(function () { saveRole(devAdmRoleList.closeForm); });
    $('#btnClose').click(function () { devAdmRoleList.closeForm(); });

});
function saveRole(ftnAfterSave) {
    var roleDTO = devAdmRoleForm.buildDTO();
    var selectedContext = checkboxTree.getCheckedNodes();
    //if (devAdmRoleForm.validate()) {
    callService('Role/SaveRole?roleJson=' + JSON.stringify(roleDTO) + '&contextJson=' + JSON.stringify(selectedContext) + '&rightJson=' + JSON.stringify(devRoleRight.getRights()),
        function (result) {
            if (result.indexOf("Lỗi:") == -1) {
                devAdmRoleForm.setFormId(result);
                if (ftnAfterSave) {
                    ftnAfterSave(result);
                }
                callService("Role/GetContexts?roleId=" + result, mapTree.setCheckedNodes);
            }
            else
                alert(result);
        });
    // }
}
function deleteRole() {
    var id = devAdmRoleList.getFormId();
    if (id == '' || id == 0) {
        alert("Vui lòng chọn vai trò cần xóa");
    }
    else if (confirm("Bạn có thực sự muốn xóa vai trò này?")) {
        callService("Role/DeleteRole?roleId=" + id, devAdmRoleList.closeForm);
    }
}

