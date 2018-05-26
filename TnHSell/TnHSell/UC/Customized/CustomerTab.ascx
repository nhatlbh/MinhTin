<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerTab.ascx.cs" Inherits="TnHSell.UC.CustomerTab" %>
<script type="text/javascript">
    $(document).ready(function () {

        var tabstrip = $('#tabstrip').kendoTabStrip({}).data('kendoTabStrip');
        tabstrip.activateTab($("#tab1"));
        //$('#gridInvoice').svcGrid({
        //    service: 'SelInvoice/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
        //    columns: [
        //                { field: 'ID', hidden: true },
        //                { field: 'Code', title: 'Mã' },
        //                { field: 'Cat_Customer_Name', title: 'Khách hàng' },
        //                { field: 'Cat_IOCode_Name', title: 'Mã nhập xuất' },
        //                { field: 'DeliveryAddress', title: 'ĐC giao hàng' },
        //                { field: 'IsDelivered', title: 'Đã giao hàng', template: "<input type='checkbox' #= IsDelivered ? checked='checked' : '' # disabled='disabled' ></input>" },
        //                { field: 'DeliverDate', title: 'Ngày hẹn giao hàng' },
        //                { field: 'IncomeDate', title: 'Ngày thanh toán' },
        //                { field: 'Total', title: 'Tổng tiền' },
        //                { field: 'TotalDebt', title: 'Tổng nợ' },
        //                { field: 'Description', title: 'Ghi chú' },
        //    ]
        //});
        //$('#gridStoreExport').svcGrid({
        //    service: 'StoExport/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
        //    columns: [
        //                { field: 'ID', hidden: true },
        //                { field: 'Code', title: 'Mã' },
        //                { field: 'Cat_Store_Name', title: 'Kho' },
        //                { field: 'Reason', title: 'Lý do' },
        //                { field: 'Description', title: 'Ghi chú' },
        //                { field: 'CreateDate', title: 'Ngày tạo' },
        //    ]
        //});
        //$('#gridReceiveProduct').svcGrid({
        //    service: 'SelReceiveproduct/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
        //    columns: [
        //                { field: 'ID', hidden: true },
        //                { field: 'Code', title: 'Mã' },
        //                { field: 'Sel_Invoice_Name', title: 'Phiếu bán hàng' },
        //                { field: 'Cat_Customer_Name', title: 'Khách hàng' },
        //                { field: 'Cat_Store_Name', title: 'Kho' },
        //                { field: 'CreateDate', title: 'Ngày tạo' },
        //                { field: 'Total', title: 'Tổng tiền' },
        //                { field: 'TotalReturn', title: 'Tiền phải trả' },
        //                { field: 'Discount', title: 'Chiết khấu' },
        //                { field: 'Description', title: 'Ghi chú' },
        //    ]
        //});
        //$('#gridGuarantee').svcGrid({
        //    service: 'SelReceiveproduct/GetGridData?cond=' + 'Buy_ImportInvoiceID=1',
        //    columns: [
        //                { field: 'ID', hidden: true },
        //                { field: 'Code', title: 'Mã' },
        //                { field: 'Sel_Invoice_Name', title: 'Phiếu bán hàng' },
        //                { field: 'Cat_Customer_Name', title: 'Khách hàng' },
        //                { field: 'Cat_Store_Name', title: 'Kho' },
        //                { field: 'CreateDate', title: 'Ngày tạo' },
        //                { field: 'Total', title: 'Tổng tiền' },
        //                { field: 'TotalReturn', title: 'Tiền phải trả' },
        //                { field: 'Discount', title: 'Chiết khấu' },
        //                { field: 'Description', title: 'Ghi chú' },
        //    ]
        //});
    });
</script>
<div class="row" id="tabstrip">
    <ul>
        <li id="tab1">Phiếu bán hàng</li>
        <li id="tab2">Phiếu thu</li>
        <li id="tab3">Phiếu trả hàng</li>
        <li id="tab4">Phiếu bảo hành</li>
    </ul>
    <div>
        <div id="gridInvoice"></div>
    </div>

    <div>
        <div id="gridReceipt"></div>
    </div>
    <div>
        <div id="gridReceiveProduct"></div>
    </div>
    <div>
        <div id="gridGuarantee"></div>
    </div>
</div>

