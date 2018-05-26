﻿<%@ Register Src="~/UC/Reusable/InvoiceDetail.ascx" TagPrefix="uc1" TagName="InvoiceDetail" %>
<script type="text/javascript" src="../../Script/Override/Form/BuyGuarantee_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                <div class="col-md-5">
                    <div class="row">
                        <div class="label col-md-2 required">Nhân viên:</div>
                        <div class="input col-md-8">
                            <input placeholder="--- Chọn ---" id="ddlSalestaffid" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2 required">Mã:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtCode" />
                        </div>
                    </div>
                    <div class="row hidden">
                        <div class="label col-md-2">Tên:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtName" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2 required">Khách hàng:</div>
                        <div class="input col-md-8">
                            <input placeholder="--- Chọn ---" id="ddlCustomerid" />
                        </div>
                    </div>
                    <div class="row hidden">
                        <div class="label col-md-2 required">Kho bảo hành:</div>
                        <div class="input col-md-8">
                            <input placeholder="--- Chọn ---" id="ddlStoreid" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2 required">Ngày nhận:</div>
                        <div class="input col-md-8">
                            <input type="text" id="dedReceivedate" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2 required">Ngày hẹn trả:</div>
                        <div class="input col-md-8">
                            <input type="text" id="dedExpectreturndate" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Ngày trả:</div>
                        <div class="input col-md-8">
                            <input type="text" id="dedReturndate" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Số ngày báo trước:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtNotifydates" style="max-width: 100px" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Ghi chú:</div>
                        <div class="input col-md-8">
                            <textarea id='txtDescription' rows='3'></textarea>
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Trạng thái:</div>
                        <div class="input col-md-8">
                            <input placeholder="--- Chọn ---" id="ddlGuarstatusid" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Thứ tự:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtOrdernum" style="max-width: 100px" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <uc1:InvoiceDetail runat="server" ID="InvoiceDetail" />
                </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hdfId" />

