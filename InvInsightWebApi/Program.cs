using InvInsightWebApi.Data;
using InvInsightWebApi.Services;
using InvInsightWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvInsightWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataDirectoryPath = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}Data\\";
            Directory.CreateDirectory(dataDirectoryPath);

            var builder = WebApplication.CreateBuilder(args);

            var databaseFileName = builder.Configuration.GetValue<string>("DatabaseFileName");
            var connectionString = DbInitializer.CreateConnectionString(dataDirectoryPath, databaseFileName);
            builder.Services.AddDbContext<InventoryContext>(options =>
                options.UseSqlite(connectionString)
            );

            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddControllers();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<InventoryContext>();
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}