using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Dantoc
    {
        public Dantoc()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string DtMa { get; set; }
        public string DtTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
