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
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CourseProject
{
    public class SA_VievModel : INotifyPropertyChanged
    {
        private Sportsman sportsman1 = new Sportsman();
        public Sportsman Sportsman1
        {
            get { return sportsman1; }
            set
            {
                sportsman1 = value;
                OnPropertyChanged("Sportsman1");
            }
        }

        private ObservableCollection<Sportsman> savedsportsmen = new ObservableCollection<Sportsman>();
        public ObservableCollection<Sportsman> SavedSportsmen
        {
            get { return savedsportsmen; }
            set
            {
                savedsportsmen = value;
                OnPropertyChanged("SavedSportsmen");
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
                        using (CPContext db = new CPContext())
                        {
                            sportsman1.Distances = new List<Distance>();
                            var v = new Validation();
                            var errors = v.Validate(sportsman1);
                            if (errors == null)
                            {
                                var clone = sportsman1.CreateDBClone();
                                SavedSportsmen.Add(sportsman1);
                                db.Sportsmen.Add(clone);
                                db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show(errors);
                            }
                        }
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
