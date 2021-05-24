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

        public ObservableCollection<Sportsman> participants;

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

        public ObservableCollection<Sportsman> Participants
        {
            get { return participants; }
            set
            {
                participants = value;
                OnPropertyChanged("Participants");
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
