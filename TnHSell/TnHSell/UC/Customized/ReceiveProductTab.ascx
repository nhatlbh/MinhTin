<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveProductTab.ascx.cs" Inherits="TnHSell.UC.ReceiveProductTab" %>
<script type="text/javascript">
    $(document).ready(function () {

        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        $('#gridSelInvoice').svcGrid({
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
        <li id="tab1">Phiếu bán hàng</li>
        <li id="tab2">Phiếu chi</li>
    </ul>
    <div>
        <div id="gridSelInvoice"></div>
    </div>
    <div>
        <div id="gridMoneySlip"></div>
    </div>
</div>
