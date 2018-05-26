
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Generated/CatCustomer_Form.ascx" TagPrefix="uc1" TagName="CatCustomer_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">Khách hàng</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-1">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-1">Tên:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtName_S" />
                        </div></div> <div class="row"><div class="label col-md-1">Nhóm quản lý:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlManagementgroupid_S" />
                        </div><div class="label col-md-1">Quận-Huyện:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlDistrictid_S" />
                        </div></div> <div class="row"><div class="label col-md-1">Tỉnh:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlProvinceid_S" />
                        </div><div class="label col-md-1">Nhân viên sale:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlSalestaffid_S" />
                        </div></div> 
             <div class="row">
                 <div class="col-md-1"></div>
                <div class="col-md-4">
                <input type="button" class="btn btn-default btn-info" id="btnSearch" value="Tìm" />
                <input type="button" class="btn btn-default btn-info" id="btnAdd" value="Thêm mới" />
                </div>
             </div>
            </div>
            <div id="grid"></div>
       </div> 
       </div>
        <div id="popup">
            <uc1:CatCustomer_Form runat="server" ID="CatCustomer_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Generated/Page/CatCustomer_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Generated/Page/CatCustomer_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
