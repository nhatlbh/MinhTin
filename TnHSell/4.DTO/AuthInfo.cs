using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnHSell.DTO
{
    public class AuthInfo
    {
        public string UserId { get; set; }
        public string StaffId { get; set; }
        public string BranchId { get; set; }
        public List<string> StaffMgntGroupIds { get; set; }
        public List<string> StaffProductTypeIds { get; set; }
        public List<string> UserRightIds { get; set; }
    }
}
