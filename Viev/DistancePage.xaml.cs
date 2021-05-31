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
using System.Text.RegularExpressions;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for DistancePage.xaml
    /// </summary>
    public partial class DistancePage : Page
    {
        public DistancePage(Frame frame, Comp comp, int l, string s)
        {
            InitializeComponent();
            DataContext = new DistanceAddingViewModel(frame, comp, l, s);
        }

        private void OnlyText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я]{1,}$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void OnlyNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^0-9\\s]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnlyMF(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[MmFfМмЖж]{1,}$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
