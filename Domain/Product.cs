using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string CalculationUnit { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [JsonIgnore]
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<StoreDetail> StoreDetails { get; set; }
    }
}