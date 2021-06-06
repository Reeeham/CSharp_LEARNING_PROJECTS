using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using AutoLotDAL.Models;
using System.Text;

namespace CarLotMVC.Controllers
{
    public class InventoryController : Controller
    {
        //  private readonly InventoryRepo _repo = new InventoryRepo();
        private string _baseUrl = "http://localhost:60710/api/Inventory";

        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var items = JsonConvert.DeserializeObject<List<Inventory>>(await response.Content.
                ReadAsStringAsync());
                return View(items);
            }
            return HttpNotFound();
        }

        // GET: Inventory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(
                await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return HttpNotFound();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Make,Color,PetName")] Inventory inventory)
        {
            if (!ModelState.IsValid) return View(inventory);
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(inventory);
                var response = await client.PostAsync(_baseUrl,
                new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }
            return View(inventory);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(
                await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return new HttpNotFoundResult();
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarId,Make,Color,PetName,Timestamp")] Inventory inventory)
        {

            if (!ModelState.IsValid) return View(inventory);
            try
            {

                
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty,
                $@"Unable to save the record. Another user has updated it. {ex.Message}");
                return View(inventory);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                return View(inventory);
            }

            return RedirectToAction("Index");
        }

        // GET: Inventory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(await response.Content.
                ReadAsStringAsync());
                return View(inventory);
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "Id,Timestamp")] Inventory inventory)
        {
            try
            {
                var client = new HttpClient();
                /*HttpRequestMessage takes the HttpMethod as the first parameter and the URL
                as the second. Json.NET serializes the inventory object so that it can be added 
                to a StringContent instance,which is part of the object initialization for the message.*/
                HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{inventory.Id}")
                {
                    Content =
                new StringContent(JsonConvert.SerializeObject(inventory), Encoding.UTF8,
                "application/json")
                };
                var response = await client.SendAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }
            return View(inventory);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }
    }
}
