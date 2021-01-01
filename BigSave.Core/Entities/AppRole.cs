using Microsoft.AspNetCore.Identity;
namespace BigSave.Core.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}