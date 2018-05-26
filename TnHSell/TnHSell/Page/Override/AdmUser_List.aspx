
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Override/AdmUser_Form.ascx" TagPrefix="uc1" TagName="AdmUser_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">người dùng</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-1">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-1">Tên:</div>
                    <div class="input col-md-3">
                        <textarea  id='txtName_S'  rows='3'></textarea>
                    </div></div> <div class="row"><div class="label col-md-1">Ngày tạo:</div>
                        <div class="input col-md-3">
                            <input type="text" placeholder="Từ ngày" ID="dedCreatedate_SF"/>
                                                <input type="text" placeholder="Đến ngày" ID="dedCreatedate_ST"/>
                        </div><div class="label col-md-1">Đã khóa:</div>
                        <div class="input col-md-3">
                        <input type="checkbox"  ID="chkDisabled_S" style='max-width:20px' />
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
            <uc1:AdmUser_Form runat="server" ID="AdmUser_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Override/Page/AdmUser_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Override/Page/AdmUser_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
