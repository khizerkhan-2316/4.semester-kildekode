using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lektion_11___MVC_APS.NET_1.Models
{
    public class HomeModel
    {
        public int Id { get; set; } 

        public HomeModel(int id)
        {
            Id = id;
        }
    }
}