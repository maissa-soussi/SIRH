using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class CountryDTO
    {
        public Country Country { get; set; }
        public List<int?> CandidateIDs { get; set; }
    }
}
