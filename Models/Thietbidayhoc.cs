using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thietbidayhoc
    {
        public Thietbidayhoc()
        {
            Cosovatchat = new HashSet<Cosovatchat>();
        }

        public string TbdhMa { get; set; }
        public string TbdhTen { get; set; }

        public virtual ICollection<Cosovatchat> Cosovatchat { get; set; }
    }
}
