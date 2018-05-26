
    <script type="text/javascript" src="../../Script/Generated/Form/CusConversation_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                        <div class="label col-md-2">Tiêu đề:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtTitle" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Nhân viên:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlSalestaffid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Khách hàng:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlCustomerid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Nội dung:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtConvContent'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Kênh liên hệ:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlChanelid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Kết quả:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlConvresultid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Ngày cập nhật:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="dedCreatedon"/>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Note:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtNote'  rows='3'></textarea>
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

