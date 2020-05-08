using System;
using System.Collections.Generic;

namespace Domain
{
    public class Article
    {
        //tạo ID không trùng, tránh id tăng dần bị giới hạn
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        //từ khóa virtual để sử dụng proxies - lazy loading
        public virtual ICollection<UserArticle> UserArticles {get; set;}
        public virtual ICollection<Photo> ArticlePhotos {get; set;}
    }
}