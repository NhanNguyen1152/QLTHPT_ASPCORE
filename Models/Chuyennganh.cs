using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Chuyennganh
    {
        public Chuyennganh()
        {
            Thongtindaotao = new HashSet<Thongtindaotao>();
        }

        public string CnMa { get; set; }
        public string CnTen { get; set; }

        public virtual ICollection<Thongtindaotao> Thongtindaotao { get; set; }
    }
}
