using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public class FakeRouterRepository : IRouterRepository
    {
        private List<Router> routers = new List<Router>();
        public IEnumerable<Router> Routers => routers;

        public void AddRouter(Router newRouter)
        {
            routers.Add(newRouter);
        }
    }
}
