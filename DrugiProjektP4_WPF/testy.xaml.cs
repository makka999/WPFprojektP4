using DrugiProjektP4_WPF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrugiProjektP4_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy testy.xaml
    /// </summary>
    /// 
    public partial class testy : Window
    {
        private readonly KolekcjaPlytContext context = new KolekcjaPlytContext();

        public testy()
        {
            InitializeComponent();
            //_plytySource = (CollectionViewSource)FindResource(nameof(_plytySource));
            var result =
                from p in context.Plyta
                join n in context.Nabycies on p.IdNabycie equals n.IdNabycie
                select new wynik
                {
                    IdPlyta = p.IdPlyta,
                    Nazwa = p.Nazwa,
                    Komentarz = p.Komentarz,
                    RodzajPlyty = p.RodzajPlyty,
                    StatusPosiadania = p.StatusPosiadania,
                    IdNabycie = p.IdNabycie,
                    DataNabycia = n.DataNabycia.Value.ToShortDateString()
                };

            testyGrid.ItemsSource = result.ToList();
        }
        class wynik
        {
            public int IdPlyta { get; set; }
            public string Nazwa { get; set; }
            public string Komentarz { get; set; }
            public string RodzajPlyty { get; set; }
            public string StatusPosiadania { get; set; }
            public int? IdNabycie { get; set; }
            public string? DataNabycia { get; set; }


        }

        private void testyGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid db = sender as DataGrid;
            var a = db.SelectedItem as wynik;
            DetailsWindow detailsWindow = new DetailsWindow(a);
            detailsWindow.Show();
        }
    }
}
