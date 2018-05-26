(function ($) {

    //-----Form popup for manipulate detail data----//
    $.fn.popupForm = function (options) {
        var id = options.id;
        var setting = $.extend({
            open: function (e) { },
            close: function (e) { },
        }, options);
        var popup = this.kendoPopup(
              {
                  open: setting.open,
                  close: setting.close,
                  origin: 'top center',
                  position: 'top center',
                  collision: "fit",
              }).data('kendoPopup');
        return {
            popup: popup,
            id: id,
        };
    }

    //------ Combobox bind to service to get data ---- //
    $.fn.svcCombobox = function (options) {
        var setting = $.extend({
            textField: 'Name',
            valueField: 'ID',
            service: '',
            change: function () { },
            filter: 'contains',
            data: {},
        }, options);
        callService(setting.service, createCombobox, [setting, this])
    }
    function createCombobox(dt, setting, ccb) {
        setting.data = JSON.parse(dt);
        ccb.kendoComboBox({
            dataTextField: setting.textField,
            dataValueField: setting.valueField,
            dataSource: setting.data,
            filter: setting.filter,
            suggest: true,
            change: setting.change,
            enable:setting.enable,
        });
    }
    //----- End svcCombobox -----//

    //------ Grid bind to service to get data -----//
    $.fn.svcGrid = function (options) {
        var setting = $.extend({
            service: '',
            data: [],
            pageSize: 5,
            id: 'ID',
            columns: [],
            selectable: 'row',
            pageable: {
                buttonCount: 5
            },
            change: function () { },
        }, options);
        callService(setting.service, createGrid, [setting, this])
    }
    function createGrid(dt, setting, grid) {
        setting.data = JSON.parse(dt);
        grid.kendoGrid({
            dataSource: {
                type: 'odata',
                data: setting.data,
                pageSize: setting.pageSize,
                schema: {
                    model: {
                        id: setting.id,
                    }
                },
            },
            columns: setting.columns,
            selectable: setting.selectable,
            pageable: setting.pageable,
            change: setting.change,
        });
    }
    //----- End svcGrid -----//

    //----- Radio Button List -----//
    $.fn.radioList = function (option) {
        var setting = $.extend({
            name: '',
            items: [{}],
            change: function () { },
            defaultValue: '',
            itemClass: 'col-md-1 radio-button',
            inputClass: '',
        }, option);
        for (var i = 0; i < setting.items.length; i++) {
            var value = this.find('input[value="' + setting.items[i].value + '"]').attr('value');
            if (value == undefined || value != setting.items[i].value)
                this.append("<div class='" + setting.itemClass + "'>"
                                + "<input class='" + setting.inputClass + "' type='radio' name='" + setting.name + "' value='" + setting.items[i].value + "'/>" + setting.items[i].text
                          + " </div>");
        }
        this.find('input').change(setting.change);
        this.find('input[value="' + setting.defaultValue + '"]').prop('checked', true);
        var getValue = function () {
            return this.radioList.find("input[name='" + setting.name + "']:checked").attr('value');
        };
        var setValue = function (val) {
            this.radioList.find("input[value='" + val + "']").prop('checked', true);
        };
        return {
            radioList: this,
            getValue: getValue,
            setValue: setValue,
        };
    }
    //----- End radioList -----//
}(jQuery))

