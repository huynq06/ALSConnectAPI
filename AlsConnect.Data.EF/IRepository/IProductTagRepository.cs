﻿using AlsConnect.Data.EF.Entities;
using AlsConnect.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.EF.IRepository
{
    public interface IProductTagRepository : IRepository<ProductTag, int>
    {
    }
}
