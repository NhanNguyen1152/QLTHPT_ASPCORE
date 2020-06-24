using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thoikhoabieu
    {
        public string TkbMa { get; set; }
        public string LopLopMa { get; set; }
        public string MonhocMhMa { get; set; }
        public string ThuThuMa { get; set; }
        public string TiethocThMa { get; set; }
        public string CanboCbMa { get; set; }
        public string HockyHkMa { get; set; }

        public virtual Canbo CanboCbMaNavigation { get; set; }
        public virtual Hocky HockyHkMaNavigation { get; set; }
        public virtual Lop LopLopMaNavigation { get; set; }
        public virtual Monhoc MonhocMhMaNavigation { get; set; }
        public virtual Thu ThuThuMaNavigation { get; set; }
        public virtual Tiethoc TiethocThMaNavigation { get; set; }
    }
}
