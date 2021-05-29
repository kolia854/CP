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
        private DBSportsman chosenSportsman = new DBSportsman();
        public DBSportsman ChosenSportsman
        {
            get { return chosenSportsman; }
            set
            {
                chosenSportsman = value;
                OnPropertyChanged("ChosenSportsman");
            }
        }

        public SportsmenPageViewModel()
        {
            using (CPContext db = new CPContext())
            {
                //var dislis = from a in db.Competitions
                //             from aa in a.distances
                //             from aaa in aa.Participants
                //             select aaa;

                //List results = new List();
                //IQueryable result;
                //var dis = db.Distances.Where(d => d.Participants.Contains(chosenSportsman));
                //foreach (var a in dis)
                //{
                //    var sor = db.Competitions.Where(c => c.distances.Contains(a.DBDistanceID => ()));
                //    result = dis.Join(sor,
                //        x => x.DBDistanceID,
                //        y => y.distances,
                //        (x, y) => new
                //        {
                //            CompName = y.name,
                //            CompDate = y.date,
                //            Price = x.Length

                //        });

                //}

                //        foreach (var s in dis)
                //        {
                //            //var result =
                //            //    db.Distances.Where(d => d.Participants.Contains(chosenSportsman)).Join(db.Competitions.Where(c => c.distances.Contains(s)),
                //            //    a => a.DBDistanceID,
                //            //    b => b.distances => )
                //        }
                ////            var phones = db.Phones.Join(db.Companies, // второй набор
                //          p => p.CompanyId, // свойство-селектор объекта из первого набора
                //          c => c.Id, // свойство-селектор объекта из второго набора
                //          (p, c) => new // результат
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

        public SportsmenPageViewModel(Frame frame, Sportsman sportsman)
        {
            WorkFrame = frame;
            chosenSportsman = sportsman.CreateDBClone();
        }
    }
}
