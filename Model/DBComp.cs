using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CourseProject
{
    public class DBComp
    {
        public int DBCompID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public List<DBDistance> distances { get; set; }
    }
}
