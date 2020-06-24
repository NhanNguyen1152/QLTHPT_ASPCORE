using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Hocky
    {
        public Hocky()
        {
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string HkMa { get; set; }
        public string HkTen { get; set; }

        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
