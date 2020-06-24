using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Thietbigiangday
    {
        public Thietbigiangday()
        {
            Cosovatchat = new HashSet<Cosovatchat>();
        }

        public string TbgdMa { get; set; }
        public string TbgdTen { get; set; }

        public virtual ICollection<Cosovatchat> Cosovatchat { get; set; }
    }
}
