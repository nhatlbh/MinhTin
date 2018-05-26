<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master" %>

<%@ Register Src="~/UC/Override/BuyImportinvoice_Form.ascx" TagPrefix="uc1" TagName="BuyImportinvoice_Form" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">


    <div class="row">
        <div class="col-md-12">
            <div class="title">Phiếu nhập</div>
            <div id="search" class="jumbotron">
                <div class="row">
                    <div class="label col-md-1">Mã:</div>
                    <div class="input col-md-3">
                        <input type="text" id="txtCode_S" />
                    </div>
                    <div class="label col-md-1">Kho:</div>
                    <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" id="ddlCatStoreid_S" />
                    </div>
                </div>
                <div class="row">
                    <div class="label col-md-1">Nhà cung cấp:</div>
                    <div class="input col-md-3">
                        <input placeholder="--- Chọn ---" id="ddlCatSupplierid_S" />
                    </div>
                    <div class="label col-md-1">Ngày tạo:</div>
                    <div class="input col-md-3">
                        <input type="text" placeholder="Từ ngày" id="dedCreatedate_SF" />
                        <input type="text" placeholder="Đến ngày" id="dedCreatedate_ST" />
                    </div>
                </div>
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
    <div class="row" id="popup">
        <uc1:BuyImportinvoice_Form runat="server" ID="BuyImportinvoice_Form" />
    </div>

    <input type="hidden" id="hdfId" />
    <script type="text/javascript" src="../../Script/Override/Page/BuyImportinvoice_List.js?session='<%=Guid.NewGuid() %>'"></script>
    <script type="text/javascript" src="../../Script/Override/Page/BuyImportinvoice_Page.js?session='<%=Guid.NewGuid() %>'"></script>
</asp:Content>
