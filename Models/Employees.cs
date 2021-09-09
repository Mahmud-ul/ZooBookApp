using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooBookApp.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Must Include a First Name")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must Include a Middle Name")]
        [StringLength(50, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Must Include a Last Name")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
