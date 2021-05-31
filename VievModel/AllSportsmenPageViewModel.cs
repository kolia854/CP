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
    class AllSportsmenPageViewModel : INotifyPropertyChanged
    {
        private Frame WorkFrame;
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

        private Sportsman chosenSportsman = new Sportsman();
        public Sportsman ChosenSportsman
        {
            get { return chosenSportsman; }
            set
            {
                chosenSportsman = value;
                OnPropertyChanged("ChosenSportsman");
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private RelayCommand openInfo;
        public RelayCommand OpenInfo
        {
            get
            {
                return openInfo ??
                    (openInfo = new RelayCommand(obj =>
                    {
                        if (chosenSportsman != null)
                            WorkFrame.Navigate(new Sportsmen(WorkFrame, chosenSportsman));
                        else
                            MessageBox.Show("Выберите в списке спортмена");
                    }));
            }
        }

        private RelayCommand delete;
        public RelayCommand Delete
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(obj =>
                    {
                        if (chosenSportsman != null)
                        {
                            using (CPContext db = new CPContext())
                            {
                                var toremove = from s in db.Sportsmen
                                                  where s.DBSportsmanID == chosenSportsman.ID
                                        select s;
                                foreach (var s in toremove)
                                {
                                    db.Sportsmen.Remove(s);
                                }
                                db.SaveChanges();
                                savedsportsmen.Remove(chosenSportsman);
                            }
                        }
                        else
                            MessageBox.Show("Выберите в списке спортмена");
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

        public AllSportsmenPageViewModel(Frame frame)
        {
            WorkFrame = frame;
            using (CPContext db = new CPContext())
            {
                var dBSportsmen = from s in db.Sportsmen
                                  where s.name != ""
                                  select s;
                foreach(var s in dBSportsmen)
                {
                    savedsportsmen.Add(s.SportsmanClone());
                }
            }
        }
    }
}
