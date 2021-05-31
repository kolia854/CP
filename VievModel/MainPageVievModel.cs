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
    public class MainViewModel : INotifyPropertyChanged 
    {
        private Frame WorkFrame;
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

        private List<Comp> savedCompetitions = new List<Comp>();
        public List<Comp> SavedCompetitions
        {
            get { return savedCompetitions; }
            set
            {
                savedCompetitions = value;
                OnPropertyChanged("SavedCompetitions");
            }
        }

        //private RelayCommand delete;          не работает (связи)
        //public RelayCommand Delete
        //{
        //    get
        //    {
        //        return delete ??
        //            (delete = new RelayCommand(obj =>
        //            {
        //                if (selectedCompetition != null)
        //                {
        //                    using (CPContext db = new CPContext())
        //                    {
        //                        var toremove = from s in db.Competitions
        //                                       where s.DBCompID == selectedCompetition.CompID
        //                                       select s;
        //                        foreach (var s in toremove)
        //                        {
        //                            db.Competitions.Remove(s);
        //                        }
        //                        db.SaveChanges();
        //                        savedCompetitions.Remove(SelectedCompetition);
        //                    }
        //                }
        //                else
        //                    MessageBox.Show("Выберите в списке соревнование");
        //            }));
        //    }
        //}

        private RelayCommand openCompetitionInfoPage;
        public RelayCommand OpenCompetitionInfoPage
        {
            get
            {
                return openCompetitionInfoPage ??
                    (openCompetitionInfoPage = new RelayCommand(obj =>
                    {
                        if (selectedCompetition != null)
                            WorkFrame.Navigate(new CompetitionInfo(selectedCompetition));
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

        public MainViewModel(Frame frame)
        {
            using (CPContext db = new CPContext())
            {
                WorkFrame = frame;
                var sc = (from c in db.Competitions
                          select c).ToList();
                foreach (var c in sc)
                {
                    savedCompetitions.Add(c.Clone());
                }
            }
        }
    }
}
