using Microsoft.AspNet.Identity.EntityFramework;

namespace EventsManager.Web.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }
        public ApplicationRole(string name) : base(name)
        {
        }
    }
}