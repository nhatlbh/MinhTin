<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="TnHSell.UC.Common.MessageBox" %>

<link rel="stylesheet" href="../../Style/msgBox/msgBoxLight.css" />
<script type="text/javascript" src="../../Script/Libs/jquery.msgBox.js"></script>

<script type="text/javascript">
    var msgBox = {
        alert: alert,
    }
    function alert(msg) {
        $.msgBox({
            title: "Thông báo",
            content: msg,
            type: "alert"
        });
    }
</script>
<div id="alert"></div>
