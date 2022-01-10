using AlsConnect.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        //private MainDbContext _alsContext;
        //private HermesDBContext _hermesContext;
        public EFUnitOfWork(AppDbContext context)
        {
            _context = context;
            //_alsContext = alsContext;
            //_hermesContext = hermesDBContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        //public void CommitAls()
        //{
        //    _alsContext.SaveChanges();
        //}
        //public void CommitHermes()
        //{
        //    _hermesContext.SaveChanges();
        //}
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
