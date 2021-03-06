﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public virtual memeber member {get;set;}
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HeroProject.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<HeroProject.Models.Friend> Friends { get; set; }

        public System.Data.Entity.DbSet<HeroProject.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<HeroProject.Models.Profile> Profiles { get; set; }

        public System.Data.Entity.DbSet<HeroProject.Models.Interest> Interests { get; set; }

        public System.Data.Entity.DbSet<HeroProject.Models.Photo> Photos { get; set; }
    }
}