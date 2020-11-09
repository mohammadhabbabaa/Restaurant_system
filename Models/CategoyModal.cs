using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CategoyModal
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Restourant { get; set; }
        public string Image { get; set; }
        public int RestourantID { get; set; }
       
    }
}