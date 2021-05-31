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
    public class DBSportsman
    {
        public int DBSportsmanID { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string rank { get; set; }
        public string trainer { get; set; }
        public int year { get; set; }
        public int race { get; set; }
        public int seconds { get; set; }
        public List<DBDistance> Distances { get; set; }

        public Sportsman SportsmanClone()
        {
            var dbs = new Sportsman();
            dbs.ID = DBSportsmanID;
            dbs.Name = name;
            dbs.Gender = gender;
            dbs.Rank = rank;
            dbs.Trainer = trainer;
            dbs.Year = year;
            dbs.Race = race;
            dbs.Seconds = seconds;
            dbs.Distances = new List<Distance>();
            if (Distances == null)
                Distances = new List<DBDistance>();
            foreach (var s in Distances)
            {
                dbs.Distances.Add(s.Clone());
            }
            return dbs;
        }
    }
}
