using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DancerWeb.Models
{
    public class Teacher : Dancers
    {
        //public int Id { set; get; }
        //[Required]
        //public string Name { set; get; }
        //[Required]
        //public int Age { set; get; }
        
        //public int Phone { set; get; }
        public string CompanyAddress { get; set; }
        public string CompanyName { set; get; }
   //     [Required]
        //public string City { set; get; }

        //[EmailAddress]
        //[Required]
        //[Display(Name = "Email")]
        //public string Email { set; get; }

        //[DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[Required]
        //public string Password { set; get; }

        //  public List<Dancers> Dancers { get; set; }


    }
}