using System;
using System.ComponentModel.DataAnnotations;

namespace Aionys.DAL.Domain
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
