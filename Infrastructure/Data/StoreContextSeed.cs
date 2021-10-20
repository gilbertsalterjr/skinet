using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                 if (!context.Categories.Any())
                 {
                     var categoryData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                     var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                     foreach (var item in categories)
                     {
                         context.Categories.Add(item);
                     }

                     await context.SaveChangesAsync();
                 }

                  if (!context.Products.Any())
                 {
                     var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                     var products = JsonSerializer.Deserialize<List<Product>>(productData);

                     foreach (var item in products)
                     {
                         context.Products.Add(item);
                     }

                     await context.SaveChangesAsync();
                 }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
            }
            
        }
    }
}