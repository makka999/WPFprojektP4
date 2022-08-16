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
        
        // private CollectionViewSource _plytySource;
        public MainWindow()
        {
            InitializeComponent();
            //_plytySource = (CollectionViewSource)FindResource(nameof(_plytySource));
            //Plytum plyta = new Plytum();
            var plyta = context.Plyta;



            PlytyDataGrid.ItemsSource = plyta.ToList();

        }



        private void PlytyDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var select = dg.SelectedItem as Plytum;
            DetailsWindow detailsWindow = new DetailsWindow(select);
            detailsWindow.Show();
            // DataGrid db = sender as DataGrid;
            // var a = db.SelectedItem as wynik;
            // DetailsWindow detailsWindow = new DetailsWindow(a.IdPlyta);
            // detailsWindow.Show();
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

            var addPlyta = new Plytum
            {
                Nazwa = "sa",
                RodzajPlyty = "asasaas",

                StatusPosiadania = "Dodana z wpf"

            };
            context.Plyta.Add(addPlyta);
            // _context.Plyta.Load();
            context.SaveChanges();

            //int idNabyciaAdd = addNabycie.IdNabycie;

            //using (var _context = new KolekcjaPlytContext())
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
            //var addPlyta = new Plytum();
                
            //addPlyta.Nazwa = Convert.ToString(nazwa);
            //addPlyta.RodzajPlyty = Convert.ToString(nazwa);
            //addPlyta.IdNabycie = idNabyciaAdd;
            //addPlyta.StatusPosiadania = "Dodana z wpf";

            //context.Plyta.Add(addPlyta);
            //context.SaveChanges();
            
            PlytyDataGrid.Items.Refresh();
        }


        //private void view(object sender, RoutedEventArgs e)
        // {
        //  var result = 
        //      from p in context.Plyta
        //      join n in context.Nabycies on p.IdNabycie equals n.IdNabycie
        //      select new {
        //          IdPlyta = p.IdPlyta,
        //          Nazwa = p.Nazwa,
        //          Komentarz = p.Komentarz,
        //          RodzajPlyty = p.RodzajPlyty,
        //          StatusPosiadania = p.StatusPosiadania,
        //          IdNabycie = p.IdPlyta,
        //          DataNabycia = n.DataNabycia
        //      };
        //
        //  PlytyDataGrid.ItemsSource = result.ToList();
        // foreach (var item in result.ToList())
        // {
        //     Console.WriteLine(result.);
        // }



        //context.Database.EnsureCreated();
        //context.Plyta.Load();
        //_plytySource.Source = context.Plyta.Local.ToObservableCollection();
        //}
    }
}
