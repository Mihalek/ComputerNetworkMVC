using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerNetwork.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private MessageHub hub;
        //private IRouterRepository routerRepository;
        public ViewResult Index()
        {
            return View();
        }
        public HomeController(ApplicationDbContext context) {
            _context = context;


        }
        [HttpGet]
        public async Task<JsonResult> GetNetworksNames()
        {
            var networks = from c in _context.Networks
                           select new { key = c.Id, value = c.NameOfNetwork, date =c.DateOfAdd };
            
            return Json(networks);
        }




        [HttpGet]
        public async Task<JsonResult> GetNetwork(string mystring)
        {
            
            var routers = from c in _context.Routers
                          where c.NameOfNetwork == mystring
                          select new {
                              ipaddress = c.IpAddress,
                              mask = c.Mask,
                              defaultgateway = c.Gateway,
                              id = c.IdOfElement,
                              shape = c.Shape,
                              title = c.Title,
                              nameofelement = c.Label,
                              image = c.Image,
                              label = c.Label,
                              nazwasieci = c.NameOfNetwork,
                              dateofadd = c.DateOfAdd
                          };
            
            var switches = from c in _context.Switches
                           where c.NameOfNetwork == mystring
                           select new
                           {
                               ipaddress = c.IpAddress,
                               mask = c.Mask,
                               defaultgateway = c.Gateway,
                               id = c.IdOfElement,
                               shape = c.Shape,
                               title = c.Title,
                               nameofelement = c.Label,
                               image = c.Image,
                               label = c.Label,
                               nazwasieci = c.NameOfNetwork,
                               dateofadd = c.DateOfAdd
                           };
            var computers = from c in _context.Computers
                            where c.NameOfNetwork == mystring
                            select new
                            {
                                ipaddress = c.IpAddress,
                                mask = c.Mask,
                                defaultgateway = c.Gateway,
                                id = c.IdOfElement,
                                shape = c.Shape,
                                title = c.Title,
                                nameofelement = c.Label,
                                image = c.Image,
                                label = c.Label,
                                nazwasieci = c.NameOfNetwork,
                                dateofadd = c.DateOfAdd
                            };
            var edges = from c in _context.Edges
                        where c.NameOfNetwork==mystring
                        select new
                        {
                            to = c.To,
                            nazwasieci = c.NameOfNetwork,
                            dateofadd = c.DateOfAdd,
                            @from = c.From
                        }
                        ;
            var Result = new { Routers = routers, Switches = switches, Computers = computers, Edges = edges };
            return Json(Result);
        }

        



        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PostData postData)
        {
            /*
            string id = HttpContext.Request.Form["idofelement"].ToString();
            string item = HttpContext.Request.Form["nameofelement"].ToString();
            */
            Network network = new Network
            {
                NameOfNetwork = postData.nazwasieci + " " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                DateOfAdd = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
                          
            };


            await _context.Networks.AddAsync(network);
            await _context.SaveChangesAsync();



            foreach (var element in postData.obiekty)
            {
                if (ModelState.IsValid)
                {
                    bool contactExists;
                    string item = element.label.ToString();
                    string id = element.id.ToString();
                    switch (item)
                    {
                        case "Router":
                            contactExists = _context.Routers.Any(r => r.IdOfElement.Equals(id));
                            Router router = new Router
                            {
                                IpAddress = element.ipaddress.ToString(),
                                Mask = element.mask.ToString(),
                                Gateway = element.defaultgateway.ToString(),
                                IdOfElement = element.id.ToString(),
                                Shape = element.shape.ToString(),
                                Title = element.title.ToString(),
                                NameOfElement = element.label.ToString(),
                                Image = element.image.ToString(),
                                Label = element.label.ToString(),
                                NameOfNetwork = postData.nazwasieci.ToString()+" "+DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                DateOfAdd = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

                            };
                            if (!contactExists)
                            {
                                await _context.Routers.AddAsync(router);
                                await _context.SaveChangesAsync();
                                continue;
                            }
                            else 
                            {
                                continue;
                            }
                            
                        case "Switch":
                            contactExists = _context.Switches.Any(s => s.IdOfElement.Equals(id));
                            Switch @switch = new Switch
                            {
                                IpAddress = element.ipaddress.ToString(),
                                Mask = element.mask.ToString(),
                                Gateway = element.defaultgateway.ToString(),
                                IdOfElement = element.id.ToString(),
                                Shape = element.shape.ToString(),
                                Title = element.title.ToString(),
                                NameOfElement = element.label.ToString(),
                                Image = element.image.ToString(),
                                Label = element.label.ToString(),
                                NameOfNetwork = postData.nazwasieci.ToString() + " " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                DateOfAdd = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

                            };
                            if (!contactExists)
                            {
                                await _context.Switches.AddAsync(@switch);
                                await _context.SaveChangesAsync();
                                continue;
                            }
                            else
                            {
                                continue;
                            }


                        case "Computer":
                            contactExists = _context.Computers.Any(c => c.IdOfElement.Equals(id));
                            Computer computer = new Computer
                            {
                                IpAddress = element.ipaddress.ToString(),
                                Mask = element.mask.ToString(),
                                Gateway = element.defaultgateway.ToString(),
                                IdOfElement = element.id.ToString(),
                                Shape = element.shape.ToString(),
                                Title = element.title.ToString(),
                                NameOfElement = element.label.ToString(),
                                Image = element.image.ToString(),
                                Label = element.label.ToString(),
                                NameOfNetwork = postData.nazwasieci.ToString() + " " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                DateOfAdd = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

                            };
                            if (!contactExists)
                            {
                                await _context.Computers.AddAsync(computer);
                                await _context.SaveChangesAsync();
                                continue;
                            }
                            else
                            {
                                continue;
                            }


                      
                    }
                }
                

            }


            foreach (var element in postData.polaczenia)
            {
              
                    Edge edge = new Edge
                    {
                        From = element.from.ToString(),
                        To = element.to.ToString(),
                        DateOfAdd = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                        NameOfNetwork = postData.nazwasieci.ToString() + " " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

                    };
                
                        await _context.Edges.AddAsync(edge);
                        await _context.SaveChangesAsync();

            }

      


            return Json(network);
        }

        public class PostData
        {
            public string nazwasieci { get; set; }
            public List<Polaczenia> polaczenia { get; set; }
            public List<Obiekty> obiekty { get; set; }
        }
        
        public class Obiekty
        {
            public string defaultgateway { get; set; }
            public string id { get; set; }
            public string image { get; set; }
            public string ipaddress { get; set; }
            public string label { get; set; }
            public string mask { get; set; }
            public string shape { get; set; }
            public string title { get; set; }
        }

        public class Polaczenia
        {
            public string from { get; set; }
            public string to { get; set; }
            public string id { get; set; }
        }

        [HttpGet]
        public JsonResult Test()
        {
            var obiekt = new Router()
            {
                Id= 124,
                IdOfElement="sagasg",
                IpAddress="192.168.0.1",
                Mask="255.255.255.0",
                Gateway="192.168.0.2",
                NameOfElement="Router"
                

            };

            return Json(obiekt);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Flag([FromBody]string flaga_do_usuniecia)
        {
            flagtodelete = flaga_do_usuniecia;

            return RedirectToAction();
        }

        [HttpGet]
        public async Task<JsonResult> Flag()
        {
            string a = flagtodelete;
            flagtodelete = "";
            return Json(a);
        }
        */

        [HttpPost]
        public async Task<IActionResult> DeleteNetwork([FromBody]string todelete)
        {
            try
            {

                var routerstodelete = _context.Routers.Where(r => r.NameOfNetwork == todelete);
                _context.Routers.RemoveRange(routerstodelete);
                _context.SaveChanges();

               var switchestodelete = _context.Switches.Where(r => r.NameOfNetwork == todelete);
                _context.Switches.RemoveRange(switchestodelete);
                _context.SaveChanges();

                var computerstodelete = _context.Computers.Where(r => r.NameOfNetwork == todelete);
                _context.Computers.RemoveRange(computerstodelete);
                _context.SaveChanges();

                var edgestodelete = _context.Edges.Where(r => r.NameOfNetwork == todelete);
                _context.Edges.RemoveRange(edgestodelete);

                _context.Networks.Remove(_context.Networks
                        .SingleOrDefault(r => r.NameOfNetwork == todelete));
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }



        [HttpPost]
        public async Task<IActionResult> DeleteAllNetworks()
        {
            _context.Routers.RemoveRange(_context.Routers);
            _context.Switches.RemoveRange(_context.Switches);
            _context.Computers.RemoveRange(_context.Computers);
            _context.Edges.RemoveRange(_context.Edges);
            _context.Networks.RemoveRange(_context.Networks);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        /*
        [HttpPost]
        public IActionResult Clean()
        {
            _context.Routers.RemoveRange(_context.Routers);
            _context.Switches.RemoveRange(_context.Switches);
            _context.Computers.RemoveRange(_context.Computers);
            _context.Edges.RemoveRange(_context.Edges);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public IActionResult Delete()
        {
            string id = HttpContext.Request.Form["idofelement"].ToString();
            string item = HttpContext.Request.Form["nameofelement"].ToString();
            switch (item)
            {

                case "Router":
                    try
                    {
                        _context.Routers.Remove(_context.Routers
                                .SingleOrDefault(r => r.IdOfElement == id));
                        _context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("index");
                    }

                case "Switch":
                    try
                    {
                        _context.Switches.Remove(_context.Switches
                                .SingleOrDefault(r => r.IdOfElement == id));
                        _context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("index");
                    }

                case "Computer":

                    try
                    {
                        _context.Computers.Remove(_context.Computers
                                .SingleOrDefault(r => r.IdOfElement == id));
                        _context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("index");
                    }
                case "Edge":
                    try
                    {
                        _context.Edges.Remove(_context.Edges
                                .SingleOrDefault(r => r.IdOfElement == id));
                        _context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index");
                    }

            }
            return View("index");
        }


        /*
        [HttpPost]
        public async Task<IActionResult> Index(Router router, Computer computer, Edge edge, Switch @switch)
        {

            if (ModelState.IsValid)
            {
                bool contactExists;
                string item = HttpContext.Request.Form["nameofelement"].ToString();
                string id = HttpContext.Request.Form["idofelement"].ToString();
                switch (item)
                {
                    case "Router":
                        contactExists = _context.Routers.Any(r => r.IdOfElement.Equals(id));
                        if (!contactExists)
                        {
                            await _context.Routers.AddAsync(router);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var oldrouter = await this._context.Routers
                            .SingleOrDefaultAsync(r => r.IdOfElement == id);
                            oldrouter.IpAddress = router.IpAddress;
                            oldrouter.Mask = router.Mask;
                            oldrouter.Gateway = router.Gateway;
                        
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                    case "Switch":
                        contactExists = _context.Switches.Any(s => s.IdOfElement.Equals(id));
                        if (!contactExists)
                        {
                            await _context.Switches.AddAsync(@switch);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var oldswitch = await this._context.Switches
                            .SingleOrDefaultAsync(r => r.IdOfElement == id);
                            oldswitch.IpAddress = @switch.IpAddress;
                            oldswitch.Mask = @switch.Mask;
                            oldswitch.Gateway = @switch.Gateway;

                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                    case "Computer":
                        contactExists = _context.Computers.Any(c => c.IdOfElement.Equals(id));
                        if (!contactExists)
                        {
                            await _context.Computers.AddAsync(computer);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var oldcomputer = await this._context.Computers
                            .SingleOrDefaultAsync(c => c.IdOfElement == id);
                            oldcomputer.IpAddress = computer.IpAddress;
                            oldcomputer.Mask = computer.Mask;
                            oldcomputer.Gateway = computer.Gateway;

                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                    case "Edge":
                        contactExists = _context.Edges.Any(e => e.IdOfElement.Equals(id));
                        if (!contactExists)
                        {
                            await _context.Edges.AddAsync(edge);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var oldedge = await this._context.Edges
                            .SingleOrDefaultAsync(e => e.IdOfElement == id);
                            oldedge.IpAddress = edge.IpAddress;
                            oldedge.Mask = edge.Mask;
                            oldedge.Gateway = edge.Gateway;

                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                }
            }
            return View();
            */


    }

    }
