using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventsManager.Web.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Events = new HashSet<Event>();
            Tickets = new HashSet<Ticket>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Location { get; set; }
        public string PersonalInformation { get; set; }
        public string Address { get; set; }
        public string WebPage { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string PinteresUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string FlickrUrl { get; set; }
        public string LinkedinUrl { get; set; }

        //public string[] Preferences { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //userIdentity.AddClaim(new Claim("PhotoUrl", PhotoUrl, ClaimValueTypes.String));

            // Add custom user claims here
            return userIdentity;
        }
    }
}