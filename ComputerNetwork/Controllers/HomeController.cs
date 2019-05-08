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
        public async Task<IActionResult> Index(Computer router)
        {
            await _context.Computers.AddAsync(router);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}