using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int Total { get; set; }
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories {get; set;}
    }
}