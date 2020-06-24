using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Coquan
    {
        public Coquan()
        {
            Canbo = new HashSet<Canbo>();
        }

        public string CqMa { get; set; }
        public string CqTen { get; set; }

        public virtual ICollection<Canbo> Canbo { get; set; }
    }
}
