using Microsoft.AspNet.Identity.EntityFramework;

namespace AndroidAPP02.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<AndroidAPP02.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<AndroidAPP02.Models.UserInfo> UserInfoes { get; set; }

        public System.Data.Entity.DbSet<AndroidAPP02.Models.UserToProject> UserToProjects { get; set; }

        public System.Data.Entity.DbSet<AndroidAPP02.Models.Accounter> Accounters { get; set; }
    }
}