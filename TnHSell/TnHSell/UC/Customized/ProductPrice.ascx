<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductPrice.ascx.cs" Inherits="TnHSell.UC.Generated.ProductPrice" %>
<script type="text/javascript">
    $(function () {

    });
    var productPrice = (function () {
        var grid;
        var showGrid = function (productId) {
            if (!productId || productId == '')
                productId = 0;
            callService('CatProductOvr/GetProductPrice?productId=' + productId, bindPriceGrid);
        }
        var getPrice = function () {
            if (!grid)
                grid = $("#gridPrice").kendoGrid().data("kendoGrid");
            var choiceList = [];
            grid.tbody.find("tr").each(function () {
                var dataItem = grid.dataItem($(this));
                var price = dataItem.Price;
                choiceList.push({ 'ioCodeID': dataItem.ID, 'price': price });
            });
            return choiceList;
        }
        function bindPriceGrid(data) {
            grid = $('#gridPrice').kendoGrid({
                columns: [
                  { field: "ID", hidden: true },
                  { field: "Code", title: 'Mã NX' },
                  { field: "Name", title: 'Tên mã NX' },
                  { field: "Price", title: 'Giá bán', format: "{0:#,0##}" }
                ],
                dataSource: {
                    data: JSON.parse(data),
                    schema: {
                        model: {
                            id: "ID",
                            fields: {
                                ID: { editable: false, },
                                Code: { editable: false },
                                Name: { editable: false },
                                Price: { editable: true, type: 'number' }
                            }
                        }
                    }
                },
                editable: true,
            }).data("kendoGrid");
        }

        return {
            'showGrid': showGrid,
            'getPrice': getPrice,
        }
    })()
</script>
<div id="gridPrice" />
