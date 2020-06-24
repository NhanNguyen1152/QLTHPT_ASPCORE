using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Sodanhgia
    {
        public Sodanhgia()
        {
            Chitietdanhgia = new HashSet<Chitietdanhgia>();
        }

        public string SdgMa { get; set; }
        public string SdgDiem { get; set; }
        public string SdgGhichu { get; set; }
        public string NamhocNhMa { get; set; }

        public virtual Namhoc NamhocNhMaNavigation { get; set; }
        public virtual ICollection<Chitietdanhgia> Chitietdanhgia { get; set; }
    }
}
