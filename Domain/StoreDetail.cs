using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class StoreDetail
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public int Price { get; set; }
        public int InventoryNumber { get; set; }
        [JsonIgnore]
        public virtual Store Store { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}