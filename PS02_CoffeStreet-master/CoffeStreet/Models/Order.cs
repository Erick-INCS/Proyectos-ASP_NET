using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoffeStreet.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Pruducto")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        [Display(Name = "Cliente")]
        public string ClientName { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [DefaultValue(true)]
        public bool Pending { get; set; }
    }
}