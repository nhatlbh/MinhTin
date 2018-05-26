<%@ Register Src="~/UC/Reusable/SelectableGrid.ascx" TagPrefix="uc1" TagName="SelectableGrid" %>

<script type="text/javascript" src="../../Script/Override/Form/CatSalestaff_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                <div class="col-md-7">
                    <div class="row">
                        <div class="label col-md-2 required">Mã:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtCode" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Tên:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtName" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Chi nhánh:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlBranchid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Người dùng:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlUserid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Địa chỉ:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtAddress'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Điện thoại:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtPhone" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Email:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtEmail" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Di động:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtMobile" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">CMND:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtSocialnum" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Giới tính:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlSex" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Ngày sinh:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="dedBirthdate"/>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Nghỉ việc:</div>
                        <div class="input col-md-8">
                        <input type="checkbox"  ID="chkIsquit" style='max-width:20px' />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Ghi chú:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtDescription'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Thứ tự:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="txtOrdernum" style="max-width:100px"/>
                        </div>
                    </div>    
                </div>
                <div class="col-md-4">
                    <uc1:SelectableGrid runat="server" ID="SelectableGrid" />
                    <div class="row grid-title">Nhóm sản phẩm</div>
                    <div class="row" id="grdProductType"></div>
                </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hdfId" />

