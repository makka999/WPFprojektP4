using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjektP4_WPF.DataValidation
{
    public class ObservableObjectDetalisWindow : ObservableObject
    {
        private string _tytulBox;
        public string tytulBox
        {
            get { return _tytulBox; }
            set
            {
                OnPropertyChanged(ref _tytulBox, value);
            }
        }

        private string _garynekBox;
        public string garynekBox
        {
            get { return _garynekBox; }
            set
            {
                OnPropertyChanged(ref _garynekBox, value);
            }
        }
    }
}
