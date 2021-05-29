using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseProject
{
    public class Sportsman : INotifyPropertyChanged 
    {
        private int sportsmanID;
        private string name;
        private string gender;
        private string rank;
        private string trainer;
        private int year;
        private int race;
        private int seconds;
        public List<Distance> Distances { get; set; }

        [Required(ErrorMessage = "Заполните ФИО")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Выберите пол")]
        [RegularExpression("[МмЖж]", ErrorMessage = "Недопустимое значение")]
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string Trainer
        {
            get { return trainer; }
            set
            {
                trainer = value;
                OnPropertyChanged("Trainer");
            }
        }

        [Required(ErrorMessage = "Заполните год рождения")]
        [Range(1950, 2018)]
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        [Range(17, 2000)]
        public int Seconds
        {
            get { return seconds; }
            set
            {
                seconds = value;
                OnPropertyChanged("Time");
            }
        }

        public int Race
        {
            get { return race; }
            set
            {
                race = value;
                OnPropertyChanged("Race");
            }
        }

        public DBSportsman CreateDBClone()
        {
            var dbs = new DBSportsman();
            dbs.name = name;
            dbs.gender = gender;
            dbs.rank = rank;
            dbs.trainer = trainer;
            dbs.year = year;
            dbs.race = race;
            dbs.seconds = seconds;
            // вот 
            foreach (var dist in Distances)
            {
                var a = dist.CreateDBClone();
                dbs.DBDistances.Add(a);
            }
            // вот 
            return dbs;
        }

        public Sportsman Clone()
        {
            var a = new Sportsman();
            a.name = name;
            a.gender = gender;
            a.rank = rank;
            a.trainer = trainer;
            a.year = year;
            a.race = race;
            a.seconds = seconds;
            return a;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
