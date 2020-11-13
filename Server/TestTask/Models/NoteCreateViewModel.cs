using System.ComponentModel.DataAnnotations;


namespace TestTask.Models
{
    public class NoteCreateViewModel
    {
        [Required]
        public string Content { get; set; }
    }
}
