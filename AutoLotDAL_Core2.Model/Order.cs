using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDAL_Core2.Models.Base;

namespace AutoLotDAL_Core2.Models
{
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        //The only change is the removal of the virtual modifier from the two navigation properties.
        [ForeignKey(nameof(CarId))]
        public Inventory Car { get; set; }

    }
}