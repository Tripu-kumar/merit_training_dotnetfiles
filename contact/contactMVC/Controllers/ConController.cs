using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using contactMVC.Helper;
using contactMVC.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace contactMVC.Controllers
{
    public class ConController : Controller
    {
        ContactApi _api = new ContactApi();
        public async Task<IActionResult> Index()
        {
            List<ContactData> contactDatas = new List<ContactData>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Contact");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                contactDatas = JsonConvert.DeserializeObject<List<ContactData>>(res);
            }


            return View(contactDatas);
        }
       
    }
}
