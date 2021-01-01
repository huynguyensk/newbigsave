using Microsoft.AspNetCore.Identity;
namespace BigSave.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        public virtual Cart Cart { get; set; }
    }
}