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
        /*
         <form asp-action="Create" id="objectparameters" onsubmit="javascript:submitform();" method="post" target="votar">
                <div class="form-group">
                    <label>ID: <input id = "idform" autocomplete="off" type="text" readonly /></label> <br />
                </div>
                <div class="form-group">
                    <label>IP-Address: <input id = "ipaddressform" autocomplete="off" type="text" /></label><br />
                </div>
                <div class="form-group">
                    <label>Mask: <input type = "text" id="maskform" autocomplete="off" /></label><br />
                </div>
                <div class="form-group">
                    <label>Default Gateway: <input id = "defaultgatewayform" autocomplete="off" type="text" /></label><br />
                </div>
                <div class="form-group">
                    <input type = "submit" value="Submit" />
                </div>
            </form>

            */

        [HttpPost]
        public async Task<IActionResult> Index(Router router, Computer computer, Edge edge, Switch @switch)
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

            return View();


        }

    }
}