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

        private RelayCommand createTemporarySportsman;
        public RelayCommand CreateTemporarySportsman
        {
            get
            {
                return createTemporarySportsman ??
                    (createTemporarySportsman = new RelayCommand(obj =>
                    {
                        TemporarySportsmanVisibility = true;
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
                        if (distance1.Participants == null)
                            distance1.Participants = new ObservableCollection<Sportsman>();

                        if (temporarySportsmanVisibility)
                        {
                            Distance1.Participants.Add(temporarySportsman);
                            MessageBox.Show("added" + distance1.Participants[0].Name);
                        }
                        else
                        {
                            distance1.Participants.Add(chosenSportsman);
                            MessageBox.Show("added" + chosenSportsman.Time);
                        }

                        //SetupRaces();
                    }));
            }
        }

        private void SetupRaces()
        {
            int counter = 0;
            int racenumber = 0;
            var SortedParticipants = from p in distance1.participants
                                     orderby p.Time descending
                                     select p;

            distance1.participants.Clear();
            foreach (var p in SortedParticipants)
            {
                racenumber++;
                counter = 0;
                while (counter < 9)
                {
                    p.Race = racenumber;
                    Distance1.participants.Add(p);
                    counter++;
                }
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
        public DistanceAddingViewModel(Frame frame)
        {
            WorkFrame = frame;
        }
    }
}
