using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class WholePrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FromQuantity { get; set; }
        public int ToQuantity { get; set; }
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
    }
}
