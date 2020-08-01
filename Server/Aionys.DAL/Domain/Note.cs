using System;
using System.ComponentModel.DataAnnotations;

namespace Aionys.DAL.Domain
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

    }
}
