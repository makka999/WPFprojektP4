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
    /// Logika interakcji dla klasy DetailsWindow.xaml
    /// </summary>



    public partial class DetailsWindow : Window
    {
        private readonly KolekcjaPlytContext context = new KolekcjaPlytContext();
        public static Plytum UsedPlyta { get; private set; }
        public DetailsWindow(object _selectPlyta)
        {
            InitializeComponent();

            var _plyta = _selectPlyta as Plytum;
            UsedPlyta = _plyta;
            var result = context.Utwors.Where(p => p.IdPlyta == _plyta.IdPlyta);

            UtworDataGrid.ItemsSource = result.ToList();
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();

            UtworDataGrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UtworDataGrid.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var tytul = TytulBox.Text;
            var gatunek = GarynekBox.Text;
            

            using (var _context = new KolekcjaPlytContext())
            {
                var addUtwor = new Utwor
                {
                    Tytul = tytul,
                    GatunekMuzyczny = gatunek,
                    IdPlyta = UsedPlyta.IdPlyta,
                    IdWykonawca = 1
                };
                _context.Utwors.Add(addUtwor);
                _context.SaveChanges();

                var result = context.Utwors.Where(p => p.IdPlyta == addUtwor.IdPlyta);

                UtworDataGrid.ItemsSource = result.ToList();


            }
            //{
            //    var addPlyta = new Plytum
            //    {
            //        Nazwa = "sa",
            //        RodzajPlyty = "asasaas",

            //        StatusPosiadania = "Dodana z wpf",

            //    };
            //    _context.Plyta.Add(addPlyta);
            //   // _context.Plyta.Load();
            //    _context.SaveChanges();
            //}
        }
    }
}
