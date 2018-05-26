<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Main.Master" %>


<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="row" style="font-family: Calibri, Arial, sans-serif; color: #47a3da; font-weight: 600; font-size: 22pt; text-align: center;">
        Vui lòng đăng nhập từ ứng dụng Window.
    </div>
    <script type="text/javascript">
        $(function () {
            var sessionKey = $('#hdfSessionKey').val();
            $("#cbp-hrmenu").html('');
            callService('Login/Login?sessionId=' + getUrlVars()['sessionId'] + "&sessionKey=" + sessionKey, postLogin);
            function postLogin(data) {
                if (data === 'Success') {
                    location.href = '../page/init';
                }
                else {
                    alert(data);
                }
            }
        });

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1].replace('#', '');
            }
            return vars;
        }
    </script>
</asp:Content>
