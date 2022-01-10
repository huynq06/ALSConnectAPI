using AlsConnect.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class ProductTag : DomainEntity<int>
    {
      //  public int Id { get; set; }
        public int ProductId { get; set; }
        public string TagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
