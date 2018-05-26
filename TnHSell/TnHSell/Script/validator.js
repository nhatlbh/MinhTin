function notEmpty(inputList) {
    var result = true;
    var focus = false;
    for (var i = 0; i < inputList.length; i++) {
        var showingObject = getShowingObject(inputList[i]);
        if (showingObject.value == '' || showingObject.value == null) {
            showingObject.consumer.addClass('error');
            if (!focus) {
                showingObject.consumer.focus();
                focus = true;
            }
            result = false;
        }
        else {
            showingObject.consumer.removeClass('error');
        }
    }
    return result;
}
function getShowingObject(input) {
    var result = {
        consumer: input,
        type: '',
        value: ''
    };
    if (input.parent().attr('class').indexOf('k-combobox') != -1) {
        result.type = "kendoComboBox";
    }
    if (input.parent().attr('class').indexOf('k-picker-wrap') != -1) {
        result.type = "kendoDatePicker";
    }
    if (result.type.indexOf('kendo') != -1) {
        result.value = input.data(result.type).value();
        result.consumer = input.parent();
    }
    else {
        result.value = input.val()
        result.type = 'HTML';
    }
    return result;
}



