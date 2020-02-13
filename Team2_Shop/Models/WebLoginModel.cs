using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Shop.Models
{
    public class WebLoginModel
    {
        [Required(ErrorMessage = "Give Your ID")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Give Your Password")]
        public string UserPwd { get; set; }
    }
}
