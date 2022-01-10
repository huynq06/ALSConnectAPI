using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Blog
    {
        public Blog()
        {
            BlogTags = new HashSet<BlogTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public virtual ICollection<BlogTag> BlogTags { get; set; }
    }
}
