using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Quanhuyen
    {
        public Quanhuyen()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string QhMa { get; set; }
        public string QhTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
