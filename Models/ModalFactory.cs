using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiConnect;

namespace WebApi.Models
{
    public  class ModalFactory
    { 
        public  CategoyModal create(Category category)
        {
            return  new CategoyModal
            {

                ID = category.ID,
                Name = category.Name,
                Image = category.Image,
                Restourant = category.Restourant.Name,
                RestourantID =category.Restourant.ID,
               

            };

        }
        public  OderModal create(Order order)
        {
            return new OderModal
            {
                ID = order.ID,
                Restourant = order.Table.Restourant.Name,
                Prodcut = order.Product.Title
              
            };

        }
        public  SubCategoryModal create(SubCategory subcategory)
        {
            return  new SubCategoryModal
            {

                ID = subcategory.ID,
                Name = subcategory.Name,
                Image = subcategory.Image,
      
                CategoryID = subcategory.CategoryID,

            };

        }
        public  PostsModal create(Product product)
        {
            return  new PostsModal
            {

                ID = product.ID,
                Title = product.Title,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
               
                
                
            };

        }
        public  TableModal create(Table table)
        {
            return  new TableModal
            {
                ID=table.ID,
                RestourantID = table.RestourantID,
                
                
            };

        }

      
    }
}