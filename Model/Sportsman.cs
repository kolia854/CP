﻿using System;
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
        private DateTime time;
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

        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
