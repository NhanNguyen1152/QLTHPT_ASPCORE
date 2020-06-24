using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Vanbang
    {
        public Vanbang()
        {
            Thongtindaotao = new HashSet<Thongtindaotao>();
        }

        public string VbMa { get; set; }
        public string VbTen { get; set; }

        public virtual ICollection<Thongtindaotao> Thongtindaotao { get; set; }
    }
}
