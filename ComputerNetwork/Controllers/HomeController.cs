using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerNetwork.Controllers
{
    public class HomeController : Controller
    {
        private IRouterRepository routerRepository;
        public ViewResult Index()
        {
            return View();
        }
        public HomeController(IRouterRepository routerRepo) => routerRepository = routerRepo;

        [HttpPost]
        public IActionResult AddRouter(Router router)
        {
            routerRepository.AddRouter(router);
            return RedirectToAction("Index");
        }

    }
}