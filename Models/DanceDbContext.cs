using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DancerWeb.Models;

namespace DancerWeb.Controllers
{
    public class DanceDbContext : DbContext
    {



        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Dancers> Dancers { get; set; }

        public DbSet<GroupDancers> GroupDancers { get; set; }

        public System.Data.Entity.DbSet<DancerWeb.Models.UserLogin> UserLogins { get; set; }
    }
}