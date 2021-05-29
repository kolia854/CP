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

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for Sportsmen.xaml
    /// </summary>
    public partial class Sportsmen : Page
    {
        public Sportsmen(Frame frame, Sportsman sportsman)
        {
            InitializeComponent();
            DataContext = new SportsmenPageViewModel(frame, sportsman);
        }
    }
}
