using FilmEHistoryReviewBackend.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.DB
{
    /*** Implemento una classe che tenga allineato il contesto dell'applicazione con il database. La classe estende DbContext (che è classe dell'Entity Framework) 
     * e permette, attraverso le proprietà di DbContext stesso, di interagire con il DB e gestire le migrations ***/
    public class ApplicationContext : DbContext
    {
        // Dichiaro un DbSet (collezione di dati) di ReviewEntity (la trasposizione a codice della tabella)
        public DbSet<ReviewEntity> Reviews { get; set; }

        // Implemento un metodo OnConfigurinf per la configurazione del DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var version = new MySqlServerVersion(new Version(8, 0, 30));
            var connectionString = "Server = localhost; Port = 3306; Database = film_history_db; Uid = root; Pwd = Rt28p4";

            optionsBuilder.UseMySql(connectionString, version);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
