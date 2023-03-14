
using FilmEHistoryReviewBackend.Core.Manager;
using FilmEHistoryReviewBackend.Core.Service;
using FilmEHistoryReviewBackend.DB;

namespace FilmEHistoryReviewBackend.RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Aggiungo l'abilitazione ai Cors per il mio programma
            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            /*** Aggiungo un Singleton per il quale indico che possiedo un'interfaccia che dichiara i metodi di storing (IStorageService) e che la classe che 
             * implementa questi metodi è MySqlStorageService ***/
            builder.Services.AddSingleton<IStorageService, MySqlStorageService>();
            // Aggiungo un Singleton al quale assegno la classe che mi consente di gestire lo storing attraverso la dependency injection 
            builder.Services.AddSingleton<ReviewManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Definisco i permessi dei Cors
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}