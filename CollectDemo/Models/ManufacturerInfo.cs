using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollectDemo.Models
{
    public class ManufacturerInfo
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public virtual List<BaseballCard> BaseballCard { get; set; }
    }
}