using System;
using System.Collections.Generic;

namespace Domain
{
    public class StatusOrder
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories {get; set;}
    }
}