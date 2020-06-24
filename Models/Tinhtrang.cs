using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Tinhtrang
    {
        public Tinhtrang()
        {
            Cosovatchat = new HashSet<Cosovatchat>();
        }

        public string TtMa { get; set; }
        public string TtMota { get; set; }

        public virtual ICollection<Cosovatchat> Cosovatchat { get; set; }
    }
}
