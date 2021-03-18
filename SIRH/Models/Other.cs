using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class Other
    {
        public int Id { get; set; }

        
        [Url]
        public string FacebookUrl { get; set; }

        
        [Url]
        public string LinkedinUrl { get; set; }
    }
}
