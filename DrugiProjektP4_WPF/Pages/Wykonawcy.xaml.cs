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
    /// Logika interakcji dla klasy Wykonawcy.xaml
    /// </summary>
    public partial class Wykonawcy : Window
    {
        private readonly KolekcjaPlytContext context = new KolekcjaPlytContext();
        public int? WybranyWykonawca;
        public Wykonawcy()
        {
            InitializeComponent();
            List<Wykonawca> wykonawcas = context.Wykonawcas.ToList();
            ComboBoxWykonawca.ItemsSource = wykonawcas;
            ComboBoxWykonawca.DisplayMemberPath = "Wykonawca1";
            ComboBoxWykonawca.SelectedValuePath = "IdWykonawca";
            ComboBoxWykonawca.SelectedIndex = 1;
        }
        private void ComboBoxWykonawca_GotMouseCapture(object sender, MouseEventArgs e)
        {
            List<Wykonawca> wykonawcas = context.Wykonawcas.ToList();
            ComboBoxWykonawca.ItemsSource = wykonawcas;
            ComboBoxWykonawca.DisplayMemberPath = "Wykonawca1";
            ComboBoxWykonawca.SelectedValuePath = "IdWykonawca";
        }


        private void ComboBoxWykonawca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WybranyWykonawca = (int)ComboBoxWykonawca.SelectedValue;
            var result = context.Czloneks.Where(c => c.IdWykonawca == WybranyWykonawca).ToList();
            CzlonekDataGrid.ItemsSource = result;
        }

        private void Button_ClickDodajWykonawce(object sender, RoutedEventArgs e)
        {
            var wykonawca = BoxWykonawca.Text;
            if (string.IsNullOrEmpty(wykonawca))
            {
                MessageBox.Show("Nie podales wykonawcy");
            }
            else
            {
                using (var _context = new KolekcjaPlytContext())
                {
                    var addWykonawca = new Wykonawca
                    {
                        Wykonawca1 = wykonawca
                    };
                    _context.Wykonawcas.Add(addWykonawca);
                    _context.SaveChanges();

                }
            }
        }

        private void Button_ClickDodajCzlonka(object sender, RoutedEventArgs e)
        {
            var nazwa = BoxNazwa.Text;
            var rola = BoxRola.Text;

            if (string.IsNullOrEmpty(nazwa))
            {
                MessageBox.Show("Nie podales artysty");
            }
            else
            { 
                using (var _context = new KolekcjaPlytContext())
                {
                    var addCzlonek = new Czlonek
                    {
                        Czlonek1 = nazwa,
                        Rola = rola,
                        IdWykonawca = (int)WybranyWykonawca

                    };
                    _context.Czloneks.Add(addCzlonek);
                    _context.SaveChanges();

                }

                var result = context.Czloneks.Where(c => c.IdWykonawca == WybranyWykonawca).ToList();
                CzlonekDataGrid.ItemsSource = result;
            }

            
        }
    }
}
