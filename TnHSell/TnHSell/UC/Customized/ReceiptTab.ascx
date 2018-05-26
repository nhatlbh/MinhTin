<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiptTab.ascx.cs" Inherits="TnHSell.UC.ReceiptTab" %>
<script type="text/javascript">
    $(document).ready(function () {

        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridInvoice').svcGrid({
            service: 'SelInvoice/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
            columns: [
                        { field: 'ID', hidden: true },
                        { field: 'Code', title: 'Mã' },
                        { field: 'Cat_Customer_Name', title: 'Khách hàng' },
                        { field: 'Cat_IOCode_Name', title: 'Mã nhập xuất' },
                        { field: 'DeliveryAddress', title: 'ĐC giao hàng' },
                        { field: 'IsDelivered', title: 'Đã giao hàng', template: "<input type='checkbox' #= IsDelivered ? checked='checked' : '' # disabled='disabled' ></input>" },
                        { field: 'DeliverDate', title: 'Ngày hẹn giao hàng' },
                        { field: 'IncomeDate', title: 'Ngày thanh toán' },
                        { field: 'Total', title: 'Tổng tiền' },
                        { field: 'TotalDebt', title: 'Tổng nợ' },
                        { field: 'Description', title: 'Ghi chú' },
            ]
        });

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
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Phiếu bán hàng</li>
        <li id="tab3">Phiếu trả hàng NCC</li>
    </ul>
    <div>
        <div id="gridInvoice"></div>
    </div>
    <div>
        <div id="gridSupplierReturn"></div>
    </div>
</div>
