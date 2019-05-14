using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerNetwork.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        //private IRouterRepository routerRepository;
        public ViewResult Index()
        {
            return View();
        }
        public HomeController(ApplicationDbContext context) {
            _context = context;

        }
        [HttpPost]
        public async Task<IActionResult> Index(Router router, Computer computer, Edge edge, Switch @switch)
        {

            if (ModelState.IsValid)
            {
                string item = HttpContext.Request.Form["nameofelement"].ToString();
                switch (item)
                {
                    case "Router":
                        await _context.Routers.AddAsync(router);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    case "Switch":
                        await _context.Switches.AddAsync(@switch);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    case "Computer":
                        await _context.Computers.AddAsync(computer);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    case "Edge":
                        await _context.Edges.AddAsync(edge);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                }
            }
            return View();



        }

    }
}