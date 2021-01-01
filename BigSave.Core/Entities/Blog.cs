using System.ComponentModel.DataAnnotations;
using BigSave.Core.Entities.Base;

namespace BigSave.Core.Entities
{
    public class Blog : BaseEntity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}