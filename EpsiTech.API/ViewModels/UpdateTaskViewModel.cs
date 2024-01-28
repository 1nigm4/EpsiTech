using System.ComponentModel.DataAnnotations;

namespace EpsiTech.API.ViewModels
{
    public class UpdateTaskViewModel
    {
        [Required]
        public Guid TaskId { get; set; }
        [Required]
        public string? NewTitle { get; set; }
        [Required]
        public string? NewDescription { get; set; }
    }
}
