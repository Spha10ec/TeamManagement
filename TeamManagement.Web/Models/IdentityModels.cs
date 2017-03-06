using Microsoft.AspNet.Identity.EntityFramework;

namespace TeamManagement.Web.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool ConfirmedEmail { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
            : base("TeamManagementEntitiesString")
        {
        }
    }
}