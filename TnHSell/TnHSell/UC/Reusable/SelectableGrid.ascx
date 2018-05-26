<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectableGrid.ascx.cs" Inherits="Admin.UC.AssignRole" %>
<div class="row grid-title">
    <span id="title"></span>
</div>
<div class="row">
    <div id="selectableGrid"></div>
</div>
<script type="text/javascript">
    var selectableGrid = {
        grid: {},
        service: '',
        title: '',
        gridId: 'selectableGrid',
        columns: [
                    { field: "ID", hidden: true, },
                    { field: "Name", title: "Tên" },
                    { title: "Chọn", template: "<input type='checkbox' class='checkbox' />" },
        ],
        pageSize: 10,
        schema: {
            model: {
                id: 'ID',
            }
        },
        init: function () {
            if (this.title && this.title != '')
                $('#title').html(this.title);
            var self = this;
            callService(this.service, this.showGrid, self);
        },

        resetSelected: function (grid) {
            if (grid) {
                grid.tbody.find("tr").each(function () {
                    var checkbox = $(this).find("input");
                    checkbox.prop("checked", false);
                });
            }
            return;
        },

        setSelectedRows: function (idList, grid) {
            //this.setGrid;
            if (grid) {
                $.each(idList, function (index, value) {
                    var row;
                    grid.tbody.find("tr").each(function () {
                        if ($(this).find("td").first().html() == value) {
                            row = $(this);
                            return false;
                        }
                    });
                    var checkbox = $(row).find("input");
                    checkbox.prop("checked", true);
                });
            }
        },

        getSelectedRows: function (grid) {
            if (grid) {
                var choiceList = [];
                grid.tbody.find("tr").each(function () {
                    var checkbox = $(this).find("input");
                    if (checkbox.prop('checked')) {
                        var dataItem = grid.dataItem($(this));
                        choiceList.push(dataItem.ID);
                    }
                });
                return choiceList;
            }
        },

        setGrid: function () {
            return $("#" + this.gridId).data("kendoGrid");
        },
        showGrid: function showGrid(data, self) {
            self.grid = $("#" + self.gridId).kendoGrid({
                dataSource: {
                    type: 'odata',
                    data: JSON.parse(data),
                    pageSize: self.pageSize,
                    schema: self.schema,
                }
               , pageable: true
               , selectable: "multiple row"
               , columns: self.columns,
                editable: "inline",
            }).data("kendoGrid");
        }
    }
</script>
