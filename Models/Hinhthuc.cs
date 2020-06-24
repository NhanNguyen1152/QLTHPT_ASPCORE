using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Hinhthuc
    {
        public Hinhthuc()
        {
            Thongtindaotao = new HashSet<Thongtindaotao>();
        }

        public string HtMa { get; set; }
        public string HtTen { get; set; }

        public virtual ICollection<Thongtindaotao> Thongtindaotao { get; set; }
    }
}
