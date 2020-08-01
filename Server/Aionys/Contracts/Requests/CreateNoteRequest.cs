using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Contracts.Requests
{
    public class CreateNoteRequest
    {
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
    }
}
