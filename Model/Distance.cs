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
    [DistanceValidation]
    public class Distance : INotifyPropertyChanged
    {
        public int distanceID;

        [Required(ErrorMessage = "Дистанция не была выбрана")]
        public int length;

        [Required(ErrorMessage = "Стиль не был выбран")]
        public string style;

        public List<Sportsman> participants;

        public Comp competition;

        public int Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }

        public string Style
        {
            get { return style; }
            set
            {
                style = value;
                OnPropertyChanged("Style");
            }
        }

        public List<Sportsman> Participants
        {
            get { return participants; }
            set
            {
                participants = value;
                OnPropertyChanged("Participants");
            }
        }

        public Comp Competition
        {
            get { return competition; }
            set
            {
                competition = value;
                OnPropertyChanged("Competition");
            }
        }

        public DBDistance CreateDBClone()
        {
            var d = new DBDistance();
            d.Participants = new List<DBSportsman>();
            foreach (var s in Participants)
            {
                d.Participants.Add(s.CreateDBClone());
            }
            d.Length = length;
            d.Style = style;
            d.competition = new DBComp();
            d.competition = competition.CreateDBClone();
            return d;
        }

        public void SetupRaces()
        {
            int counter = 0;
            int racenumber = 0;
            var SortedParticipants = (from p in participants
                                      orderby p.Seconds descending
                                      select p).ToList();

            participants.Clear();
            for (int i = 0; i < SortedParticipants.Count(); )
            {
                racenumber++;
                counter = 0;
                while (counter < 9 && i < SortedParticipants.Count())
                {
                    SortedParticipants[i].Race = racenumber;
                    participants.Add(SortedParticipants[i]);
                    counter++; 
                    i++;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
