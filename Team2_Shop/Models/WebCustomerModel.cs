using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Shop.Models
{
    public class WebCustomerModel
    {
        public int Customer_ID { get; set; }

        [Required(ErrorMessage = "아이디를 입력해주세요")]
        [DisplayName("아이디")]
        public string Customer_UserID { get; set; }



        [Required(ErrorMessage = "비밀번호를 입력해주세요")]
        [DisplayName("비밀번호")]
        public string Customer_PWD { get; set; }



        [Required(ErrorMessage = "이름은 입력해주세요")]
        [DisplayName("이름")]
        public string Customer_Name { get; set; }



        [Required(ErrorMessage = "전화번호를 입력해주세요.")]
        [DisplayName("전화번호")]
        public string Customer_Phone { get; set; }



        [DisplayName("이메일")]
        [Required(ErrorMessage = "이메일을 입력해주세요.")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Customer_Email { get; set; }


        
        [Required(ErrorMessage = "생년월일을 입력해주세요.")]
        [DisplayName("생년월일")]
        public string Customer_Birth { get; set; }


        
        [Required(ErrorMessage = "도로명주소를 입력해주세요.")]
        [DisplayName("도로명 주소")]
        public string Customer_Address1 { get; set; }

         
        [Required(ErrorMessage = "상세주소를 입력해주세요.")]
        [DisplayName("상세주소")]
        public string Customer_Address2 { get; set; }
    }

    public class RegisterModel : WebCustomerModel
    {
        public string Customer_Phone1 { get; set; }
        public string Customer_Phone2 { get; set; }
        public string Customer_Phone3 { get; set; }
        public string Customer_Birth_Y { get; set; }
        public string Customer_Birth_M { get; set; }
        public string Customer_Birth_D { get; set; }
    }

}
