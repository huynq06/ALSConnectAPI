using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlsConnect.Data.EF.Entities
{
    [Table("AppRoles")]
    public partial class AppRole : IdentityRole<Guid>
    {
        public AppRole()
        {
            Permissions = new HashSet<Permission>();
        }

      //  public Guid Id { get; set; }
        //public string Name { get; set; }
        //public string NormalizedName { get; set; }
        //public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
