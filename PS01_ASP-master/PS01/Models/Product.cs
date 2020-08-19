using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PS01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
        public ProductType productType { get; set; }

        public decimal Cost { get; set; }

    }
}