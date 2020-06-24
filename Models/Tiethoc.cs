using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Tiethoc
    {
        public Tiethoc()
        {
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string ThMa { get; set; }
        public string ThTen { get; set; }

        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
