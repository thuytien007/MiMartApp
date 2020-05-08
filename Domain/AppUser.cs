using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName {get; set;}
        public string Avatar {get; set;}
        public virtual ICollection<UserArticle> UserArticles {get; set;}
        public virtual ICollection<Photo> Photos {get; set;}
    }
}