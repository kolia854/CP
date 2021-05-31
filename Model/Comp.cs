using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourseProject 
{
    public class Comp : INotifyPropertyChanged
    {
        private int compID;
        [Required(ErrorMessage = "Укажите имя соревнования")]
        private string name;
        [Required(ErrorMessage = "Укажите дату проведения соревнования")]
        [Column(TypeName = "datetime2")]
        private DateTime date;
        [Required(ErrorMessage = "Добавьте минимум 1 дистанцию")]
        private ObservableCollection<Distance> distances = new ObservableCollection<Distance>();

        public int CompID
        {
            get { return compID; }
            set
            {
                compID = value;
                OnPropertyChanged("CompID");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public ObservableCollection<Distance> Distances
        {
            get { return distances; }
            set
            {
                distances = value;
                OnPropertyChanged("Distances");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public DBComp CreateDBClone()
        {
            var c = new DBComp();
            c.DBCompID = compID;
            c.date = date;
            c.name = name;
            c.distances = new List<DBDistance>();
            foreach (var d in distances)
            {
                var dc = d.CreateDBClone();
                c.distances.Add(dc);
            }
            return c;
        }
    }
}