using AutoLotDAL_Core2.EF;
using AutoLotDAL_Core2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDAL_Core2.Model.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>, IInventoryRepo
    {
        // a constructor takes AutoLotContext as the parameter  and chain it to the base constructor
        // this will be used by the DI framework in ASP.NET Core to create the repository using one of the pooled 
        //AutoLoContext instances 
        public InventoryRepo(AutoLotContext context): base(context)
        {

        }
        // add the GetAll override and the GetPinkCars() methods 
        public override List<Inventory> GetAll()=>GetAll(x=>x.PetName,true).ToList();
        public List<Inventory> GetPinkCars()=> GetSome(x => x.Color == "Pink");

        //executing A SQL LIKE Query new in EF Core 2.0 is the EF.Functions property that can be 
        // used by database providers to implement specific operations 
        // the first implementtion released for the sql server provider is a .net implementation
        // of the SQL LIKE operator
        public List<Inventory> Search(string searchString)
            => Context.Cars.Where(c => DbFunctions.ReferenceEquals(c.PetName, $"%{searchString}")).ToList();
        //this uses the LIKE function to create sql query searchString == "foo"
        //SELECT * FROM Inventory WHERE PetName like '%foo%'

        // using Include() and ThenInclude for Related Data
        // the final method to add demonstrates the FromSql(),Include(),ThenInclude() methods

        public List<Inventory> GetRelatedData() => Context.Cars.FromSql("Select * From Inventory").
            Include(x => x.orders).ThenInclude(x => x.Customer).ToList();


    }
}
