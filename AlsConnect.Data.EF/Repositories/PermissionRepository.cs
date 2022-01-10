using AlsConnect.Data.EF.Entities;
using AlsConnect.Data.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
