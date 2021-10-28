using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 7.99M,
                        Actors = "Bob Ross"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 8.99M,
                        Actors = "Bob Ross"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 9.99M,
                        Actors = "Bob Ross"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "B",
                        Price = 3.99M,
                        Actors = "Bob Ross"
                    }
                );
                context.Actors.AddRange(
                    new Actors
                    {
                        Firstname = "Jhonny",
                        Lastname = "Dennisson",
                        BirthDay = DateTime.Parse("1952-11-29"),
                        Skills = "Boxing",
                        Networth = 45000.00M
                    },

                    new Actors
                    {
                        Firstname = "Bob",
                        Lastname = "Ross",
                        BirthDay = DateTime.Parse("1942-10-29"),
                        Skills = "Painting",
                        Networth = 4500000.00M
                    },

                    new Actors
                    {
                        Firstname = "Tris",
                        Lastname = "Tennyson",
                        BirthDay = DateTime.Parse("1983-01-19"),
                        Skills = "Dancing",
                        Networth = 780000.00M
                    },

                    new Actors
                    {
                        Firstname = "Danny",
                        Lastname = "Dank",
                        BirthDay = DateTime.Parse("1932-10-01"),
                        Skills = "Funny voices",
                        Networth = 1500000.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}