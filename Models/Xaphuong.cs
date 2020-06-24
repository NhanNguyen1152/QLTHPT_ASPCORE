using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Xaphuong
    {
        public Xaphuong()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string XpMa { get; set; }
        public string XpTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
