using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CategoriedData
    {
        public List<CategoyModal> categories { get; set; }
        public string Error { get; set; }

    }
}