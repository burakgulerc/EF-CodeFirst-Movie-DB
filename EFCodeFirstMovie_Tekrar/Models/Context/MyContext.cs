using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstMovie_Tekrar.Models.Entities;

namespace EFCodeFirstMovie_Tekrar.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnectionWinAuth")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().Ignore(x => x.ID);
            modelBuilder.Entity<MovieActor>().HasKey(x => new
            {
                x.ActorID,
                x.MovieID
            });

            modelBuilder.Entity<MovieTag>().Ignore(x => x.ID);
            modelBuilder.Entity<MovieTag>().HasKey(x => new
            {
                x.MovieID,
                x.TagID
            });

            modelBuilder.Entity<Actor>().HasOptional(x => x.Profile).WithRequired(x => x.Actor);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorProfile> Profiles { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
