using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ProductsData
    {
        public List<PostsModal> products { get; set; }

        public string Error { get; set; }
    }
}