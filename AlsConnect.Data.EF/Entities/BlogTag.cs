using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class BlogTag
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string TagId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
