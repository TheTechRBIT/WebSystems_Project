using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CollectDemo.Models
{
    public class UserBaseballCardCollection
    {

        [Key]
        public int CollectionCardID { get; set; }
        private string UserID { get; set; }
        public int BaseballCardID { get; set; }
        public virtual BaseballCard BaseballCard { get; set; }
        public string CardNumber { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public int? PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public int? CoachID { get; set; }
        public virtual Coach Coach { get; set; }
        public int? PositionID { get; set; }
        public virtual Position Position { get; set; }
        public int PlayerNumber { get; set; }
        public int? ManufacturerID { get; set; }
        public virtual ManufacturerInfo ManufacturerInfo { get; set; }
        public int CardYear { get; set; }


    }
}