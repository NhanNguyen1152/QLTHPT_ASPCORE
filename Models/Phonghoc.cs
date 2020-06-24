using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Phonghoc
    {
        public Phonghoc()
        {
            Cosovatchat = new HashSet<Cosovatchat>();
        }

        public string PhMa { get; set; }
        public string PhTen { get; set; }

        public virtual ICollection<Cosovatchat> Cosovatchat { get; set; }
    }
}
