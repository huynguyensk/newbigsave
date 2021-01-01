using System.ComponentModel.DataAnnotations;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(10)]
        [Required]
        public string Message { get; set; }
    }
}