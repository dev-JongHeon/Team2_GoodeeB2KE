using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="노답")]        
        public string UserID { get; set; }
        [Required(ErrorMessage = "노답")]        
        public string UserPwd { get; set; }
    }
}