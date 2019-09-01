namespace _3_MVCApplication.Managers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using _3_MVCApplication.Models; // prepei na kaneis add to namespace tou project

    public class WatchDb : DbContext
    {
        // Your context has been configured to use a 'WatchDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_3_MVCApplication.Managers.WatchDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WatchDb' 
        // connection string in the application configuration file.
        public WatchDb()
            : base("name=WatchDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

            //oi klaseis einai se eniko kai to antistoixo dbset ths einai se plhthyntiko
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
    }
}