using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TournaHub.Models;

namespace TournaHub.Controllers
{
    public class TournaController : Controller
    {
        // GET: TournaController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7148/api/user";

            List<Tourna> users = new List<Tourna>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<Tourna>>(result);
            }

            return View(users);
        }

        // GET: TournaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TournaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tourna user)
        {
            string apiUrl = "https://localhost:7148/api/user";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: TournaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TournaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TournaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TournaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
