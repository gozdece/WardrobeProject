using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.UserDto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage ="Email alani zorunludur")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password alani zorunludur")]
        public string Password { get; set; }
    }
}
