using NewsPortal.DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models.VM.Users
{
    public class UserEditVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(40, ErrorMessage = "FullName must be less than 40 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(25, ErrorMessage = "UserName must be less than 25 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(25, ErrorMessage = "Password must be less than 25 characters")]
        [MinLength(6, ErrorMessage = "Password must be longer than 6 characters")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
