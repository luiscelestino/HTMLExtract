using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HTMLExtractWeb.Models
{
    public class HTMLPage
    {
        [Required]
        public string URI { get; set; }

        public string RegEx { get; set; }

        public string Code { get; set; }

        public string Match { get; set; }
    }
}
