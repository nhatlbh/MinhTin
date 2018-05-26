<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportInvoiceTab.ascx.cs" Inherits="TnHSell.UC.ImportInvoiceTab" %>
<script type="text/javascript">
    $(document).ready(function () {

        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridSupplierReturn').svcGrid({
            service: 'BuySupplierreturn/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                { field: 'ID', hidden: true },
                { field: 'Code', title: 'Mã' },
                { field: 'Buy_ImportInvoice_Name', title: 'Phiếu nhập' },
                { field: 'Cat_Supplier_Name', title: 'Nhà cung cấp' },
                { field: 'CreateDate', title: 'Ngày tạo' },
                { field: 'Description', title: 'Ghi chú' },
                { field: 'TotalDebt', title: 'Tổng nợ' },
            ]
        });
        $('#gridMoneySlip').svcGrid({
            service: 'FinMoneyslip/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                    { field: 'ID', hidden: true },
                    { field: 'Code', title: 'Mã' },
                    { field: 'Cat_PaymentType_Name', title: 'Loại chi' },
                    { field: 'TotalPay', title: 'Số tiền' },
                    { field: 'CreateDate', title: 'Ngày tạo' },
                    { field: 'Description', title: 'Ghi chú' },
            ]
        });
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Phiếu trả hàng NCC</li>
        <li id="tab2">Phiếu chi</li>
    </ul>
    <div>
        <div id="gridSupplierReturn"></div>
    </div>
    <div>
        <div id="gridMoneySlip"></div>
    </div>
</div>
