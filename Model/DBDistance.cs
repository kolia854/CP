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
    public class DBDistance
    {
        public int DBDistanceID { get; set; }

        public int Length { get; set; }

        public string Style { get; set; }

        public List<DBSportsman> Participants { get; set; }
    }
}
