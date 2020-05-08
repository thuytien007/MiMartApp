using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserArticle
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }  
        //trong UserArticle có tham chiếu đến bảng AppUser và bảng Article
        //nên ở 2 lớp kia sẽ có ICollection của UserArticle đến (quan hệ n-n)
        //UserArticle lúc này là do qhe n-n sinh ra
        //thêm bên DbContext DbSet dòng ICollection tương tự
    }
}