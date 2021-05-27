using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CourseProject 
{
    public class Comp : INotifyPropertyChanged
    {
        private int compID;
        private string name;
        private DateTime date;
        private ObservableCollection<Distance> distances;

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

        public DBComp CreateDBclone()
        {
            var c = new DBComp();
            c.date = date;
            c.name = name;
            foreach (var d in distances)
            {
                var dc = d.CreateDBClone();
                c.distances.Add(dc);
            }
            return c;
        }
    }
}