using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public interface IRouterRepository
    {
        IEnumerable<Router> Routers { get; }
        void AddRouter(Router newRouter);
    }
}
