using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Cosovatchat
    {
        public string CsvcMa { get; set; }
        public int CsvcSoluong { get; set; }
        public string PhonghocPhMa { get; set; }
        public string ThietbigiangdayTbgdMa { get; set; }
        public string ThietbidayhocTbdhMa { get; set; }
        public string TinhtrangTtMa { get; set; }

        public virtual Phonghoc PhonghocPhMaNavigation { get; set; }
        public virtual Thietbidayhoc ThietbidayhocTbdhMaNavigation { get; set; }
        public virtual Thietbigiangday ThietbigiangdayTbgdMaNavigation { get; set; }
        public virtual Tinhtrang TinhtrangTtMaNavigation { get; set; }
    }
}
