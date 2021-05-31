using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourseProject
{
    public class DBComp
    {
        public int DBCompID { get; set; }

        public string name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public List<DBDistance> distances { get; set; }

        public Comp Clone()
        {
            var c = new Comp();
            c.Date = date;
            c.Name = name;
            c.CompID = DBCompID;
            if (distances != null)
            {
                foreach (var d in distances)
                {
                    var dc = d.Clone();
                    c.Distances.Add(dc);
                }
            }
            return c;
        }
    }
}
