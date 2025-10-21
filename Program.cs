
using HannahElSayed0523003.DatabaseConnection;
using HannahElSayed0523003.Repos;
using HannahElSayed0523003.Repos.CoachRepos;
using HannahElSayed0523003.Repos.CompetitionRepos;
using HannahElSayed0523003.Repos.PlayerRepos;
using HannahElSayed0523003.Repos.TeamRepos;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<ICompetitionRepo, CompetitionRepo>();
            builder.Services.AddScoped<ITeamRepo, TeamRepo>();
            builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
            builder.Services.AddScoped<ICoachRepo, CoachRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
