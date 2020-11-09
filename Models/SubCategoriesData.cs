using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SubCategoriesData
    {
        public List<SubCategoryModal> subcategories { get; set; }
        public string Error { get; set; }
    }
}