using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;
using EventsManager.Web.Domain.Entities;
using EventsManager.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EventsManager.Web.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(new int?(256))
                .HasColumnAnnotation("Index", (object) new IndexAnnotation(new IndexAttribute("EventCategoryNameIndex")
                {
                    IsUnique = true
                }));



            base.OnModelCreating(modelBuilder);
        }
    }
}