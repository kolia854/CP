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
    class LoginWindowViewModel : INotifyPropertyChanged
    {
        private string password;
        private string login;
        private MainWindow mainWindow1;

        private RelayCommand enter;
        public RelayCommand Enter
        {
            get
            {
                return enter ??
                    (enter = new RelayCommand(obj =>
                    {
                        mainWindow1.Show();

                    }));
            }
        }

        private RelayCommand adminEnter;
        public RelayCommand AdminEnter
        {
            get
            {
                return adminEnter ??
                    (adminEnter = new RelayCommand(obj =>
                    {
                        if (login == "admin" && password == "admin")
                            mainWindow1.Show();
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

        public LoginWindowViewModel(string s, MainWindow main)
        {
            password = s;
            mainWindow1 = main;
        }
    }
}
