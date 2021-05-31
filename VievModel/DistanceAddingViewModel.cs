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
    class DistanceAddingViewModel : INotifyPropertyChanged
    {
        CPContext db = new CPContext();

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

        private Comp competition1 = new Comp();

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

        private Sportsman temporarySportsman = new Sportsman();
        public Sportsman TemporarySportsman
        {
            get { return temporarySportsman; }
            set
            {
                temporarySportsman = value;
                OnPropertyChanged("TemporarySportsman");
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

        private bool temporarySportsmanVisibility = false;
        public bool TemporarySportsmanVisibility
        {
            get { return temporarySportsmanVisibility; }
            set
            {
                temporarySportsmanVisibility = value;
                OnPropertyChanged("TemporarySportsmanVisibility");
            }
        }

        private bool savedSportsmenVisibility = true;
        public bool SavedSportsmenVisibility
        {
            get { return savedSportsmenVisibility; }
            set
            {
                savedSportsmenVisibility = value;
                OnPropertyChanged("SavedSportsmenVisibility");
            }
        }

        private RelayCommand createTemporarySportsman;
        public RelayCommand CreateTemporarySportsman
        {
            get
            {
                return createTemporarySportsman ??
                    (createTemporarySportsman = new RelayCommand(obj =>
                    {
                        TemporarySportsmanVisibility = true;
                        SavedSportsmenVisibility = false;
                    }));
            }
        }

        private RelayCommand saveSportsman;
        public RelayCommand SaveSportsman
        {
            get
            {
                return saveSportsman ??
                    (saveSportsman = new RelayCommand(obj =>
                    {
                        var r = new Sportsman();
                        if (distance1.Participants == null)
                            distance1.Participants = new ObservableCollection<Sportsman>();

                        if (temporarySportsmanVisibility)
                        {
                            r = temporarySportsman.Clone();
                            Distance1.Participants.Add(r);
                        }
                        else
                        {
                            if (distance1.participants.Contains(chosenSportsman))
                            {
                                MessageBox.Show("Такой участник уже добавлен");
                            }
                            else
                            {
                                chosenSportsman.Distances = new List<Distance>();
                                chosenSportsman.Distances.Add(distance1);
                                r = chosenSportsman.Clone();
                                chosenSportsman.Distances.Add(Distance1);
                                Distance1.Participants.Add(r);
                            }
                        }

                        distance1.SetupRaces();
                    }));
            }
        }

        private RelayCommand saveDistance;
        public RelayCommand SaveDistance
        {
            get
            {
                return saveDistance ??
                    (saveDistance = new RelayCommand(obj =>
                    {
                        if (distance1.participants == null)
                        {
                            MessageBox.Show("Нельзя создать дистанцию без участников");
                            return;
                        }
                        db.Distances.Add(distance1.CreateDBClone());
                        db.SaveChanges();
                        WorkFrame.GoBack();
                    }));
            }
        }

        private RelayCommand discardCreation;
        public RelayCommand DiscardCreation
        {
            get
            {
                return discardCreation ??
                    (discardCreation = new RelayCommand(obj =>
                    {
                        WorkFrame.GoBack();
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

        private Frame WorkFrame;
        public DistanceAddingViewModel(Frame frame, Comp competition, int length, string style)
        {
            WorkFrame = frame;
            distance1.competition = new Comp();
            distance1.competition = competition;
            distance1.length = length;
            distance1.style = style;
            var dBSportsmen = from s in db.Sportsmen
                              where s.name != ""
                              select s;
            foreach (var s in dBSportsmen)
            {
                if (s.Distances == null)
                    s.Distances = new List<DBDistance>();
                savedsportsmen.Add(s.SportsmanClone());
            }
        }
    }
}
