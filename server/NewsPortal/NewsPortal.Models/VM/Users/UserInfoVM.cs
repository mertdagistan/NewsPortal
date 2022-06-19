using NewsPortal.DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.VM.Users
{
    public class UserInfoVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

        public string Role{ get; set; }

    }
}
