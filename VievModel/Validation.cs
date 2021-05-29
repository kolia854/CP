using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseProject
{
    public class Validation
    {
        public string Validate(object obj)
        {
            string error = null;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj, context, results))
            {
                error = results[0].ErrorMessage;
            }

            return error;
        }
    }
}
