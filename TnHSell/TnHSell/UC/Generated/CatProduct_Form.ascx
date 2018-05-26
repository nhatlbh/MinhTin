<%@ Register Src="~/UC/Customized/ProductPrice.ascx" TagPrefix="uc1" TagName="ProductPrice" %>

<script type="text/javascript" src="../../Script/Generated/Form/CatProduct_Form.js?session='<%=Guid.NewGuid() %>'"></script>
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
                <div class="col-md-6">
                    <div class="row">
                        <div class="label col-md-2">Mã:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtCode" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">tên:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtName" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Đơn vị tính:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlUnitid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Màu:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlColorid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Nhà cung cấp:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlSupplierid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Nhà sản xuất:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlManufactureid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Loại sản phẩm:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlProducttypeid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Nhóm sản phẩm:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlProductgroupid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2 required">Chi nhánh:</div>
                        <div class="input col-md-8">
                        <input placeholder="--- Chọn ---" ID="ddlBranchid" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Ghi chú:</div>
                    <div class="input col-md-8">
                        <textarea  id='txtDescription'  rows='3'></textarea>
                    </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Khóa:</div>
                        <div class="input col-md-8">
                        <input type="checkbox"  ID="chkBlocked" style='max-width:20px' />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Là linh kiện:</div>
                        <div class="input col-md-8">
                        <input type="checkbox"  ID="chkIscomponent" style='max-width:20px' />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Barcode:</div>
                        <div class="input col-md-8">
                            <input type="text" id="txtBarcode" />
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Định mức:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="txtWarningnum" style="max-width:100px"/>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="label col-md-2">Thứ tự:</div>
                        <div class="input col-md-8">
                            <input type="text" ID="txtOrdernum" style="max-width:100px"/>
                        </div>
                    </div>    
                </div>
                <div class="col-md-5">
                    <uc1:ProductPrice runat="server" ID="ProductPrice" />
                </div>
           </div> 
        </div>
        </div>
    </div>
<input type="hidden" id="hdfId" />

