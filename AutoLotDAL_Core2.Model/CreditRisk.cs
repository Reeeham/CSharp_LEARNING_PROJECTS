
using System.ComponentModel.DataAnnotations;
using AutoLotDAL_Core2.Models.Base;

namespace AutoLotDAL_Core2.Models
{
    public partial class CreditRisk : EntityBase
    {
        // prop tab +2
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

    }
}
