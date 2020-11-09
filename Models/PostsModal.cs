using ApiConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PostsModal
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }

        public virtual List<ExstraIngredient> ExstraIngredients { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }



    }
}