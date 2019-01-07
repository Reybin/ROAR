using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Employee:BaseModel
    {
        [Required,StringLength(30)]
        public string FirstName { get; set; }

        [Required, StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        [Required, StringLength(60)]
        public string Address { get; set; }
        [Required, StringLength(25)]
        public string PhoneNumber { get; set; }
    }
}
