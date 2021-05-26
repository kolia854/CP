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
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Frame workFrame;

        private RelayCommand openMainPage;
        public RelayCommand OpenMainPage
        {
            get
            {
                return openMainPage ??
                    (openMainPage = new RelayCommand(obj =>
                    {
                        workFrame.Navigate(new MainPage(workFrame));
                    }));
            }
        }

        private RelayCommand openCompetitionAddingPage;
        public RelayCommand OpenCompetitionAddingPage
        {
            get
            {
                return openCompetitionAddingPage ??
                    (openCompetitionAddingPage = new RelayCommand(obj =>
                    {
                        workFrame.Navigate(new Competition(workFrame));
                    }));
            }
        }

        private RelayCommand openAllSportsmanPage;
        public RelayCommand OpenAllSportsmanPage
        {
            get
            {
                return openAllSportsmanPage ??
                    (openAllSportsmanPage = new RelayCommand(obj =>
                    {
                        workFrame.Navigate(new AllSportsmanPage());
                    }));
            }
        }

        private RelayCommand openSportsmanAddingPage;
        public RelayCommand OpenSportsmanAddingPage
        {
            get
            {
                return openSportsmanAddingPage ??
                    (openSportsmanAddingPage = new RelayCommand(obj =>
                    {
                        workFrame.Navigate(new SportsmanAddingPage());
                    }));
            }
        }

        private RelayCommand openPreviousPage;
        public RelayCommand OpenPreviousPage
        {
            get
            {
                return openPreviousPage ??
                    (openPreviousPage = new RelayCommand(obj =>
                    {
                        if (workFrame.CanGoBack)
                            workFrame.GoBack();
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

        public MainWindowViewModel(Frame frame)
        {
            workFrame = frame;
        }
    }
}
