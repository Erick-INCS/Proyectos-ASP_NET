using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeStreet.Models
{
    public class ProductType
    {
        [Key]
        [Display(Name = "Tipo")]
        public string Type { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}