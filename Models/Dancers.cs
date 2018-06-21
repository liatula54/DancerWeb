using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DancerWeb.Models
{
    public class Dancers
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Age { set; get; }
        public int Phone { set; get; }
        public string StudioAddress { get; set; }
        public string StudioName { set; get; }
        [Required]
        public string City { set; get; }
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required]
        public string Password { set; get; }


    }
}