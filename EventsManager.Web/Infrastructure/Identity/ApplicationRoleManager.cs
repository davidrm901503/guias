using EventsManager.Web.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace EventsManager.Web.Infrastructure.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }
    }
}