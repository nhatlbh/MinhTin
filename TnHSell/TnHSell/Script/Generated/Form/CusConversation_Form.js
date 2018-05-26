
     

var cusconversationForm = (function () {
    var seviceName = 'CusConversation';
    var sessionKey = $('#hdfSessionKey').val();
    var initFormControl = function initFormControl(){
            sessionKey = $('#hdfSessionKey').val();
             numberOnly($('#hdfId'))
      callService('CatSalestaff/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlSalestaffid']);
  callService('CatCustomer/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlCustomerid']);
    callService('CatChanel/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlChanelid']);
  callService('CatConvresult/GetComboboxData?sessionKey='+sessionKey, loadCombobox, ['ddlConvresultid']);
  $('#dedCreatedon').kendoDatePicker({
                                    format: '{0:dd/MM/yyyy}',
                                    });
    numberOnly($('#txtOrdernum'))
 
    }

  var buildDTO = function(){
  return {
           Id: $('#hdfId').val() ? $('#hdfId').val() : 0,
Code: $('#txtCode').val(),
Title: $('#txtTitle').val(),
Salestaffid: $("#ddlSalestaffid").data("kendoComboBox").value(),
Customerid: $("#ddlCustomerid").data("kendoComboBox").value(),
ConvContent: $('#txtConvContent').val(),
Chanelid: $("#ddlChanelid").data("kendoComboBox").value(),
Convresultid: $("#ddlConvresultid").data("kendoComboBox").value(),
Createdon: $('#dedCreatedon').val(),
Note: $('#txtNote').val(),
Ordernum: getNumber( $('#txtOrdernum').val())
        };
  }
  var validate = function () {
        return notEmpty([$('#txtCode'),$('#ddlSalestaffid'),$('#ddlCustomerid'),$('#txtConvContent'),$('#dedCreatedon')]);
        }
    var save = function save(ftnAfterSave) {
        var data = buildDTO();
        if (validate()) {
            callService(seviceName + '/Save?cusconversationJson=' + JSON.stringify(data), function (id) {
                setFormId(id);
                if(ftnAfterSave)
                    ftnAfterSave();
            });
        }
    }    
    
    var del = function del(ftnAfterDelete) {
        var id = $('#hdfId').val();
        if (id == '' || id == '0') {
            alert('Chưa chọn Cuộc hội thoại cần xóa');
        }
        else if (confirm("Bạn có muốn xóa Cuộc hội thoại này?")) {
            callService(seviceName + '/Delete?id=' + id, function (data) {
                alert('Xóa thành công.');
                ftnAfterDelete();
            })
        }
    }
    
    var refreshInputForm = function refreshInputForm() {
        $('#hdfId').val('');
        $('#txtCode').val('');
$('#txtTitle').val('');
$('#ddlSalestaffid').data('kendoComboBox').value(staffInfo.Id);
$('#ddlCustomerid').data('kendoComboBox').value('');
$('#txtConvContent').val('');
$('#ddlChanelid').data('kendoComboBox').value('');
$('#ddlConvresultid').data('kendoComboBox').value('');
$('#dedCreatedon').data('kendoDatePicker').value(getCurDate());
$('#txtNote').val('');
$('#txtOrdernum').val('');
        $("#grid .k-state-selected").removeClass('k-state-selected');
        $('.error').removeClass('error');
    }
    
    var setFormId = function (id) { $('#hdfId').val(id); }
    var getFormId = function () { return $('#hdfId').val(); }
 
    return {
        'buildDTO':buildDTO,
        'validate':validate,
        'save': save,
        'del': del,
        'refreshInputForm': refreshInputForm,
        'initFormControl': initFormControl,
        'setFormId': setFormId,
        'getFormId': getFormId,
    }
})();
