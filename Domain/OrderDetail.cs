using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public int CurrentPrice { get; set; }
        public int SelectedNumber { get; set; }
        public int Total { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual StoreDetail StoreDetails { get; set; }
    }
}