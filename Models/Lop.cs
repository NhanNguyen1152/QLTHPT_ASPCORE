using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Lop
    {
        public Lop()
        {
            Hocsinh = new HashSet<Hocsinh>();
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string LopMa { get; set; }
        public string LopTen { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
