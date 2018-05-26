<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoneySlipTab.ascx.cs" Inherits="TnHSell.UC.MoneySlipTab" %>
<script type="text/javascript">
    $(document).ready(function () {

        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridImportInvoice').svcGrid({
            service: 'BuyImportinvoice/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                    { field: 'ID', hidden: true },
                    { field: 'Code', title: 'Mã' },
                    { field: 'Cat_Store_Name', title: 'Kho' },
                    { field: 'Cat_Supplier_Name', title: 'Nhà cung cấp' },
                    { field: 'CreateDate', title: 'Ngày tạo' },
                    { field: 'Description', title: 'Ghi chú' },
                    { field: 'TotalDebt', title: 'Tổng nợ' },
            ]
        });
        $('#gridReceiveProduct').svcGrid({
            service: 'SelReceiveproduct/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                        { field: 'ID', hidden: true },
                        { field: 'Code', title: 'Mã' },
                        { field: 'Sel_Invoice_Name', title: 'Phiếu bán hàng' },
                        { field: 'Cat_Customer_Name', title: 'Khách hàng' },
                        { field: 'Cat_Store_Name', title: 'Kho' },
                        { field: 'CreateDate', title: 'Ngày tạo' },
                        { field: 'Total', title: 'Tổng tiền' },
                        { field: 'TotalReturn', title: 'Tiền phải trả' },
                        { field: 'Discount', title: 'Chiết khấu' },
                        { field: 'Description', title: 'Ghi chú' },
            ]
        });
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Phiếu nhập</li>
        <li id="tab3">Phiếu trả hàng</li>
    </ul>
    <div>
        <div id="gridImportInvoice"></div>
    </div>
    <div>
        <div id="gridReceiveProduct"></div>
    </div>
</div>
