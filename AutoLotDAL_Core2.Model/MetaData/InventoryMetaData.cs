using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL_Core2.Models.Base
{
    public class InventoryMetaData
    {
        [Display(Name = "Pet Name")]
        public string PetName;
        [StringLength(50, ErrorMessage = "Please enter a value less than 50 characters long.")]
        public string Make;
    }
}
