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
        private CollectionViewSource _plytySource;
        public MainWindow()
        {
            InitializeComponent();
            //_plytySource = (CollectionViewSource)FindResource(nameof(_plytySource));

        }


        private void view(object sender, RoutedEventArgs e)
        {
            var result = 
                from p in context.Plyta
                join n in context.Nabycies on p.IdNabycie equals n.IdNabycie
                select new {
                    IdPlyta = p.IdPlyta,
                    Nazwa = p.Nazwa,
                    Komentarz = p.Komentarz,
                    RodzajPlyty = p.RodzajPlyty,
                    StatusPosiadania = p.StatusPosiadania,
                    IdNabycie = p.IdPlyta,
                    DataNabycia = n.DataNabycia
                };

           // foreach (var item in result.ToList())
           // {
           //     Console.WriteLine(result.);
           // }

            PlytyDataGrid.ItemsSource = result.ToList();

            //context.Database.EnsureCreated();
            //context.Plyta.Load();
            //_plytySource.Source = context.Plyta.Local.ToObservableCollection();
        }
    }
}
