// ReSharper disable VirtualMemberCallInConstructor
namespace PokerStrategy.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using PokerStrategy.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<ForumThread> ForumThreads { get; set; }

        public virtual ICollection<ForumReply> ForumReplies { get; set; }

        public virtual ICollection<News> NewsPosted { get; set; }

        public virtual ICollection<NewsComment> NewsComments { get; set; }

        // Users Profile
        public virtual ICollection<ApplicationUser> Friends { get; set; }

        public virtual ICollection<ProfileMessage> ProfileMessages { get; set; }

        public string Signature { get; set; }

        public string ImageUrl { get; set; }

        public int Points { get; set; } // meh
    }
}
