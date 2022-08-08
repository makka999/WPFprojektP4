using System;
using System.Collections.Generic;

namespace DrugiProjektP4_WPF.DataBase
{
    public partial class Wykonawca
    {
        public Wykonawca()
        {
            Czloneks = new HashSet<Czlonek>();
            Utwors = new HashSet<Utwor>();
        }

        public int IdWykonawca { get; set; }
        public string Wykonawca1 { get; set; } = null!;

        public virtual ICollection<Czlonek> Czloneks { get; set; }
        public virtual ICollection<Utwor> Utwors { get; set; }
    }
}
