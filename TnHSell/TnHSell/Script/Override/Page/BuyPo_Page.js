
// Generated Initiate List Script

    var devBuyPoList = (function (buypoList) {
        cloneBuyPo = Object.create(buypoList);
        return cloneBuyPo;
    })(buypoList);


    $(document).ready(function () {
        var sessionKey = $('#hdfSessionKey').val();
        validateSession(sessionKey);
        document.title = 'Đơn đặt hàng';
        devBuyPoList.initSearchControl();
        devBuyPoList.showGrid();
        $('#btnSearch').click(function () {
            devBuyPoList.search();
        });
        $('#btnAdd').click(function () {
            devBuyPoList.openForm();
        });
    });

// Generated Initiate Form Script

    var devBuyPoForm = (function (buypoForm) {
        cloneBuyPo = Object.create(buypoForm);
        return cloneBuyPo;
    })(buypoForm);


    $(document).ready(function () {
        devBuyPoForm.initFormControl();
        $('#btnSave').click(function () { devBuyPoForm.save(); });
        $('#btnDelete').click(function () { devBuyPoForm.del(buypoList.closeForm); });
        $('#btnNew').click(function () { devBuyPoForm.refreshInputForm(); });
        $('#btnSaveAndClose').click(function () { var saveID = devBuyPoForm.save(buypoList.closeForm); });
        $('#btnClose').click(function () { buypoList.closeForm(); });

    });
