
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master"%>
<%@ Register Src="~/UC/Override/BuyGuarantee_Form.ascx" TagPrefix="uc1" TagName="BuyGuarantee_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
         <div class="title">Tình\Thành phố</div>
            <div id="search" class="jumbotron">
             <div class="row"><div class="label col-md-1">Mã:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtCode_S" />
                        </div><div class="label col-md-1">Tên:</div>
                        <div class="input col-md-3">
                            <input type="text" id="txtName_S" />
                        </div></div> <div class="row"><div class="label col-md-1">Khách hàng:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlCustomerid_S" />
                        </div><div class="label col-md-1">Sản phẩm:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlProductid_S" />
                        </div></div> <div class="row"><div class="label col-md-1">Kho bảo hành:</div>
                        <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" ID="ddlStoreid_S" />
                        </div><div class="label col-md-1">Ngày nhận:</div>
                        <div class="input col-md-3">
                            <input type="text" placeholder="Từ ngày" ID="dedReceivedate_SF"/>
                                                <input type="text" placeholder="Đến ngày" ID="dedReceivedate_ST"/>
                        </div></div> <div class="row"><div class="label col-md-1">Ngày hẹn trả:</div>
                        <div class="input col-md-3">
                            <input type="text" placeholder="Từ ngày" ID="dedExpectreturndate_SF"/>
                                                <input type="text" placeholder="Đến ngày" ID="dedExpectreturndate_ST"/>
                        </div><div class="label col-md-1">Ngày trả:</div>
                        <div class="input col-md-3">
                            <input type="text" placeholder="Từ ngày" ID="dedReturndate_SF"/>
                                                <input type="text" placeholder="Đến ngày" ID="dedReturndate_ST"/>
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
            <uc1:BuyGuarantee_Form runat="server" ID="BuyGuarantee_Form" />
        </div>

<input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Override/Page/BuyGuarantee_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Override/Page/BuyGuarantee_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
