using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Kyluat
    {
        public Kyluat()
        {
            Hocsinh = new HashSet<Hocsinh>();
        }

        public string KlMa { get; set; }
        public string KlHinhthuc { get; set; }
        public DateTime? KlNgaykyluat { get; set; }

        public virtual ICollection<Hocsinh> Hocsinh { get; set; }
    }
}
