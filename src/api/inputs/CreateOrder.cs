using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using domain.entities;

using utils;
using System;

namespace api.inputs
{
    public class CreateOrder : IValidatableObject
    {
        [Required]
        public string timeOfDay { get; set; }

        [Required, MinLength(1)]
        public IEnumerable<int> dishesTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (!EnumUtils.IsValidEnumOfType(timeOfDay, typeof(TimeOfDay)))
            {
                results.Add(new ValidationResult("Time of day must be morning or night"));
            }

            this.dishesTypes.ToList().ForEach(dishType =>
            {
                if (!Enum.IsDefined(typeof(DishTypes), dishType))
                {
                    results.Add(new ValidationResult($"Invalid dish type id: ${dishType}"));
                }
            });

            return results;
        }
    }
}