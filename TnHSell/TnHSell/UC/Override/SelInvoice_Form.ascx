<%@ Register Src="~/UC/Reusable/InvoiceDetail.ascx" TagPrefix="uc1" TagName="InvoiceDetail" %>
<script type="text/javascript" src="../../Script/Override/Form/SelInvoice_Form.js?session='<%=Guid.NewGuid() %>'"></script>
<div class="container">
    <div class="row">
        <div id="input" class="col-md-11">
            <div class="row btn-seperator">
                <div class="col-md-1"></div>
                <input type="button" id="btnNew" class="btn btn-default btn-sm btn-info" value="Mới" />
                <input type="button" id="btnSave" class="btn btn-default btn-sm btn-info" value="Lưu" />
                <input type="button" id="btnSaveAndClose" class="btn btn-default btn-sm btn-info" value="Lưu và đóng" />
                <input type="button" id="btnDelete" class="btn btn-default btn-sm btn-info" value="Xóa" />
                <input type="button" id="btnClose" class="btn btn-default btn-sm btn-info" value="Đóng" />
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="label col-md-1 required">Nhân viên:</div>
                        <div class="input col-md-3">
                            <input placeholder="--- Chọn ---" id="ddlSalestaffid" />
                        </div>
                        <div class="label col-md-1 required">Mã:</div>
                        <div class="input col-md-2">
                            <input type="text" id="txtCode" />
                        </div>
                        <div class="label col-md-1 required">Ngày tạo:</div>
                        <div class="input col-md-2">
                            <input type="text" id="dedCreatedate" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label col-md-1 required">Kho:</div>
                        <div class="input col-md-4">
                            <input placeholder="--- Chọn ---" id="ddlStoreid" />
                        </div>
                        <div class="label col-md-1 required">Khách hàng:</div>
                        <div class="input col-md-4">
                            <input placeholder="--- Chọn ---" id="ddlCustomerid" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label col-md-1 required">Mã nhập xuất:</div>
                        <div class="input col-md-4">
                            <input placeholder="--- Chọn ---" id="ddlIocodeid" />
                        </div>
                        <div class="label col-md-1 required">ĐC giao hàng:</div>
                        <div class="input col-md-4">
                            <textarea id='txtDeliveryaddress' rows='3'></textarea>
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-1">Số HS tài chính:</div>
                        <div class="input col-md-4">
                            <input type="text" id="txtFinancefilenum" />
                        </div>
                        <div class="label col-md-1">Số quyển:</div>
                        <div class="input col-md-4">
                            <input type="text" id="txtFilenum" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-1">Số biên nhận:</div>
                        <div class="input col-md-4">
                            <input type="text" id="txtReceiptnum" />
                        </div>
                        <div class="label col-md-1">Ngày thanh toán:</div>
                        <div class="input col-md-4">
                            <input type="text" id="dedIncomedate" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label col-md-1">Ghi chú:</div>
                        <div class="input col-md-9">
                            <textarea id='txtDescription' rows='3'></textarea>
                        </div>
                    </div>
                    <div class="row" style="border: solid 1px; padding: 10px; margin: 0px 70px 0px 10px; border-collapse: collapse; border-radius: 5px; border-color: #cdcdcd;">
                        <div class="label col-md-1" style="margin-top: 2px;">
                            <div style="float: left;">Giảm giá:</div>
                            <input type="checkbox" id="chkDiscount" style="float: left; margin-top: 0px; margin-left: 2px;" />
                        </div>
                        <div class="label col-md-1">Phần trăm:</div>
                        <div class="input col-md-2">
                            <input type="text" id="txtPercentdiscount" style="max-width: 100px" />
                        </div>
                        <div class="label col-md-1">Tiền mặt:</div>
                        <div class="input col-md-2">
                            <input type="text" id="txtValuediscount" style="max-width: 100px" />
                        </div>
                        <div class="label col-md-1">Tổng tiền:</div>
                        <div class="input col-md-2">
                            <input type="text" id="txtTotaldiscount" style="max-width: 100px" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10" style="padding-left: 90px; padding-top: 20px;">
                            <uc1:InvoiceDetail runat="server" ID="InvoiceDetail" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label col-md-1">Tổng tiền:</div>
                        <div class="input col-md-4">
                            <input type="text" id="txtTotal" style="max-width: 100px" />
                        </div>
                        <div class="label col-md-1 required">Tổng nợ:</div>
                        <div class="input col-md-4">
                            <input type="text" id="txtTotaldebt" style="max-width: 100px" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="label col-md-1">Đã giao hàng:</div>
                        <div class="input col-md-4">
                            <input type="checkbox" id="chkIsdelivered" style='max-width: 20px' />
                        </div>
                        <div class="label col-md-1">Ngày giao hàng:</div>
                        <div class="input col-md-4">
                            <input type="text" id="dedDeliverdate" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hdfId" />

<script type="text/javascript">
    var chkDiscount = $('#chkDiscount'), txtPercentdiscount = $('#txtPercentdiscount'), txtValuediscount = $('#txtValuediscount'), txtTotaldiscount = $('#txtTotaldiscount');
    var txtTotal = $('#txtTotal'), txtTotalDeb = $('#txtTotaldebt');
    $(function () {
        disableControlArr([txtPercentdiscount, txtValuediscount, txtTotaldiscount]);
        chkDiscount.change(function () {
            if (chkDiscount.prop('checked')) {
                enableControlArr([txtPercentdiscount, txtValuediscount, ]);
            }
            else {
                disableControlArr([txtPercentdiscount, txtValuediscount, ]);
                txtPercentdiscount.val('');
                txtValuediscount.val('');
            }
        });
        txtPercentdiscount.change(function () {
            discountChanged();
        });
        txtTotal.change(function () {
            discountChanged();
        });
        txtValuediscount.change(function () { discountChanged(); });
    });
    function discountChanged() {
        var totalDiscount = getNumber(txtTotal.val()) * getNumber(txtPercentdiscount.val()) / 100 + getNumber(txtValuediscount.val());
        var totalDebt = getNumber(txtTotal.val()) - getNumber(totalDiscount);
        txtTotaldiscount.val(numberFormat(totalDiscount));
        txtTotalDeb.val(numberFormat(totalDebt));
    }
</script>
