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
        public int Id { get; set; }

        public int Length { get; set; }

        public string Style { get; set; }

        public DBComp competition { get; set; }

        public List<DBSportsman> Participants { get; set; }

        public Distance Clone()
        {
            var d = new Distance();
            d.Length = Length;
            d.Style = Style;
            d.competition = competition.Clone();
            d.Participants = new ObservableCollection<Sportsman>();
            foreach (var s in Participants)
            {
                d.Participants.Add(s.SportsmanClone());
            }
            return d;
        }
    }
}
