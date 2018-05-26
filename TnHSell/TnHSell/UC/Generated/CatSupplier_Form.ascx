
    <script type="text/javascript" src="../../Script/Generated/Form/CatSupplier_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                        <div class="label col-md-2 required">Mã:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtCode" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Tên:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtName" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Địa chỉ:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtAddress'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">MST:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtTaxcode" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Điện thoại:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtPhone" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Fax:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtFax" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Email:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtEmail" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Người liên hệ:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtContact'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">SĐT liên hệ:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtContactphone" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Email liên hệ:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtContactemail" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Được phép nợ:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="txtMaxalloweddebt" style="max-width:100px"/>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Khóa:</div>
                        <div class="input col-md-8">
                        <input type="checkbox"  ID="chkBlocked" style='max-width:20px' />
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
           </div> 
        </div>
        </div>
    </div>
<input type="hidden" id="hdfId" />

