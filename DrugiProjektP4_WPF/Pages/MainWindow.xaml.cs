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
using DrugiProjektP4_WPF.DataValidation;

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
            detailsWindow.Closed += DetailsWindow_Closed;
            detailsWindow.Show();
        }

        private void DetailsWindow_Closed(object? sender, EventArgs e)
        {
            KolekcjaPlytContext _context = new KolekcjaPlytContext();
            var plyta = _context.Plyta;
            PlytyDataGrid.ItemsSource = plyta.ToList();
        }

        private void Botton_AddPlyty(object sender, RoutedEventArgs e)
        {
            var dataNabycia = DataNabyciaBox.Text;
            var cena = CenaBox.Text;
            var nazwa = NazwaBox.Text;
            var rodzajPlyty = RodzajPlytyBox.Text;

            if (!string.IsNullOrEmpty(Convert.ToString(dataNabycia)))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cena)))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(nazwa)))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(rodzajPlyty)))
                        {
                            var addNabycie = new Nabycie
                            {
                                Cena = Convert.ToDecimal(cena),
                                DataNabycia = Convert.ToDateTime(dataNabycia)
                            };

                            context.Nabycies.Add(addNabycie);
                            context.SaveChanges();

                            var addPlyta = new Plytum
                            {
                                Nazwa = nazwa,
                                RodzajPlyty = rodzajPlyty,
                                Komentarz = null,
                                StatusPosiadania = "z wpf",
                                IdNabycie = addNabycie.IdNabycie

                            };

                            context.Plyta.Add(addPlyta);
                            context.SaveChanges();
                            var plyta = context.Plyta;
                            PlytyDataGrid.ItemsSource = plyta.ToList();
                            PlytyDataGrid.Items.Refresh();
                        }
                        else MessageBox.Show("Brak rodzaju plyty");
                    }
                    else MessageBox.Show("Brak nazwy");
                }
                else MessageBox.Show("Brak ceny");
            }
            else MessageBox.Show("Brak daty");
        }

    }
}
