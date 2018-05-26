
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Override/GuarReturn_Form.ascx" TagPrefix="uc1" TagName="GuarReturn_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">Phiếu trả bảo hành</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-2">Nhân viên tạo:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlSalestaffid_S" />
                        </div><div class="label col-md-2">Khách hàng:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlCustomerid_S" />
                        </div></div> <div class="row"><div class="label col-md-2">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-2">Ngày tạo:</div>
                        <div class="input col-md-3">
                            <input type="text" placeholder="Từ ngày" ID="dedCreatedate_SF"/>
                                                <input type="text" placeholder="Đến ngày" ID="dedCreatedate_ST"/>
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
            <uc1:GuarReturn_Form runat="server" ID="GuarReturn_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Override/Page/GuarReturn_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Override/Page/GuarReturn_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
