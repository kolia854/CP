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
    /// Interaction logic for DistancePage.xaml
    /// </summary>
    public partial class DistancePage : Page
    {
        public DistancePage(Frame frame, int l, string s)
        {
            InitializeComponent();
            DataContext = new DistanceAddingViewModel(frame);
        }
    }
}
