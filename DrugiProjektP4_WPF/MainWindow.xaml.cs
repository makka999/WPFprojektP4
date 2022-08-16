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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrugiProjektP4_WPF.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DrugiProjektP4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        
        private readonly KolekcjaPlytContext context = new KolekcjaPlytContext();
        

        public MainWindow()
        {
            InitializeComponent();
            var plyta = context.Plyta;
            PlytyDataGrid.ItemsSource = plyta.ToList();
        }

        private void PlytyDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var select = dg.SelectedItem as Plytum;
            DetailsWindow detailsWindow = new DetailsWindow(select);
            detailsWindow.Show();
        }

        private void Botton_AddPlyty(object sender, RoutedEventArgs e)
        {
            var dataNabycia = DataNabyciaBox.Text;
            var cena = CenaBox.Text;
            var nazwa = NazwaBox.Text;
            var rodzajPlyty = RodzajPlytyBox.Text;
            //cena = Convert.ToDecimal(cena);
            //var addNabycie = new Nabycie();
            //addNabycie.Cena = Convert.ToDecimal(cena);
            //addNabycie.DataNabycia = Convert.ToDateTime(dataNabycia);


            //using (var _context = new KolekcjaPlytContext())
            //{
            //    var addNabycie = new Nabycie
            //    {
            //        Cena = Convert.ToDecimal(cena),
            //        DataNabycia = Convert.ToDateTime(dataNabycia)
            //    };
            //    _context.Add(addNabycie);
            //    _context.SaveChanges();
            //}
            //context.Nabycies.Add(addNabycie);
            //context.SaveChanges();

            //var addPlyta = new Plytum
            //{
            //    Nazwa = "sa",
            //    RodzajPlyty = "asasaas",
            //    Komentarz = "abyby",
            //    StatusPosiadania = "Dodanawpf",  //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    IdNabycie = 19

            //};
            //context.Plyta.Add(addPlyta);

            //context.SaveChanges();

            //int idNabyciaAdd = addNabycie.IdNabycie;

            using (var _context = new KolekcjaPlytContext())
            {
                var addPlyta = new Plytum
                {
                    Nazwa = "sa",
                    RodzajPlyty = "asass",
                    Komentarz = "abybyl",
                    StatusPosiadania = "Dodazwpf",
                    IdNabycie = 12
                };
                _context.Plyta.Add(addPlyta);
               // _context.Plyta.Load();
                _context.SaveChanges();
            }
            //var addPlyta = new Plytum();
                
            //addPlyta.Nazwa = Convert.ToString(nazwa);
            //addPlyta.RodzajPlyty = Convert.ToString(nazwa);
            //addPlyta.IdNabycie = idNabyciaAdd;
            //addPlyta.StatusPosiadania = "Dodana z wpf";

            //context.Plyta.Add(addPlyta);
            //context.SaveChanges();
            
            PlytyDataGrid.Items.Refresh();
        }

    }
}
