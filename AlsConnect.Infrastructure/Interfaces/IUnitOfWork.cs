using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call save change from db context
        /// </summary>
        void Commit();
        //void CommitAls();
       // void CommitHermes();
    }
}
