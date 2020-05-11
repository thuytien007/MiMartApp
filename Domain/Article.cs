using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Domain
{
    public class Article
    {
        //tạo ID không trùng, tránh id tăng dần bị giới hạn
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }
        //từ khóa virtual để sử dụng proxies - lazy loading
        //public virtual ICollection<Photo> Photos { get; set; }
    }
}