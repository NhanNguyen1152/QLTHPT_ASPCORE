using System;
using System.Collections.Generic;

namespace QLTHPT.Models
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            ChitietChucvu = new HashSet<ChitietChucvu>();
        }

        public string CvMa { get; set; }
        public string CvTen { get; set; }

        public virtual ICollection<ChitietChucvu> ChitietChucvu { get; set; }
    }
}
