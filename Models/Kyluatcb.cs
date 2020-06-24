using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Kyluatcb
    {
        public Kyluatcb()
        {
            Canbo = new HashSet<Canbo>();
        }

        public string KlcbMa { get; set; }
        public string KlcbNgay { get; set; }
        public string KlcbHt { get; set; }

        public virtual ICollection<Canbo> Canbo { get; set; }
    }
}
