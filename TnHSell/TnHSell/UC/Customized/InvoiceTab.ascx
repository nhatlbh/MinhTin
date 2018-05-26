<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvoiceTab.ascx.cs" Inherits="TnHSell.UC.InvoiceTab" %>
<script type="text/javascript">
    $(document).ready(function () {
        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridReceipt').svcGrid({
            service: 'FinReceipt/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                        { field: 'ID', hidden: true },
                        { field: 'Code', title: 'Mã' },
                        { field: 'Cat_PaymentType_Name', title: 'Loại thu' },
                        { field: 'TotalPay', title: 'Số tiền' },
                        { field: 'CreateDate', title: 'Ngày tạo' },
                        { field: 'Description', title: 'Ghi chú' },
            ]
        });
        $('#gridStoreExport').svcGrid({
            service: 'StoExport/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                        { field: 'ID', hidden: true },
                        { field: 'Code', title: 'Mã' },
                        { field: 'Cat_Store_Name', title: 'Kho' },
                        { field: 'Reason', title: 'Lý do' },
                        { field: 'Description', title: 'Ghi chú' },
                        { field: 'CreateDate', title: 'Ngày tạo' },
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
        <li id="tab1">Phiếu thu</li>
        <li id="tab2">Phiếu xuất kho</li>
        <li id="tab3">Phiếu trả hàng</li>
    </ul>
    <div>
        <div id="gridReceipt"></div>
    </div>
    <div>
        <div id="gridStoreExport"></div>
    </div>
    <div>
        <div id="gridReceiveProduct"></div>
    </div>
</div>
