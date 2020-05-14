using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string CalculationUnit { get; set; }
        public string ProductImage { get; set; }
        [JsonIgnore]
        public virtual ProductGroup ProductGroup { get; set; }  
    }
}