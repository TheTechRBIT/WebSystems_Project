using CollectDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class CollectContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public CollectContext() : base("name=CollectContext")
    {
    }

    public System.Data.Entity.DbSet<CollectDemo.Models.ManufacturerInfo> ManufacturerInfo { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.BaseballCard> BaseballCard { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.Player> Player { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.Coach> Coach { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.Team> Team { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.Position> Position { get; set; }
    public System.Data.Entity.DbSet<CollectDemo.Models.UserBaseballCardCollection> UserBaseballCardCollection { get; set; }


}
