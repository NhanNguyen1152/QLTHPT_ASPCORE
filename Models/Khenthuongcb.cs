using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Khenthuongcb
    {
        public Khenthuongcb()
        {
            Canbo = new HashSet<Canbo>();
        }

        public string KtcbMa { get; set; }
        public string KtcbNgay { get; set; }
        public string KtcbThanhtich { get; set; }

        public virtual ICollection<Canbo> Canbo { get; set; }
    }
}
