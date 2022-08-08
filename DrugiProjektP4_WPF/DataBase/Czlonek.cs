﻿using System;
using System.Collections.Generic;

namespace DrugiProjektP4_WPF.DataBase
{
    public partial class Czlonek
    {
        public int IdCzlonek { get; set; }
        public string Czlonek1 { get; set; } = null!;
        public string? Rola { get; set; }
        public int IdWykonawca { get; set; }

        public virtual Wykonawca IdWykonawcaNavigation { get; set; } = null!;
    }
}
