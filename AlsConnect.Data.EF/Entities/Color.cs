using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Color
    {
        public Color()
        {
            BillDetails = new HashSet<BillDetail>();
            ProductQuantities = new HashSet<ProductQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
