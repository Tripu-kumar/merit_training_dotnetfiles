using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using jobmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jobmvc.helper;
using jobmvc.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace jobmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        jobapi _api = new jobapi();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> JobList()
        {
            List<jobdata> jobDatas = new List<jobdata>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/jobDetails");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                jobDatas = JsonConvert.DeserializeObject<List<jobdata>>(res);
            }


            return View(jobDatas);
        }
        public async Task<IActionResult> Details(int id)
        {
            var job = new jobdata();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/jobDetails/{id}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                job = JsonConvert.DeserializeObject<jobdata>(res);
            }
            return View(job);
        }
        public ActionResult create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> create(jobdata student)
        {
            HttpClient cli = _api.Initial();
            string jobnew = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(jobnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/jobDetails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient cli = _api.Initial();
            HttpResponseMessage response = cli.DeleteAsync("api/jobDetails/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient cli = _api.Initial();
            jobdata job = new jobdata();
            HttpResponseMessage response = await cli.GetAsync($"api/jobDetails/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                job = JsonConvert.DeserializeObject<jobdata>(data);
            }
            return View(job);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("JobDetailsId,Companyname,JobCategory,Requiredskills,Experience,NoOfVacancies,Salary,EndDate,Email,JobLocation,PhNo,CompanyAddress,JobDescription,JobType")] jobdata model)
        {
            //if (id != model.JobDetailsId)
            //{
            //    return NotFound();
            //}
            HttpClient cli = _api.Initial();
            string stnew = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(stnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cli.PutAsync($"api/jobDetails/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("JobList");
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
