using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Size
    {
        public Size()
        {
            BillDetails = new HashSet<BillDetail>();
            ProductQuantities = new HashSet<ProductQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
