using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Canbo
    {
        public Canbo()
        {
            ChitietChucvu = new HashSet<ChitietChucvu>();
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
            Thongtindaotao = new HashSet<Thongtindaotao>();
            Thongtinluong = new HashSet<Thongtinluong>();
        }

        public string CbMa { get; set; }
        public string CbHoten { get; set; }
        public string CbGioitinh { get; set; }
        public string CbDiachi { get; set; }
        public DateTime? CbNgaysinh { get; set; }
        public string CbCmnd { get; set; }
        public string CoquanCqMa { get; set; }
        public string KyluatcbKlcbMa { get; set; }
        public string KhenthuongcbKtcbMa { get; set; }

        public virtual Coquan CoquanCqMaNavigation { get; set; }
        public virtual Khenthuongcb KhenthuongcbKtcbMaNavigation { get; set; }
        public virtual Kyluatcb KyluatcbKlcbMaNavigation { get; set; }
        public virtual ICollection<ChitietChucvu> ChitietChucvu { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
        public virtual ICollection<Thongtindaotao> Thongtindaotao { get; set; }
        public virtual ICollection<Thongtinluong> Thongtinluong { get; set; }
    }
}
