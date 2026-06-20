using HumanResource.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
namespace HumanResource.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            //if (isProd)
            //{
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            //}

            if (!context.Employees.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Employees.AddRange(
                    new Models.Employee() { 
                        FirstName = "John", 
                        LastName = "Doe", Email = " ", 
                        DateOfBirth = new DateTime(1990, 1, 1), 
                        Position = "Software Engineer", 
                        Salary = 60000, Department = 1, PhoneNumber = "123-456-7890", 
                        HireDate = DateTime.Now, IsActive = true
                    },
                    new Models.Employee() { 
                        FirstName = "Jane", 
                        LastName = "Smith", 
                        Email = " ", 
                        DateOfBirth = new DateTime(1985, 5, 15), 
                        Position = "Project Manager", 
                        Salary = 75000 
                        , Department = 2, PhoneNumber = "987-654-3210",
                        HireDate = DateTime.Now, IsActive = true
                    });

                    context.SaveChanges();
            }        
        }    
    }
}
    