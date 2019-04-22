using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public interface IComputerRepository
    {
        IQueryable<Computer> Computers { get; }

    }
}
