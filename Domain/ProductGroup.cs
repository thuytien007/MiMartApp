using System;
using System.Collections.Generic;

namespace Domain
{
    public class ProductGroup
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }  
        public virtual ICollection<Product> Products { get; set; }
    }
}