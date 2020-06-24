using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Khoi
    {
        public Khoi()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string KhoiMa { get; set; }
        public string KhoiTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
