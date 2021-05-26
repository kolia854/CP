using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace CourseProject.Viev
{
    public static class Navigation
    {
        private static Frame frame;

        public static void RegisterFrame(Frame frame)
        {
            Navigation.frame = frame;
        }

        public static void OpenPage(Page page)
        {
            if (page is null)
                throw new NullReferenceException();
            else
                frame.Navigate(page);
        }

        public static void GoBack()
        {
            frame.GoBack();
        }
    }
}
