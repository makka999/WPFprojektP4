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
        private readonly KolekcjaPlytContext contextForPlyta = new KolekcjaPlytContext();

        public static Plytum UsedPlyta { get; private set; }
        public static Utwor ResetMemory { get; private set; }

        public DetailsWindow(object _selectPlyta)
        {
            InitializeComponent();

            var _plyta = _selectPlyta as Plytum;
            UsedPlyta = _plyta;
            var result = context.Utwors.Where(p => p.IdPlyta == _plyta.IdPlyta);
            //ResetMemory = (Utwor)result;
            UtworDataGrid.ItemsSource = result.ToList();

            var plytaModyfi = contextForPlyta.Plyta.Where(p => p.IdPlyta == _plyta.IdPlyta);
            PlytyModyfiDataGrid.ItemsSource = plytaModyfi.ToList();

            List<Wykonawca> wykonawcas = context.Wykonawcas.ToList();
            ComboBoxWykonawca.ItemsSource = wykonawcas;
            ComboBoxWykonawca.DisplayMemberPath = "Wykonawca1";
            ComboBoxWykonawca.SelectedValuePath = "IdWykonawca";
            

            //object zespoly = context.Wykonawcas;
            //var wykonaw = zespoly as Wykonawca;
            //ComboBoxWykonawca.ItemsSource = wykonaw.Wykonawca1.ToList();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();

            UtworDataGrid.Items.Refresh();
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            //var result = context.Utwors.Where(p => p.IdPlyta == UsedPlyta.IdPlyta);
            //UtworDataGrid.ItemsSource = null;
            //UtworDataGrid.ItemsSource = result.ToList();
            //UtworDataGrid.ItemsSource = ResetMemory;
            //UtworDataGrid.Items.Clear();
            UtworDataGrid.Items.Refresh();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var tytul = TytulBox.Text;
            var gatunek = GarynekBox.Text;

            //ComboBoxItem idwykonawca = (ComboBoxItem)ComboBoxWykonawca.SelectedItem;
            //int wykonawca = Convert.ToInt16(idwykonawca);
            //var wykonawca = Convert.ToInt32(ComboBoxWykonawca.SelectedValuePath);
            //if (ComboBoxWykonawca.SelectedValuePath != null)
            //{
            //    wykonawca = ComboBoxWykonawca.SelectedValue;
            //}

            using (var _context = new KolekcjaPlytContext())
            {
                var addUtwor = new Utwor
                {
                    Tytul = tytul,
                    GatunekMuzyczny = gatunek,
                    IdPlyta = UsedPlyta.IdPlyta,
                    IdWykonawca =  (int)ComboBoxWykonawca.SelectedValue
                };
                _context.Utwors.Add(addUtwor);
                _context.SaveChanges();

                var result = context.Utwors.Where(p => p.IdPlyta == addUtwor.IdPlyta);

                UtworDataGrid.ItemsSource = result.ToList();


            }

        }

        private void Button_ModPlyta(object sender, RoutedEventArgs e)
        {
            contextForPlyta.SaveChanges();
        }


        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            string txt = sender as string;


        }
    }
}
