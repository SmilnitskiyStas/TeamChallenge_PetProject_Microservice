
using Brands.Service.API.GraphQl.Mutations;
using Brands.Service.API.GraphQl.Queries;
using Brands.Service.API.GraphQl.Subscriptions;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories;
using ServerLibrary.Repositories.IRepositories;

namespace Brands.Service.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddTransient<AppDbContext>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();

            builder.Services.AddGraphQLServer()
                .AddQueryType<BrandQuery>()
                .AddMutationType<BrandMutation>()
                .AddSubscriptionType<BrandSubscription>()
                .AddInMemorySubscriptions();

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
            app.UseWebSockets(); // For Subscription

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();
            app.MapControllers();

            app.Services.GetRequiredService<AppDbContext>();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                IDbContextFactory<AppDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();

                using (AppDbContext context = contextFactory.CreateDbContext())
                {
                    context.Database.Migrate();
                }
            }

            app.Run();
        }
    }
}
