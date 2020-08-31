using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MojoDesignCollection.Models.DB
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            MojoDesignCollectionDbContext context =
                app.ApplicationServices
                    .CreateScope().ServiceProvider.GetService<MojoDesignCollectionDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
           
            if (!context.ProductsDbSet.Any())
            {
 
                context.ProductsDbSet.AddRange(
                    new Product
                    {
                        Category = CategoryEnum.Tutu.ToString(),
                        Description = "“TUTU” is the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2020",
                        InStock = true,
                        Price = 85.00m,
                        Name = "Tutu doll / handmade heirloom doll",
                    },
                    new Product
                    {
                        Category = CategoryEnum.Fairy.ToString(),
                        Description = "“Dandelion dolls” are the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2019",
                        InStock = true,
                        Price = 30.00m,
                        Name = "Fairy / tooth fairy / Handmade doll",
                        Quantity = 1
                    },
                    new Product
                    {
                        Category = CategoryEnum.Tutu.ToString(),
                        Description = "“TUTU” is the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2020",
                        InStock = true,
                        Price = 85.00m,
                        Name = "Tutu, Handmade, Heirloom Fabric doll",
                        Quantity = 1
                    },
                    new Product
                    {
                        Category = CategoryEnum.Tutu.ToString(),
                        Description = "“TUTU” is the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2020",
                        InStock = true,
                        Price = 85.00m,
                        Name = "Tutu doll / handmade heirloom doll",
                        Quantity = 1
                    }  ,
                    new Product
                    {
                        Category = CategoryEnum.Fairy.ToString(),
                        Description = "“Dandelion dolls” are the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2019",
                        InStock = true,
                        Price = 30.05m,
                        Name = "Fairy / tooth fairy / Handmade doll",
                        Quantity = 1
                    },
                    new Product
                    {
                        Category = CategoryEnum.Fairy.ToString(),
                        Description = "“Dandelion dolls” are the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2019",
                        InStock = true,
                        Price = 30.15m,
                        Name = "Fairy / tooth fairy / Handmade doll",
                        Quantity = 1
                    },
                    new Product
                    {
                        Category = CategoryEnum.Fairy.ToString(),
                        Description = "“Dandelion dolls” are the original and unique design exclusive to MojoDesignCollection - ©️Copyright 2019",
                        InStock = true,
                        Price = 30.25m,
                        Name = "Fairy / tooth fairy / Handmade doll",
                        Quantity = 1
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
