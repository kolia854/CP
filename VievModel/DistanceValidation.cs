using System.ComponentModel.DataAnnotations;


namespace CourseProject
{
    public class DistanceValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var distance = new Distance();
            try
            {
                distance = value as Distance;
            }
            catch { }
            if (distance.length == 0 || distance.style == null)
                return false;
            if (distance != null)
            {
                switch (distance.style)
                {
                    case "Баттерфляй":
                        if (distance.length != 50 && distance.length != 100 && distance.length != 200)
                        {
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                            return false;
                        }
                        return true;
                    case "На спине":
                        if (distance.length != 50 && distance.length != 100 && distance.length != 200)
                        {
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                            return false;
                        }
                        return true;
                    case "Брасс":
                        if (distance.length != 50 && distance.length != 100 && distance.length != 200)
                        {
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                            return false;
                        }
                        return true;
                    case "Кроль":
                        if (distance.length != 50 && distance.length != 100 && distance.length != 200 &&
                            distance.length != 400 && distance.length != 800 && distance.length != 1500)
                        {
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                            return false;
                        }
                        return true;
                    case "Комплекс":
                        if (distance.length != 100 && distance.length != 200 && distance.length != 400)
                        {
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                            return false;
                        }
                        return true;
                    default:
                        return true;
                }
            }
            return false;
        }
    }
}
