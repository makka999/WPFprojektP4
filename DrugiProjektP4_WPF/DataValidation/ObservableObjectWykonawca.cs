using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjektP4_WPF.DataValidation
{
    public class ObservableObjectWykonawca : ObservableObject
    {
        private string _boxWykonawca;
        public string boxWykonawca
        {
            get { return _boxWykonawca; }
            set
            {
                OnPropertyChanged(ref _boxWykonawca, value);
            }
        }

        private string _boxNazwa;
        public string boxNazwa
        {
            get { return _boxNazwa; }
            set
            {
                OnPropertyChanged(ref _boxNazwa, value);
            }
        }

        private string _boxRola;
        public string boxRola
        {
            get { return _boxRola; }
            set
            {
                OnPropertyChanged(ref _boxRola, value);
            }
        }
    }
}
