using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
//using AutoLotDAL.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using AutoLotDAL.MetaData;

namespace AutoLotDAL.Models
{
    [MetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make}+({Color})";
        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make} with ID{ this.CarId}.";

}
    }
}
