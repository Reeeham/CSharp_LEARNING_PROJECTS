using AutoLotDAL_Core2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLotDAL_Core2.Model.Repos
{
    //this handles the specific work on the inventory table that isn't covered by the base repo
    //you'll need to create an IInventoryRepo interface to set you up for ASP.NET Cre dependency Injection
    public interface IInventoryRepo : IRepo<Inventory>
    {
        List<Inventory> Search(string searchString);
        List<Inventory> GetPinkCars();
        List<Inventory> GetRelatedData();
    }
    // next add new InventoryRepo to repos dir. 
}
