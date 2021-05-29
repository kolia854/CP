using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public sealed class User
    {
        public bool IsAdmin;
        private static User instance;

        private User()
        {
        }

        public static User getInstance()
        {
            if (instance == null)
            {
                instance = new User();
            }
            return instance;
        }
    }
}
