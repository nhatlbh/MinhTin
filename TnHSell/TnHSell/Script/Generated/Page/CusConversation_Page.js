
// Generated Initiate List Script

    var devCusConversationList = (function (cusconversationList) {
        cloneCusConversation = Object.create(cusconversationList);
        return cloneCusConversation;
    })(cusconversationList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Cuộc hội thoại';
        devCusConversationList.initSearchControl();
        devCusConversationList.showGrid();
        $('#btnSearch').click(function () {
            devCusConversationList.search();
        });
        $('#btnAdd').click(function () {
            devCusConversationList.openForm();
        });
    });

// Generated Initiate Form Script

    var devCusConversationForm = (function (cusconversationForm) {
        cloneCusConversation = Object.create(cusconversationForm);
        return cloneCusConversation;
    })(cusconversationForm);


    $(document).ready(function () {
        devCusConversationForm.initFormControl();
        $('#btnSave').click(function () { devCusConversationForm.save(); });
        $('#btnDelete').click(function () { devCusConversationForm.del(cusconversationList.closeForm); });
        $('#btnNew').click(function () { devCusConversationForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devCusConversationForm.save(cusconversationList.closeForm); });
        $('#btnClose').click(function () { cusconversationList.closeForm(); });

    });
