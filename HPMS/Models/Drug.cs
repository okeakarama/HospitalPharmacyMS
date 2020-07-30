using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HPMS.Models
{
    public class Drug
    {
        public int DrugID { get; set; }

        [Required(ErrorMessage = "Drug Name field can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price field can't be empty")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Description field can't be empty")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity field can't be empty")]
        public int Quantity { get; set; }

        public string Rack { get; set; }

        //[UIHint("Enums")]
        //public HPMS.Models.Enums.DrugType DrugType { get; set; }
    }
}