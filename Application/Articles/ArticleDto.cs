using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.Articles
{
    public class ArticleDto
    {
        //tạo ID không trùng, tránh id tăng dần bị giới hạn
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author{ get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

        [JsonPropertyName("attendees")]
        public ICollection<AttendeeDto> UserArticles {get; set;}
    }
}