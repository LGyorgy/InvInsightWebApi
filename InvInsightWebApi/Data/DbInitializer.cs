using InvInsightWebApi.Models;
using Microsoft.Data.Sqlite;

namespace InvInsightWebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InventoryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new()
                {
                    Id = 1,
                    Name = "Dummy Product 1",
                    Sku = "DMMY-PRDCT-1",
                    Description = "Dummy Product 1 description.",
                    Category = "Dummies",
                    Price = 1.99,
                    Cost = 0.99,
                    Supplier = "DummySupplier"
                },
                new()
                {
                    Id = 2,
                    Name = "Dummy Product 2",
                    Description = "Dummy Product 2 description.",
                    Sku = "DMMY-PRDCT-2",
                    Category = "Dummies",
                    Price = 2.99,
                    Cost = 1.49,
                    Supplier = "DummySupplier"
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        public static string CreateConnectionString(string dataDirectoryPath, string databaseFileName)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            var databasePath = $"{dataDirectoryPath}{databaseFileName}";
            connectionStringBuilder.DataSource = databasePath;
            return connectionStringBuilder.ToString();
        }
    }
}
