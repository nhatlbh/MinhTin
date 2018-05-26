using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum LoginSessionColumns
    {
           ID,           
           UserID,           
           SessionID,           
           Token,           
           Expired,           
    }
    public partial class LoginSessionContract
    {  

    public static readonly string[] Columns = {"ID","UserID","SessionID","Token","Expired",};
        public Int32 Id { get; set; }
        public Int32? Userid { get; set; }
        string _sessionid;
        public string Sessionid { get {return _sessionid!=null?_sessionid:string.Empty;} set{_sessionid=value;} }
        string _token;
        public string Token { get {return _token!=null?_token:string.Empty;} set{_token=value;} }
        string _expired;
        public string Expired { get {return _expired!=null?_expired:string.Empty;} set{_expired=value;} }
    }
}
