using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class ShipInfo
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "주소를 입력해주세요.")]
        [Display(Name = "배송지 주소")]        
        public string Addr1 { get; set; }

        [Display(Name = "상세주소")]
        [Required(ErrorMessage = "상세주소를 입력해주세요.")]
        public string Addr2 { get; set; }

        [Display(Name ="배송확인 이메일")]
        public string Email { get; set; }

        [Display(Name = "배송메세지")]
        public string Message { get; set; }
    }
}