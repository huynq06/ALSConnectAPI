using AlsConnect.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace AlsConnect.Data.EF.Entities
{
    public partial class Permission : DomainEntity<int>
    {
        public Permission() { }
        public Permission(Guid roleId, string functionId, bool canCreate,
            bool canRead, bool canUpdate, bool canDelete)
        {
            RoleId = roleId;
            FunctionId = functionId;
            CanCreate = canCreate;
            CanRead = canRead;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }
        //   public int Id { get; set; }
        public Guid RoleId { get; set; }
        public string FunctionId { get; set; }
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        public virtual Function Function { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
