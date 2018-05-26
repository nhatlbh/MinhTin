var domain = 'http://localhost:58949/';

//Tạo kendocombobox từ datasorce
function loadCombobox(data, inputID, onChanged, firstItem) {
    data = JSON.parse(data);
    var textField = "Name";
    if (data.length > 0) {
        var props = Object.keys(data[0]);
        textField = props[1];
    }
    if (firstItem) {
        var item = {
            ID: 0,
            Name: firstItem,
            Code: firstItem,
        };
        var tmp = Array.prototype.slice.call([].concat(data));
        tmp.unshift(item);
        data = tmp;
    }
    if (data.length > 0) {
        $('#' + inputID).kendoComboBox({
            dataTextField: textField,
            dataValueField: "ID",
            dataSource: data,
            filter: "contains",
            suggest: true,
            change: onChanged,
        });
    }
    else {
        $('#' + inputID).kendoComboBox({});
    }
}
//Gọi service sau đó truyền params để thực thi hàm Callback 
var callService = function callService(serviceName, callback, params) {
    //$.ajaxPrefilter(function (options, original_Options, jqXHR) {
    //    options.async = true;
    //});
    return $.ajax({
        //async: true,
        url: domain + serviceName,
        //data: JSON.stringify(data),
        error: function (XHR, textStatus, errorThrown) {
            console.log(textStatus + ":" + errorThrown);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (params && Array.isArray(params)) {
                var callbackArgs = Array.prototype.slice.call(params);
                callbackArgs.unshift(data);
                callback.apply(this, callbackArgs);
            }
            else {
                callback(data, params);
            }
        },
    });
}
var callServiceMultiCallback = function callServiceMultiCallback(serviceName, callbacks, params) {
    //$.ajaxPrefilter(function (options, original_Options, jqXHR) {
    //    options.async = true;
    //});
    return $.ajax({
        //async: true,
        url: domain + serviceName,
        //data: JSON.stringify(data),
        error: function (XHR, textStatus, errorThrown) {
            console.log(textStatus + ":" + errorThrown);
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $.each(callbacks, function (idx, callback) {
                if (idx == 0)
                    if (params && Array.isArray(params[idx])) {
                        var callbackArgs = Array.prototype.slice.call(params);
                        callbackArgs.unshift(data);
                        callback.apply(this, callbackArgs);
                    }
                    else {
                        if (params && params[idx])
                            callback(data, params[idx]);
                        else
                            callback(data);
                    }
                else
                    if (params && Array.isArray(params[idx])) {
                        var callbackArgs = Array.prototype.slice.call(params);
                        callback.apply(this, callbackArgs);
                    }
                    else {
                        if (params && params[idx])
                            callback(params[idx]);
                        else
                            callback();
                    }
            });
        },
    });
}


//Remove SQLInject từ điều kiện truyền vào để gọi API.
function removeSQLInject(input) {
    return input.replace("'", "''");
}
//Tạo Cotrol chỉ chấp nhận nhập ký tự số
function numberOnly(control) {
    control.keydown(function (e) {
        if (e.shiftKey)
            e.preventDefault();
        else
            if (e.keyCode == 8 || e.keyCode == 9)
                return;
        if (e.keyCode < 95) {
            if (e.keyCode < 48 || e.keyCode > 57)
                e.preventDefault();
        }
        else {
            if (e.keyCode < 96 || e.keyCode > 105)
                e.preventDefault();
        }
    });
}
function numberOnlyArr(arrControl) {
    for (var i = 0; i < arrControl.length; i++) {
        numberOnly(arrControl[i]);
    }
}
//Lấy ngày hiện tại theo format dd/MM/yyyy
function getCurDate() {
    var date = new Date();
    var day = date.getDate();
    if (day < 10)
        day = '0' + day;
    var month = date.getMonth() + 1;
    if (month < 10)
        month = '0' + month;
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
}
function dateToString(date) {
    var day = date.getDate();
    if (day < 10)
        day = '0' + day;
    var month = date.getMonth();
    if (month < 10)
        month = '0' + month;
    var year = date.getFullYear();
    return date + '/' + month + '/' + year;
}

//Disable nhiều control
function disableControlArr(arrControl) {
    $.each(arrControl, function (idx, control) {
        control.attr('disabled', 'disabled');
    });
}
//Enable nhiều control
function enableControlArr(arrControl) {
    $.each(arrControl, function (idx, control) {
        control.removeAttr('disabled');
    });
}

//Ẩn nhiều control
function hideControlArr(arrControl) {
    $.each(arrControl, function (idx, control) {
        control.hide();
    });
}
//Hiển thị nhiều control
function showControlArr(arrControl) {
    $.each(arrControl, function (idx, control) {
        control.show();
    });
}

//Format kiểu số
function numberFormat(value) {
    return numeral(value).format('0,0');
}
//Lấy giá trị số đã qua format
function getNumber(value) {
    return numeral(value).value();
}

function validateSession(sessionKey) {
    callService("Session/Validate?sessionKey=" + sessionKey, postValidateSession)
}

function postValidateSession(message) {
    if (message === 'False')
        location.href = '../page/login';
}
