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
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace CourseProject
{
    class CompetitionInfoViewModel : INotifyPropertyChanged
    {
        private Comp selectedCompetition = new Comp();
        public Comp SelectedCompetition
        {
            get { return selectedCompetition; }
            set
            {
                selectedCompetition = value;
                OnPropertyChanged("SelectedCompetition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public CompetitionInfoViewModel(Comp comp)
        {
            selectedCompetition = comp;
        }
    }
}
