using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum BuyGuaranteeColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           Name,           
           CustomerID,           
           StoreID,           
           ReceiveDate,           
           ExpectReturnDate,           
           ReturnDate,           
           NotifyDates,           
           Description,           
           GuarStatusID,           
           OrderNum,           
    }
    public partial class BuyGuaranteeContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","Name","CustomerID","StoreID","ReceiveDate","ExpectReturnDate","ReturnDate","NotifyDates","Description","GuarStatusID","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        public Int32? Customerid { get; set; }
        public Int32? Storeid { get; set; }
        string _receivedate;
        public string Receivedate { get {return _receivedate!=null?_receivedate:string.Empty;} set{_receivedate=value;} }
        string _expectreturndate;
        public string Expectreturndate { get {return _expectreturndate!=null?_expectreturndate:string.Empty;} set{_expectreturndate=value;} }
        string _returndate;
        public string Returndate { get {return _returndate!=null?_returndate:string.Empty;} set{_returndate=value;} }
        string _notifydates;
        public string Notifydates { get {return _notifydates!=null?_notifydates:string.Empty;} set{_notifydates=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        public Int32? Guarstatusid { get; set; }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
