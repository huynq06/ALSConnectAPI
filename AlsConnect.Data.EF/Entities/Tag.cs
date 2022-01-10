using AlsConnect.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Tag : DomainEntity<string>
    {
        public Tag()
        {
            BlogTags = new HashSet<BlogTag>();
            ProductTags = new HashSet<ProductTag>();
        }

        //public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<BlogTag> BlogTags { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
