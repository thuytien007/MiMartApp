using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserActivity
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }  
        //bảng UserActivity có tham chiếu đến bảng AppUser và bảng Activity
        //nên 2 bảng đó sẽ có ICollection
    }
}