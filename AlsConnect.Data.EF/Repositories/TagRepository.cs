using AlsConnect.Data.EF.Entities;
using AlsConnect.Data.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
