using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}