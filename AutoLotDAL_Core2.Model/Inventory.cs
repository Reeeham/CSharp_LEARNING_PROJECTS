using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDAL_Core2.Models.Base;

namespace AutoLotDAL_Core2.Models
{
    [Table("Inventory")]
    public partial class Inventory : EntityBase
    {
        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string PetName { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        //the Orders property is defined as a List<Order> instead of an ICollection<Order>/HashSet<Order>
        //combination. in EF6 
        public List<Order> orders { get; set; } = new List<Order>();
    }
}
