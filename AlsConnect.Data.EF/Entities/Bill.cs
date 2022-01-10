using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        public int PaymentMethod { get; set; }
        public int BillStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        public Guid CustomerId { get; set; }

        public virtual AppUser Customer { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
