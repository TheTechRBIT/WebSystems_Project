using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollectDemo.Models
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }
        public string CoachName { get; set; }
        public virtual List<BaseballCard> BaseballCard { get; set; }
    }
}