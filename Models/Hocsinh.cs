using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Hocsinh
    {
        public Hocsinh()
        {
            Chitietdanhgia = new HashSet<Chitietdanhgia>();
        }

        public string HsMa { get; set; }
        public string HsHoten { get; set; }
        public string HsGioitinh { get; set; }
        public DateTime HsNgaysinh { get; set; }
        public string HsTongiao { get; set; }
        public string TinhthanhTtMa { get; set; }
        public string XaphuongXpMa { get; set; }
        public string KyluatKlMa { get; set; }
        public string KhenthuongKtMa { get; set; }
        public string QuanhuyenQhMa { get; set; }
        public string DantocDtMa { get; set; }
        public string LopLopMa { get; set; }
        public string KhoiKhoiMa { get; set; }

        public virtual Dantoc DantocDtMaNavigation { get; set; }
        public virtual Khenthuong KhenthuongKtMaNavigation { get; set; }
        public virtual Khoi KhoiKhoiMaNavigation { get; set; }
        public virtual Kyluat KyluatKlMaNavigation { get; set; }
        public virtual Lop LopLopMaNavigation { get; set; }
        public virtual Quanhuyen QuanhuyenQhMaNavigation { get; set; }
        public virtual Tinhthanh TinhthanhTtMaNavigation { get; set; }
        public virtual Xaphuong XaphuongXpMaNavigation { get; set; }
        public virtual ICollection<Chitietdanhgia> Chitietdanhgia { get; set; }
    }
}
