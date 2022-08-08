using System;
using System.Collections.Generic;

namespace DrugiProjektP4_WPF.DataBase
{
    public partial class Nabycie
    {
        public int IdNabycie { get; set; }
        public DateTime? DataNabycia { get; set; }
        public decimal? Cena { get; set; }

        public virtual Plytum? Plytum { get; set; }
    }
}
