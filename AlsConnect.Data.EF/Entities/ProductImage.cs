using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }

        public virtual Product Product { get; set; }
    }
}
