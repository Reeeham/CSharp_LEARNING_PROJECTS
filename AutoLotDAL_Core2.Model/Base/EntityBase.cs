using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL_Core2.Models.Base
{
    public class EntityBase
    {
        //The primary key (Id) will be a sequence in SQL Server, and the Timestamp column will be used for
        //concurrency checking.These work the same as their EF 6 versions.
        
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
