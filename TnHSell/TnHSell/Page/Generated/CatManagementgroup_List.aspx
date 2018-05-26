
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Generated/CatManagementgroup_Form.ascx" TagPrefix="uc1" TagName="CatManagementgroup_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">Nhóm quản lý</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-2">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-2">Tên:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtName_S" />
                        </div></div> 
             <div class="row">
                 <div class="col-md-2"></div>
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
            <uc1:CatManagementgroup_Form runat="server" ID="CatManagementgroup_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Generated/Page/CatManagementgroup_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Generated/Page/CatManagementgroup_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
