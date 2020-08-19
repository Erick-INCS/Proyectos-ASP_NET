using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS01.Models
{
    public class Support
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ProblemDescription { get; set; }
        public string Solution { get; set; }
    }
}