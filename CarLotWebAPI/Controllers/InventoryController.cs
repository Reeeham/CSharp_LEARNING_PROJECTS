using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;


namespace CarLotWebAPI.Controllers
{
    [Route("api/Cars/{id?}")]
    public class InventoryController : ApiController
    {
        private readonly InventoryRepo _repo = new InventoryRepo();

        public InventoryController()
        {
            Mapper.Initialize(
            cfg =>{
                cfg.CreateMap<Inventory, Inventory>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
        }
        
        // GET: api/Inventory
        [HttpGet, Route("")]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repo.GetAll();
            return Mapper.Map<List<Inventory>, List<Inventory>>(inventories);
        }
        // GET: api/Inventory/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Inventory, Inventory>(inventory));
        }
        // POST: api/Inventory
        [HttpPost, Route("")]
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repo.Add(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            //CreatedAtRoute method adds the URI of this new item into the header so
            //the client can use it if necessary.
            return CreatedAtRoute("DisplayRoute", new { id = inventory.Id }, inventory);
        }
        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            try
            {
                _repo.Save(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE: api/Inventory/5
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            try
            {
                _repo.Delete(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}