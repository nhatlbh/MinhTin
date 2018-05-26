<%@ Register Src="~/UC/Reusable/CheckboxTreeview.ascx" TagPrefix="uc1" TagName="CheckboxTreeview" %>
<%@ Register Src="~/UC/Customized/RoleRight.ascx" TagPrefix="uc1" TagName="RoleRight" %>


<script type="text/javascript" src="../../Script/Override/Form/AdmRole_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                        <div class="label col-md-2 required">Tên:</div>
                        <div class="input col-md-8">
                            <textarea id='txtName' rows='3'></textarea>
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2 required">Mã:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtCode" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Mô tả:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtDescription" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Đã khóa:</div>
                        <div class="input col-md-8">
                            <input type="checkbox" id="chkDisabled" style='max-width: 20px' />
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="label col-md-2">Thứ tự:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtOrdernum" style="max-width: 100px" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <uc1:CheckboxTreeview runat="server" ID="CheckboxTreeview" />
                    <uc1:RoleRight runat="server" id="RoleRight" />
                </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hdfId" />

