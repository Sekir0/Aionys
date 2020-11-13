﻿using System.ComponentModel.DataAnnotations;


namespace TestTask.Data
{
    public class NoteEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
