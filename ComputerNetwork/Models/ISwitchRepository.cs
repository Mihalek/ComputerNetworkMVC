using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public interface ISwitchRepository
    {
        IQueryable<Switch> Switches { get; }

    }
}
