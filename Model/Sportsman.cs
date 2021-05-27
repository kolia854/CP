using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private byte[] photo;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

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

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

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

        public byte[] Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public DBSportsman CreateDBClone()
        {
            var dbs = new DBSportsman();
            dbs.DBSportsmanID = sportsmanID;
            dbs.name = name;
            dbs.gender = gender;
            dbs.rank = rank;
            dbs.trainer = trainer;
            dbs.year = year;
            dbs.race = race;
            dbs.photo = photo;
            dbs.seconds = seconds;
            return dbs;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
