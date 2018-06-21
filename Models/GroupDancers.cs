using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DancerWeb.Models
{
    public class GroupDancers
    {
        public int Id { set; get; }
        
        public string Name { set; get; }

     
        public List<Dancers> Dancers { get; set; }
    }
}