using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Tinhthanh
    {
        public Tinhthanh()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string TtMa { get; set; }
        public string TtTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
