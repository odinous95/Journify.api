using System.ComponentModel.DataAnnotations;

namespace StepManagment.api.DTOS
{
    public class UpdateStepDTO
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}