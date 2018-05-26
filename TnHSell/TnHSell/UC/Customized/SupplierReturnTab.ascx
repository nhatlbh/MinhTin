<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplierReturnTab.ascx.cs" Inherits="TnHSell.UC.SupplierReturnTab" %>
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
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Phiếu nhập hàng</li>
        <li id="tab2">Phiếu thu</li>
    </ul>
    <div>
        <div id="gridImportInvoice"></div>
    </div>
    <div>
        <div id="gridReceipt"></div>
    </div>
</div>
