﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleRight.ascx.cs" Inherits="TnHSell.UC.Customized.AdmRight" %>
<script type="text/javascript">
    var roleRight = (function () {
        var dataview;
        var init = function () {
            dataview = $("input[name='dataview']");
            $("input[name='dataview'][value='3']").prop('checked', 'checked');
            $("#chkEditInvoiceRight").prop('checked', false);
        }
        var setRights = function (rights) {
            $("#roleRight  input[value='" + rights[0] + "']").prop('checked', 'checked');
            if (rights[1] == '4')//id quyền xóa sửa phiếu = 4
            {
                $('#chkEditInvoiceRight').prop('checked', true);
            }
        }
        var getRights = function () {
            var result = [];
            result.push($("#roleRight input[name='dataview']:checked").val());
            if ($('#chkEditInvoiceRight').prop('checked')) {
                result.push('4')
            }
            return result;
        }
        return {
            'init': init,
            'setRights': setRights,
            'getRights': getRights,
        }
    })();
</script>

<div id="roleRight" class="row" style="border-top: solid 1px #e0e0e0; border-bottom: solid 1px #e0e0e0;">
    <div class="col-md-4 no-margin">Thao tác dữ liệu</div>
    <div class="col-md-7">
        <div class="row">
            <div class="col-md-4 no-margin">
                <div class="row no-margin">
                    <input type="radio" name="dataview" value="1" style="margin-left: 20px" />
                </div>
                <div class="row no-margin">Hệ thống</div>
            </div>
            <div class="col-md-4 no-margin">
                <div class="row no-margin">
                    <input type="radio" name="dataview" value="2" style="margin-left: 20px" />
                </div>
                <div class="row no-margin">Chi nhánh</div>
            </div>
            <div class="col-md-3 no-margin">
                <div class="row no-margin">
                    <input type="radio" name="dataview" value="3" checked="checked" style="margin-left: 20px" />
                </div>
                <div class="row no-margin">Cá nhân</div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4 no-margin">Xóa/Sửa phiếu bán hàng</div>
    <div class="col-md-2">
        <input type="checkbox" id="chkEditInvoiceRight" /></div>
</div>
