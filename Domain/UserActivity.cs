using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserActivity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }  
        //trong UserActivity có tham chiếu đến bảng AppUser và bảng Activity
        //nên ở 2 lớp kia sẽ có ICollection của UserActivity đến (quan hệ n-n)
        //UserActivity lúc này là do qhe n-n sinh ra
        //thêm bên DbContext DbSet dòng ICollection tương tự
    }
}