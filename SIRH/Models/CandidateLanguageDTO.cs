using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class CandidateLanguageDTO
    {
        public int? LanguageId { get; set; }
        public string Language { get; set; }
        public int? LanguageLevelId { get; set; }
        public string LanguageLevel { get; set; }
    }
}
