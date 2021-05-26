﻿using System;
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
namespace CourseProject.VievModel
{
    class AllSportsmenPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Sportsman> savedsportsmen = new ObservableCollection<Sportsman>();
        public ObservableCollection<Sportsman> SavedSportsmen
        {
            get { return savedsportsmen; }
            set
            {
                savedsportsmen = value;
                OnPropertyChanged("SavedSportsmen");
            }
        }

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

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
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