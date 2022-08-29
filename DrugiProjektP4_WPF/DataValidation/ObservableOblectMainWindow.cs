using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjektP4_WPF
{
    public class ObservableOblectMainWindow : ObservableObject
    {
        private string _dataNabyciaBox;
        public string dataNabyciaBox
        {
            get { return _dataNabyciaBox; }
            set
            {
                OnPropertyChanged(ref _dataNabyciaBox, value);
            }
        }

        private string _nazwaBox;
        public string nazwaBox
        {
            get { return _nazwaBox; }
            set
            {
                OnPropertyChanged(ref _nazwaBox, value);
            }
        }

        private string _rodzajPlytyBox;
        public string rodzajPlytyBox
        {
            get { return _rodzajPlytyBox; }
            set
            {
                OnPropertyChanged(ref _rodzajPlytyBox, value);
            }
        }

    }
}
