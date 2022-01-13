using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                context.Books.AddRange 
                (
                    new Book
                    {
                        Title = "Gülün Adı",
                        GenreId = 1, //Fiction
                        PageCount = 680,
                        PublishDate = new DateTime(1964, 6, 15)
                    },
                    new Book
                    {
                        Title = "Kötülüğün Sıradanlığı",
                        GenreId = 2, //History
                        PageCount = 300,
                        PublishDate = new DateTime(1958, 9, 23)
                    },
                    new Book
                    {
                        Title = "İnci",
                        GenreId = 1, //Fiction
                        PageCount = 120,
                        PublishDate = new DateTime(1975, 4, 16)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}