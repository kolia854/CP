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
    class SportsmenPageViewModel : INotifyPropertyChanged
    {
        private Frame WorkFrame;
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

        private List<SportsmanResults> results = new List<SportsmanResults>();
        public List<SportsmanResults> Results
        {
            get { return results; }
            set
            {
                results = value;
                OnPropertyChanged("Results");
            }
        }

        public SportsmenPageViewModel(Frame frame, Sportsman sportsman)
        {

            chosenSportsman = sportsman;
            WorkFrame = frame;
            using (CPContext db = new CPContext())
            {
                var _results = (from d in db.Distances
                                where d.Participants.Any(s => s.DBSportsmanID == chosenSportsman.ID)
                                select new 
                                {
                                    Name = d.competition.name,
                                    Date = d.competition.date,
                                    Style = d.Style,
                                    Length = d.Length
                                }).ToList();
                foreach(var res in _results)
                {
                    var a = new SportsmanResults();
                    a.CompetitionName = res.Name;
                    a.Date = res.Date;
                    a.DistanceStyle = res.Style;
                    a.DistanceLength = res.Length;
                    results.Add(a);
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
    }
}
