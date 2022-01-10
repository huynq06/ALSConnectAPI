using AlsConnect.Data.Enums;
using AlsConnect.Data.Interfaces;
using AlsConnect.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Function : DomainEntity<string>, ISwitchable, ISortable
    {
        public Function()
        {
            Permissions = new HashSet<Permission>();
        }

     //   public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ParentId { get; set; }
        public string IconCss { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
