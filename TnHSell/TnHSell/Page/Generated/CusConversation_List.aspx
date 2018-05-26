
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Generated/CusConversation_Form.ascx" TagPrefix="uc1" TagName="CusConversation_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">Cuộc hội thoại</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-1">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-1">Tiêu đề:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtTitle_S" />
                        </div></div> <div class="row"><div class="label col-md-1">Nhân viên:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlSalestaffid_S" />
                        </div><div class="label col-md-1">Khách hàng:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlCustomerid_S" />
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
            <uc1:CusConversation_Form runat="server" ID="CusConversation_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Generated/Page/CusConversation_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Generated/Page/CusConversation_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
