<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="TnHSell.UC.Menu" %>
<link rel="stylesheet" href="../../Style/menu/component.css" />
<link rel="stylesheet" href="../../Style/menu/default.css" />
<%= RenderMenu().ToString() %>
<script src="../../../Script/cbpHorizontalMenu.min.js"></script>
<script type="text/javascript">
    $(function () {
        cbpHorizontalMenu.init();
    });
</script>



