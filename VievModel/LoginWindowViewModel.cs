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
        private string Password;
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private RelayCommand enter;
        public RelayCommand Enter
        {
            get
            {
                return enter ??
                    (enter = new RelayCommand(obj =>
                    {
                        var a = User.getInstance();
                        a.IsAdmin = true;
                        var mw = new MainWindow();
                        mw.Show();
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
                        var passwordBox = obj as PasswordBox;
                        Password = passwordBox.Password;
                        if (Password == "admin" && login == "admin")
                        {
                            var a = User.getInstance();
                            a.IsAdmin = true;
                            var mw = new MainWindow();
                            mw.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный пароль");
                        }
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
    }
}
