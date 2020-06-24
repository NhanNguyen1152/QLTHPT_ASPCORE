using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Khenthuong
    {
        public Khenthuong()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string KtMa { get; set; }
        public string KtThanhtich { get; set; }
        public DateTime? KtNgaykhenthuong { get; set; }
        public string KtGhichu { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
