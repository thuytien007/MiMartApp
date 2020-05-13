using System;
using System.Collections.Generic;

namespace Domain
{
    public class Partner
    {
        public Guid Id { get; set; }
        public string PartnerName { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<Store> Stores {get; set;}
    }
}