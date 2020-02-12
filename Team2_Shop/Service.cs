using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2_DAC;

namespace Team2_Shop
{
    public class Service
    {        
        /// <summary>
        /// 정보가 맞는경우 아이디와 비밀번호를 가져옴
        /// </summary>
        /// <param name="id">유저의 아이디</param>
        /// <param name="pwd">유저의 비밀번호</param>
        public void CheckUser(string id, string pwd)
        {
            ShopDAC dAC = new ShopDAC();
            
        }        
    }
}