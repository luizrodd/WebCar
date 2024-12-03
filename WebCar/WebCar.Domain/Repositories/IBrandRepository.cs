﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCar.Domain.Models;

namespace WebCar.Domain.Repositories
{
    public interface IBrandRepository : IRepository<Brand, Guid>
    {
    }
}
