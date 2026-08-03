using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResolvingDependencyInjection.Models
{
    public class TravelDestination
    {
        [Display(Name = "VacationDays")]
        public int VacationDays { get; set; }

        [StringLength(3, MinimumLength = 0, ErrorMessage = "FieldLengthRange")]
        public string? CityName { get; set; }
    }
}