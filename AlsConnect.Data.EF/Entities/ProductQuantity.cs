using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class ProductQuantity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }

        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
