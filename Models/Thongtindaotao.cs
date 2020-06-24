using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thongtindaotao
    {
        public string TtdtMa { get; set; }
        public string HinhthucsHtMa { get; set; }
        public string ChuyennganhCnMa { get; set; }
        public string VanbangVbMa { get; set; }
        public string CanboCbMa { get; set; }

        public virtual Canbo CanboCbMaNavigation { get; set; }
        public virtual Chuyennganh ChuyennganhCnMaNavigation { get; set; }
        public virtual Hinhthuc HinhthucsHtMaNavigation { get; set; }
        public virtual Vanbang VanbangVbMaNavigation { get; set; }
    }
}
