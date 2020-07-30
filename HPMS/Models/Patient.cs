using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HPMS.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Surname field can't be empty")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Firstname field can't be empty")]
        public string Firstname { get; set; }

        public string Othername { get; set; }

        public string Fullname
        {
            get
            {
                return Surname + " " + Firstname + " " + Othername;
            }
        }

        [Required(ErrorMessage = "Gender field can't be empty")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age field can't be empty")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Address field can't be empty")]
        public string Address { get; set; }


        public string Occupation { get; set; }

        [Required(ErrorMessage = "Telephone field can't be empty")]
        public string Telephone { get; set; }
    }
}