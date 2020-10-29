using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Data
{
    public class NoteEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
