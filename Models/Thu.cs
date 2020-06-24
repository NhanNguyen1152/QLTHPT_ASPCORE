using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thu
    {
        public Thu()
        {
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string ThuMa { get; set; }
        public string ThuTen { get; set; }

        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
