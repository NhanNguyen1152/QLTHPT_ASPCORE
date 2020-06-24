using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thongtinluong
    {
        public string TtlMa { get; set; }
        public string TtlNgaynhanluong { get; set; }
        public string TtlHesoluong { get; set; }
        public string BacluongBlMa { get; set; }
        public string NgachluongNlMa { get; set; }
        public string CanboCbMa { get; set; }

        public virtual Bacluong BacluongBlMaNavigation { get; set; }
        public virtual Canbo CanboCbMaNavigation { get; set; }
        public virtual Ngachluong NgachluongNlMaNavigation { get; set; }
    }
}
