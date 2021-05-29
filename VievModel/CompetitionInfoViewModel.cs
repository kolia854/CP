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

        private Comp currentCompetition = new Comp();
        public Comp CurrentCompetition
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
            using (CPContext db = new CPContext())
            {
                //selectedCompetition = comp;
                //var comp = db.

        //        var phones = db.Phones.Join(db.Companies, // второй набор
        //p => p.CompanyId, // свойство-селектор объекта из первого набора
        //c => c.Id, // свойство-селектор объекта из второго набора
        //(p, c) => new // результат
        //{
        //    Name = p.Name,
        //    Company = c.Name,
        //    Price = p.Price
        //});
        //        foreach (var p in phones)
        //            Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }
            
        }
    }
}
