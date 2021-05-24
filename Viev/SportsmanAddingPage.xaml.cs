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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseProject
{
    /// <summary>
    /// Interaction logic for SportsmanAddingPage.xaml
    /// </summary>
    public partial class SportsmanAddingPage : Page
    {
        public SportsmanAddingPage()
        {
            InitializeComponent();
            DataContext = new SA_VievModel();
        }
    }
}
