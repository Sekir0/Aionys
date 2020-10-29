using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class NoteModel
    {
        [Required]
        public string Note { get; set; }
    }
}
