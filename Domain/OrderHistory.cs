using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class OrderHistory
    {
        public Guid OrderId { get; set; }
        public Guid StatusOrderId { get; set; }
        public DateTime DateOfStatusOrder { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual StatusOrder StatusOrder { get; set; }
    }
}