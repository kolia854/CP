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
    class CompetitionAddingViewModel : INotifyPropertyChanged
    {
        private Comp competition1 = new Comp();
        public Comp Competition1
        {
            get { return competition1; }
            set
            {
                competition1 = value;
                OnPropertyChanged("Competition1");
            }
        }

        private Distance distance1 = new Distance();
        public Distance Distance1
        {
            get { return distance1; }
            set
            {
                distance1 = value;
                OnPropertyChanged("Distance1");
            }
        }

        private ObservableCollection<Distance> savedDistances = new ObservableCollection<Distance>();
        public ObservableCollection<Distance> SavedDistances
        {
            get { return savedDistances; }
            set
            {
                savedDistances = value;
                OnPropertyChanged("SavedDistances");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        savedDistances.Add(distance1);
                    }));
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
    }
}
