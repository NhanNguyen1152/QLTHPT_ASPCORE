using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Namhoc
    {
        public Namhoc()
        {
            Sodanhgia = new HashSet<Sodanhgia>();
        }

        public string NhMa { get; set; }
        public string NhNamhoc { get; set; }

        public virtual ICollection<Sodanhgia> Sodanhgia { get; set; }
    }
}
