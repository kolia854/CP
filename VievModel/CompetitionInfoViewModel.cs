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

        private ObservableCollection<CompetitionResults> results = new ObservableCollection<CompetitionResults>();
        public ObservableCollection<CompetitionResults> Results
        {
            get { return results; }
            set
            {
                results = value;
                OnPropertyChanged("Results");
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
            using (CPContext db = new CPContext())
            {
                var distancesinfo = (from d in db.Distances
                                     where d.competition.DBCompID == selectedCompetition.CompID
                                     select new
                                     {
                                         Style = d.Style,
                                         Length = d.Length,
                                         Patricipants = d.Participants.Count()
                                     }).ToList();
                foreach (var s in distancesinfo)
                {
                    var res = new CompetitionResults();
                    res.Length = s.Length;
                    res.ParticipantsCount = s.Patricipants;
                    res.Style = s.Style;
                    results.Add(res);
                }
            }
            
        }
    }
}
