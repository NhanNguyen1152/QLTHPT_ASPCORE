using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Bacluong
    {
        public Bacluong()
        {
            Thongtinluong = new HashSet<Thongtinluong>();
        }

        public string BlMa { get; set; }
        public string BlTen { get; set; }

        public virtual ICollection<Thongtinluong> Thongtinluong { get; set; }
    }
}
