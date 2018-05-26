<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="POTabs.ascx.cs" Inherits="TnHSell.UC.POTabs" %>
<script type="text/javascript">
    $(document).ready(function () {
        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridProduct').svcGrid({
            service: 'CatProduct/GetGridData?cond=' + 'id=2',
            columns: [
                { field: 'Code', title: 'Mã' },
                { field: 'Name', title: 'tên' },
                { field: 'Cat_Unit_Name', title: 'Đơn vị tính' },
                { field: 'Cat_Color_Name', title: 'Màu' },
                { field: 'Cat_ProductType_Name', title: 'Loại sản phẩm' },
                { field: 'Cat_ProductGroup_Name', title: 'Nhóm sản phẩm' },
            ]
        });
        $('#gridPO').svcGrid({
            service: 'BuyPo/GetGridData?cond=' + 'id=1',
            columns: [
                    { field: 'ID', hidden: true },
                    { field: 'Code', title: 'Mã' },
                    { field: 'Cat_Supplier_Name', title: 'Nhà cung cấp' },
                    { field: 'CreateDate', title: 'Ngày tạo' },
                    { field: 'Description', title: 'Ghi chú' },
                    { field: 'OrderNum', title: 'Thứ tự' },
            ],
        });
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Product</li>
        <li id="tab2">Purchase Order</li>
    </ul>
    <div>
        <div id="gridProduct"></div>
    </div>
    <div>
        <div id="gridPO"></div>
    </div>
</div>

