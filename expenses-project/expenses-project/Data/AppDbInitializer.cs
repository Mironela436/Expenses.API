using expenses_project.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace expenses_project.Data
{
    public class AppDbInitializer
    {

        public static void Seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= serviceScope.ServiceProvider.GetService <AppDbContext>();

                if (!context.expenses.Any())

                {
                    context.expenses.AddRange(new expense()
                    {
                        Description = "Vegetables",
                        Amount = 301.62,

                    },

                    new expense()
                    {
                        Description = "Sweets",
                        Amount= 712,
                    },

                    new expense()
                    {
                        Description="Meat",
                        Amount=1000,
                    },

                    new expense()
                    {
                        Description = "Cheese",
                        Amount=400,
                    },




                     new expense()
                    {
                        Description = "Fruits",
                        Amount = 425.3,

              });

                    context.SaveChanges();
                }
            }
        }
    }
}
