using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string MhMa { get; set; }
        public string MhTen { get; set; }
        public string ChitietdanhgiaCtdgMa { get; set; }

        public virtual Chitietdanhgia ChitietdanhgiaCtdgMaNavigation { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
