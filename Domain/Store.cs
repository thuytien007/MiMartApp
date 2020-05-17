using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Coordinates { get; set; }
        [JsonIgnore]
        public virtual Partner Partner { get; set; }
        public virtual ICollection<StoreDetail> StoreDetails { get; set; }
    }
}