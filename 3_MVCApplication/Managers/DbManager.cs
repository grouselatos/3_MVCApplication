using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3_MVCApplication.Models;
using System.Data.Entity;

namespace _3_MVCApplication.Managers
{
    public class DbManager
    {
        public ICollection<Actor> GetActors()
        {
            ICollection<Actor> ReturnedActors;
            using (WatchDb db = new WatchDb())
            {
                ReturnedActors = db.Actors.ToList();
            }

            return ReturnedActors;
        }

        public void AddActor(Actor actor)
        {
            using (WatchDb db = new WatchDb())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }

        }

        public Actor GetActor(int id)
        {
            Actor result;
            using (WatchDb db = new WatchDb())
            {
                result = db.Actors.Find(id);
            }

            return result;
        }

        public void UpdateActor(Actor actor)
        {
            using (WatchDb db = new WatchDb())
            {
                #region First way example, not used
                ////aploikos tropos skepshs kai mh fysiologikos/apodotikos
                //Actor db_actor = db.Actors.Find(actor.Id); // vres mou apo th vash ton actor me to id pou psaxnw (to entity framework to kanei track afou proilthe apo th vash
                //db_actor.Name = actor.Name; // update first property
                //db_actor.Age = actor.Age; // update second property
                //db.SaveChanges();
                #endregion
                //kanonikos tropos
                db.Actors.Attach(actor); //kane mou attach ton actor sto db set
                db.Entry(actor).State = EntityState.Modified; //dld allakse tou to entity framework state. edw to entity ksekinaei na parakolouthei th metavlhth kai tou lew ti allagh egine
                db.SaveChanges();
            }
        }

        public void DeleteActor(int id)
        {
            using (WatchDb db = new WatchDb())
            {
                Actor actor = db.Actors.Find(id);
                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }

        public ICollection<Director> GetDirectors()
        {
            ICollection<Director> ReturnedDirectors;
            using (WatchDb db = new WatchDb())
            {
                ReturnedDirectors = db.Directors.ToList();
            }

            return ReturnedDirectors;
        }

        public void AddDirector(Director director)
        {
            using (WatchDb db = new WatchDb())
            {
                db.Directors.Add(director);
                db.SaveChanges();
            }

        }

        public Director GetDirector(int id)
        {
            Director result;
            using (WatchDb db = new WatchDb())
            {
                result = db.Directors.Find(id);
            }

            return result;
        }

        public void UpdateDirector(Director director)
        {
            using (WatchDb db = new WatchDb())
            {
                //kanonikos tropos
                db.Directors.Attach(director); //kane mou attach ton actor sto db set
                db.Entry(director).State = EntityState.Modified; //dld allakse tou to entity framework state. edw to entity ksekinaei na parakolouthei th metavlhth kai tou lew ti allagh egine
                db.SaveChanges();
            }
        }

        public void DeleteDirector(int id)
        {
            using (WatchDb db = new WatchDb())
            {
                Director director = db.Directors.Find(id);
                db.Directors.Remove(director);
                db.SaveChanges();
            }
        }

        public ICollection<Category> GetCategories()
        {
            ICollection<Category> result;
            using (WatchDb db = new WatchDb())
            {
                result = db.Categories.ToList();
            }

            return result;
        }

        public Category GetCategory(string name)
        {
            Category result;
            using (WatchDb db = new WatchDb())
            {
                result = db.Categories.Find(name);
            }
            return result;
        }

        public void AddCategory(Category category)
        {
           using (WatchDb db = new WatchDb())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string name)
        {
            using (WatchDb db = new WatchDb())
            {
                Category category = db.Categories.Find(name);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public ICollection<Movie> GetMovies()
        {
            ICollection<Movie> ReturnedMovies;
            using (WatchDb db = new WatchDb())
            {
                ReturnedMovies = db.Movies
                                   .Include("Category")
                                   .Include("Director")
                                   .Include("Actors")
                                   .ToList();
            }
            return ReturnedMovies;
        }

        public void AddMovie(Movie movie, List<int>actorIds)
        {
            using (WatchDb db = new WatchDb())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                foreach (int id in actorIds)
                {
                    Actor actor = db.Actors.Find(id);
                    if (actor != null)
                    {
                        movie.Actors.Add(actor);
                    }
                }
                db.SaveChanges();
            }
        }

        public Movie GetMovie(int id)
        {
            Movie result;
            using (WatchDb db = new WatchDb())
            {
                result = db.Movies.Find(id);
            }
            return result;
        }

        public Movie GetMovieFull(int id)
        {
            Movie result;
            using (WatchDb db= new WatchDb())
            {
                result = db.Movies
                            .Include("Category")
                            .Include("Director")
                            .Include("Actors")
                            .Where(x => x.Id == id)
                            .FirstOrDefault();
            }
            return result;
        }

        public void UpdateMovie(Movie movie, List<int>actorIds)
        {
            using (WatchDb db = new WatchDb())
            {
                db.Movies.Attach(movie);
                db.Entry(movie).Collection("Actors").Load();
                movie.Actors.Clear();
                db.SaveChanges();
                foreach (int id in actorIds)
                {
                    Actor actor = db.Actors.Find(id);
                    if (actor != null)
                    {
                        movie.Actors.Add(actor);
                    }
                }
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

        public void DeleteMovie(int id)
        {
            using (WatchDb db = new WatchDb())
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

    }
}