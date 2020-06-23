using System.Collections.Generic;
using Domain;

//chức năng profile này để dành tham khảo, không có trong ứng dụng mimart
namespace Application.Profiles
{
    public class Profile
    {
        public string DisplayName {get; set;}
        public string Username {get; set;}
        public string Image {get; set;}
        public string Bio {get; set;}

        public ICollection<Photo> Photos {get; set;}
    }
}