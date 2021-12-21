using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace GuildCars.Models.ViewModels
{
    public class VehicleAddOrEditVM : System.ComponentModel.DataAnnotations.IValidatableObject
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> BodyTypes { get; set; }
        public IEnumerable<SelectListItem> InteriorColors { get; set; }
        public IEnumerable<SelectListItem> ExteriorColors { get; set; }
        public Vehicle Vehicle { get; set; }
        public int MakeID { get; set; }
        public HttpPostedFile ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Vehicle.ModelYear < 2000 || Vehicle.ModelYear > (DateTime.Now.Year + 1))
            {
                errors.Add(new ValidationResult($"Year must be between 2000 and {DateTime.Now.Year + 1}."));
            }
            if (Vehicle.Mileage < 0)
            {
                errors.Add(new ValidationResult($"Mileage cannot be negative."));
            }
            if (Vehicle.Mileage > 1000 && Vehicle.IsNew == true)
            {
                errors.Add(new ValidationResult($"A new vehicle must have less than 1000 miles."));
            }
            else if (Vehicle.Mileage <= 1000 && Vehicle.IsNew == false)
            {
                errors.Add(new ValidationResult($"A used vehicle must have more than 1000 miles."));
            }
            if (Vehicle.VIN.Length != 17 || !CheckAlphaNumeric(Vehicle.VIN))
            {
                errors.Add(new ValidationResult($"A VIN must contain 17 characters and be only numbers or letters."));
            }
            if (Vehicle.SalePrice != null && Vehicle.SalePrice > Vehicle.RetailPrice)
            {
                errors.Add(new ValidationResult($"The sale price cannot exceed the MSRP."));
            }
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
                var extension = Path.GetExtension(ImageUpload.FileName);
                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult($"Image file must be a jpeg, png, gif, or jpg."));
                }
            }
            return errors;
        }

        private bool CheckAlphaNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c)) { return false; }
            }
            return true;
        }
    }
}
