using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class Comp
    {
        int CompID { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        List<Distance> Distances { get; set; }
    }
}