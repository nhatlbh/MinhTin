var sessionKey = $('#hdfSessionKey').val();
var gridMgntGroup = (function (grid) {
    grid.setGrid();
    return grid;
})(Object.create(selectableGrid, {
    title: { value: 'Nhóm quản lý' },
    service: { value: 'CatManagementgroup/GetComboboxData?sessionKey='+sessionKey }
}))

var gridProductType = (function (grid) {
    grid.setGrid();
    return grid;
})(Object.create(selectableGrid, {
    title: { value: '' },
    service: { value: 'CatProducttype/GetComboboxData?sessionKey=' + sessionKey },
    gridId: { value: 'grdProductType' },

}))
function resetGrid()
{
    gridMgntGroup.resetSelected(gridMgntGroup.grid);
    gridProductType.resetSelected(gridProductType.grid);
}
// Generated Initiate List Script

var devCatSalestaffList = (function (catsalestaffList) {
    cloneCatSalestaff = Object.create(catsalestaffList);
    return cloneCatSalestaff;
})(catsalestaffList);


$(document).ready(function () {
    document.title = 'Nhân viên Sale';
    devCatSalestaffList.initSearchControl();
    devCatSalestaffList.showGrid();
    $('#btnSearch').click(function () {
        devCatSalestaffList.search();
    });
    $('#btnAdd').click(function () {
        resetGrid();
        devCatSalestaffList.openForm();
    });
    var grid = catsalestaffList.getGrid();
    if (grid)
        kendoHelpers.grid.eventRowDoubleClick(grid, function (dataItem) {
            var formId = catsalestaffList.getFormId();           
            catsalestaffList.openForm(formId);
            setGridSelectedRows(formId)
        });
});

// Generated Initiate Form Script




var devCatSalestaffForm = (function (catsalestaffForm) {
    cloneCatSalestaff = Object.create(catsalestaffForm);
    return cloneCatSalestaff;
})(catsalestaffForm);


$(document).ready(function () {
    gridMgntGroup.init();
    gridProductType.init();
    devCatSalestaffForm.initFormControl();
    $('#btnSave').click(function () { SaveStaff(); });
    $('#btnDelete').click(function () { devCatSalestaffForm.del(catsalestaffList.closeForm); });
    $('#btnNew').click(function () { devCatSalestaffForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { SaveStaff(catsalestaffList.closeForm); });
    $('#btnClose').click(function () { catsalestaffList.closeForm(); });

    function SaveStaff(ftnCallback) {
        var staffDTO = devCatSalestaffForm.buildDTO();
        staffDTO.Id = catsalestaffList.getFormId();
        var selectedGroups = gridMgntGroup.getSelectedRows(gridMgntGroup.grid);
        var selectedProductTypes = gridProductType.getSelectedRows(gridProductType.grid);
        callService('CatSaleStaffOvr/SaveStaff?staffJson=' + JSON.stringify(staffDTO) + '&groupJson=' + JSON.stringify(selectedGroups) + '&productTypeJson=' + JSON.stringify(selectedProductTypes),
                        function (result) {
                            if (result.indexOf("Lỗi:") == -1) {
                                devCatSalestaffForm.setFormId(result);
                                if (ftnCallback) {
                                    ftnCallback(result);
                                }
                                callService("CatSaleStaffOvr/GetStaffMgntGroup?staffId=" + result, gridMgntGroup.setSelectedRows, gridMgntGroup.grid);
                            }
                            else
                                alert(result);
                            if (ftnCallback)
                                ftnCallback();
                        });

    }

});

function setGridSelectedRows(formId) {
    gridMgntGroup.resetSelected(gridMgntGroup.grid);
    gridProductType.resetSelected(gridProductType.grid);
    callService("CatSaleStaffOvr/GetStaffMgntGroup?staffId=" + formId, gridMgntGroup.setSelectedRows, gridMgntGroup.grid);
    callService("CatSaleStaffOvr/GetStaffProductType?staffId=" + formId, gridProductType.setSelectedRows, gridProductType.grid);
}
