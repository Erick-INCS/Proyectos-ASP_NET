using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoffeStreet.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string ProductName { get; set; }
        [Display(Name = "Costo")]
        public float Cost { get; set; }
        [Display(Name = "Disponibles")]
        public int Quantity { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }
        [Display(Name = "Tipo")]
        public string Type { get; set; }
        [Display(Name = "Tipo de producto")]
        [ForeignKey("Type")]
        public ProductType ProductType { get; set; }
    }
}