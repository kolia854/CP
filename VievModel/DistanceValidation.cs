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
            if (distance != null)
            {
                switch (distance.style)
                {
                    case "Баттерфляй":
                        if (distance.length != 50 || distance.length != 100 || distance.length != 200)
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                        return false;
                    case "На спине":
                        if (distance.length != 50 || distance.length != 100 || distance.length != 200)
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                        return false;
                    case "Брасс":
                        if (distance.length != 50 || distance.length != 100 || distance.length != 200)
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                        return false;
                    case "Кроль":
                        if (distance.length != 50 || distance.length != 100 || distance.length != 200 ||
                            distance.length != 400 || distance.length != 800 || distance.length != 1500)
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                        return false;
                    case "Комплекс":
                        if (distance.length != 100 || distance.length != 200 || distance.length != 400)
                            ErrorMessage = "Для этого стиля нет такой дистанции";
                        return false;
                    case null:
                        ErrorMessage = "Дистанция не выбрана или указана неправильно";
                        return false;
                    default:
                        return true;
                }
            }
            return false;
        }
    }
}
