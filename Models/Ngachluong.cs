using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Ngachluong
    {
        public Ngachluong()
        {
            Thongtinluong = new HashSet<Thongtinluong>();
        }

        public string NlMa { get; set; }
        public string NlTen { get; set; }

        public virtual ICollection<Thongtinluong> Thongtinluong { get; set; }
    }
}
