using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLTHPT.Models
{
    public partial class Login 
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
       
    }
}