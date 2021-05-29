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
using System.Text.RegularExpressions;
using System.Windows.Shapes;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for Competition.xaml
    /// </summary>
    public partial class Competition : Page
    {
        public Competition(Frame frame)
        {
            InitializeComponent();
            DataContext =  new CompetitionAddingViewModel(frame);
        }

        private void OnlyText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я]{1,}$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
