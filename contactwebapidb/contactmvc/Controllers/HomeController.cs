using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using contactmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using contactmvc.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace contactmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        ContactApi _api = new ContactApi();
        public async Task<IActionResult> Index()
        {
            List<Contactdata> contactDatas = new List<Contactdata>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Contacts");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                contactDatas = JsonConvert.DeserializeObject<List<Contactdata>>(res);
            }


            return View(contactDatas);
        }
       
        public ActionResult create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> create(Contactdata contact)
        {
            HttpClient cli = _api.Initial();
            string contactnew = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(contactnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Contacts", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
