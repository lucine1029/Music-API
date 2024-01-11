using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SpelarDuInAPI.Data;
using SpelarDuInAPI.Handlers;
using SpelarDuInAPI.Services;
using static SpelarDuInAPI.Services.IDbHelper;

namespace SpelarDuInAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IDbHelper, DbHelper>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/user/{userId}/genre", GenreHandler.ListUsersGenres);
            app.MapPost("/genre", GenreHandler.AddNewGenre);

            // Endpoints to be added here 

            //The assignment is to create the methods designated to you, you will also create tests for your individual methods!
            //If you feel that you hawe time over, the last 3 post calls are upp for grabs for the person who want to create them 

            //Next checkup will be this monday where the time will be decided on slack later this week,

            //Keep namestandards konsistent, Artist, Genre, Track and User. 

            //Api connection vill be created after our methods are done and workload will be declared after next checkup,
            //The Api decided on is The audio DB, more information about the api is in todo.txt

            //Meny vill be created in console client where we will reuse Spelar du in bank meny functions. 

            //God luck, hawe fun!!!


            // GET Calls
            /*
            app.MapGet("/user"); // H�mta alla personer     Mojtaba           
            app.MapGet("/user/{userId}/genre", GenreHandler.ListUsersGenres); // H�mta alla genre kopplad till en specifik person  Sean
            app.MapGet("/user/{userId}/artist"); // H�mta alla artister kopplad till en specifik person     Jing
            app.MapGet("/user/{userId}/track"); // H�mta alla tracks kopplad till en specifik person        Jonny

            // POST Calls

            app.MapPost("/user"); //skapa ny user   Mojtaba
            app.MapPost("/genre", GenreHandler.CreateNewGenre); //skapa ny genre Sean
            app.MapPost("/artist"); //skapa ny artist   Jing
            app.MapPost("/track"); //skapa ny track     jonny

            app.MapPost("/user/{userId}/genre/{genreId}"); // Kopplar person till ny genre  N/A
            app.MapPost("/user/{userId}/artist/{artistId}"); //  Kopplar person till ny artist  N/A
            app.MapPost("/user/{userId}/track/{trackId}"); // Kopplar person till ny track  N/A
            */


            app.Run();
        }
    }
}
