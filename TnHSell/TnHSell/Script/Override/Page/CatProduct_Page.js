/// <reference path="D:\Own\TnH\2017\TnHSell MinhTin\Source\TnHSell\TnHSell\Page/Generated/CatProduct_List.aspx" />

// Generated Initiate List Script
var sessionKey;
var devCatProductList = (function (catproductList) {
    cloneCatProduct = Object.create(catproductList);
    return cloneCatProduct;
})(catproductList);


$(document).ready(function () {
    sessionKey = $('#hdfSessionKey').val();
    validateSession(sessionKey);
    document.title = 'Sản phẩm';
    devCatProductList.initSearchControl();
    devCatProductList.showGrid();
    $('#btnSearch').click(function () {
        devCatProductList.search();
    });
    $('#btnAdd').click(function () {
        devCatProductList.openForm();
    });
    var gridProduct = devCatProductList.getGrid();
    if (gridProduct) {
        kendoHelpers.grid.eventRowDoubleClick(gridProduct, function (dataItem) {
            var formId = devCatProductList.getFormId();
            devCatProductList.openForm(formId);
            productPrice.showGrid(formId);
        });
    }
});

// Generated Initiate Form Script
var productPrice = (function (productPrice) {
    return Object.create(productPrice);
})(productPrice);

var devCatProductForm = (function (catproductForm) {
    cloneCatProduct = Object.create(catproductForm);
    return cloneCatProduct;
})(catproductForm);


$(document).ready(function () {
    productPrice.showGrid(0);
    devCatProductForm.initFormControl();
    $('#btnSave').click(function () { saveProduct(); });
    $('#btnDelete').remove();
    $('#btnNew').click(function () { devCatProductForm.refreshInputForm(); });
    $('#btnSaveAndClose').click(function () { saveProduct(catproductList.closeForm); });
    $('#btnClose').click(function () { catproductList.closeForm(); });
});

function saveProduct(ftnCallback) {
    var productDTO = catproductForm.buildDTO();
    // productDTO.Id = devCatProductList.getFormId();
    var priceDTOs = [];
    var priceArr = productPrice.getPrice();
    $.each(priceArr, function (i, v) { priceDTOs.push({ 'Productid': productDTO.Id, 'Iocodeid': v.ioCodeID, 'Price': v.price }); });
    callService('CatProductOvr/SaveProduct?productJson=' + JSON.stringify(productDTO) + '&priceJson=' + JSON.stringify(priceDTOs),
           function (result) {
               if (result.indexOf("Lỗi:") == -1) {
                   devCatProductForm.setFormId(result);
                   if (ftnCallback) {
                       ftnCallback(result);
                   }
                   productPrice.showGrid(result);
               }
               else
                   alert(result);
               if (ftnCallback)
                   ftnCallback();
           });
}
