
// Generated Initiate List Script

    var devCatChanelList = (function (catchanelList) {
        cloneCatChanel = Object.create(catchanelList);
        return cloneCatChanel;
    })(catchanelList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Nhà sản xuất';
        devCatChanelList.initSearchControl();
        devCatChanelList.showGrid();
        $('#btnSearch').click(function () {
            devCatChanelList.search();
        });
        $('#btnAdd').click(function () {
            devCatChanelList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCatChanelForm = (function (catchanelForm) {
        cloneCatChanel = Object.create(catchanelForm);
        return cloneCatChanel;
    })(catchanelForm);


    $(document).ready(function () {
        devCatChanelForm.initFormControl();
        $('#btnSave').click(function () { devCatChanelForm.save(); });
        $('#btnDelete').click(function () { devCatChanelForm.del(catchanelList.closeForm); });
        $('#btnNew').click(function () { devCatChanelForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCatChanelForm.save(catchanelList.closeForm); });
        $('#btnClose').click(function () { catchanelList.closeForm(); });

    });
