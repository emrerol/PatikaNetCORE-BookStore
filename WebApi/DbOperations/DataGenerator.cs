using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                
                context.Authors.AddRange(
                    new Author{
                        Name = "Umberto",
                        Surname = "Eco",
                        DateOfBirth = new DateTime(1920,10,15)
                    },
                    new Author{
                        Name = "Hannah",
                        Surname = "Arendt",
                        DateOfBirth = new DateTime(1895,6,22)
                    },
                    new Author{
                        Name = "John",
                        Surname = "Steinbeck",
                        DateOfBirth = new DateTime(1902,2,27)
                    }
                );


                context.Genres.AddRange(
                    new Genre{
                        Name = "Fiction",
                    },
                    new Genre {
                        Name = "History",
                    },
                    new Genre {
                        Name = "Science",
                    }
                );


                context.Books.AddRange 
                (
                    new Book
                    {
                        Title = "Gülün Adı",
                        GenreId = 1,
                        PageCount = 680,
                        PublishDate = new DateTime(1964, 6, 15)
                    },
                    new Book
                    {
                        Title = "Kötülüğün Sıradanlığı",
                        GenreId = 2, 
                        PageCount = 300,
                        PublishDate = new DateTime(1958, 9, 23)
                    },
                    new Book
                    {
                        Title = "İnci",
                        GenreId = 1, 
                        PageCount = 120,
                        PublishDate = new DateTime(1975, 4, 16)
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}