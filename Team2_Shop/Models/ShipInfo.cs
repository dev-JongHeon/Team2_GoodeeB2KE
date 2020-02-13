using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class ShipInfo
    {
        [Required(ErrorMessage = "이름을 입력해주세요.")]
        [Display(Name = "이름")]
        public string Name { get; set; }

        [Required(ErrorMessage = "주소1을 입력해주세요.")]
        [Display(Name = "주소1")]
        public string Addr1 { get; set; }
        [Display(Name = "주소2")]
        public string Addr2 { get; set; }

        public string Email { get; set; }

        [Display(Name = "배송메세지")]
        public string Message { get; set; }
    }
}