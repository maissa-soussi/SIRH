using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class SalaryWish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Salary { get; set; }
    }
}
