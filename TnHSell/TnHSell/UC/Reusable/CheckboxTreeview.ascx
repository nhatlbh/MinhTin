<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckboxTreeview.ascx.cs" Inherits="Admin.UC.ContextList_Selectale" %>

<script type="text/javascript">
    var checkboxTree = (function () {
        var setting;
        var defaultSetting = {
            filterId: 0,
            data: [],
        };
        var checkedNodes = [];
        var treeView;

        function treeTraversal(nodes, callbackFunc, params) {
            for (var i = 0; i < nodes.length; i++) {
                callbackFunc(nodes[i], params);
                if (nodes[i].hasChildren) {
                    treeTraversal(nodes[i].children.view(), callbackFunc, params);
                }
            }
        }

        function onCheck() {
            var message;
            treeTraversal(treeView.dataSource.view(), updateCheckedNodes);
        }
        function updateCheckedNodes(node) {
            if (node.id > setting.filterId) {
                var checkedIndex = checkedNodes.indexOf(node.id - setting.filterId);
                if (node.checked && checkedIndex < 0)
                    checkedNodes.push(node.id - setting.filterId);
                else if (!node.checked && checkedIndex >= 0)
                    checkedNodes.splice(checkedIndex, 1);
            }
        }

        var initTree = function (options) {
            setting = $.extend(defaultSetting, options);
            treeView = $("#treeview").kendoTreeView({
                checkboxes: {
                    checkChildren: true
                },

                check: onCheck,
                dataSource: setting.data,
            }).data("kendoTreeView");
            treeView.collapse(".k-item");
        }
        var getCheckedNodes = function () {
            return checkedNodes;
        }
        function isExistedId(id) {
            var result = -1;
            $.each(checkedNodes, function (i, val) {
                if (val == id)
                    result = i;
            });
            return result;
        }
        var setCheckedNodes = function (ids) {
            treeTraversal(treeView.dataSource.view(), checkTreeNodes, ids);
            treeTraversal(treeView.dataSource.view(), updateCheckedNodes);
        }
        function checkTreeNodes(node, ids) {
            if (ids.indexOf((node.id - setting.filterId).toString()) >= 0)
                node.set('checked', true);
            else
                node.set('checked', false);
        }
        return {
            'setting': setting,
            'initTree': initTree,
            'getCheckedNodes': getCheckedNodes,
            'setCheckedNodes': setCheckedNodes,
        }
    })();
    // Usage Example
    /*
     var mapTree = (function (mapTree) { return Object.create(checkboxTree); }(checkboxTree));
    $(document).ready(function () {
        $.ajax({
            url: domain + "TreeData/CreateTreeMap",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var options = { filterId: 100000, data: $.parseJSON(data), };
                mapTree.initTree(options);
            },
            error: function (XHR, textStatus, errorThrown) {
                console.log(textStatus + ":" + errorThrown);
            },
        });
    });
    */
</script>
<div class="row">
    <div id="treeview"></div>
</div>
