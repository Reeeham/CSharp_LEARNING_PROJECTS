using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoLotDAL_Core2.Models;
using AutoMapper;
using Newtonsoft.Json;
using AutoLotDAL_Core2.Model.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoLotAPI_Core2.Controllers
{
    [Route("api/Inventory")]
    [Produces("application/json")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepo _repo;

        public InventoryController(IInventoryRepo repo)
        {
            _repo = repo;
            Mapper.Initialize(
                cfg =>
                {

                    cfg.CreateMap<Inventory, Inventory>().ForMember(x => x.Orders, opt => opt.Ignore());
                });
        }

        // GET: api/Inventory
        [HttpGet]
        public IEnumerable<Inventory> GetCars()
        {
            var inventories = _repo.GetAll();
            return Mapper.Map<List<Inventory>, List<Inventory>>(inventories);
        }

        // GET: api/Inventory/5
        [HttpGet("{id}", Name = "DisplayRoute")]
        public async Task<IActionResult> GetInventory([FromRoute] int id)
        {
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Inventory, Inventory>(inventory));
            ///Note that this uses one of the base
           // Controller helper methods, the Ok() method
        }
        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> PostInventory([FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Add(inventory);
            return CreatedAtRoute("DisplayRoute", new { id = inventory.Id }, inventory);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory([FromRoute] int id, [FromBody] Inventory
        inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            _repo.Update(inventory);
            return NoContent();
        }
        [HttpDelete("{id}/{timestamp}")]
        public async Task<IActionResult> DeleteInventory([FromRoute] int id, [FromRoute] string timestamp)
        {
            if (!timestamp.StartsWith("\""))
            {
                timestamp = $"\"{timestamp}\"";
            }
            var ts = JsonConvert.DeserializeObject<byte[]>(timestamp);
            _repo.Delete(id, ts);
            return Ok();
        }
           
}
}
