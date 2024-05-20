
using Categories.Service.API.GraphQl.Queries;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories;
using ServerLibrary.Repositories.IRepositories;

namespace Categories.Service.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddTransient<AppDbContext>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddGraphQLServer()
                .AddQueryType<CategoryQuery>();
                //.AddMutationType<CategoryMutation>();

            builder.Services.AddControllers();
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
        }
    }
}
