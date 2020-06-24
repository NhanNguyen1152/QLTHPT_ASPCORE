using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Chitietdanhgia
    {
        public Chitietdanhgia()
        {
            Monhoc = new HashSet<Monhoc>();
        }

        public string CtdgMa { get; set; }
        public DateTime? CtdgNgaydg { get; set; }
        public string SodanhgiaSdgMa { get; set; }
        public string HocsinhHsMa { get; set; }

        public virtual Hocsinh HocsinhHsMaNavigation { get; set; }
        public virtual Sodanhgia SodanhgiaSdgMaNavigation { get; set; }
        public virtual ICollection<Monhoc> Monhoc { get; set; }
    }
}
