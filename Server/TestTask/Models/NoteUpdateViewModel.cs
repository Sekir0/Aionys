using System.ComponentModel.DataAnnotations;


namespace TestTask.Models
{
    public class NoteUpdateViewModel
    {
        [Required]
        public string Content { get; set; }
    }
}
