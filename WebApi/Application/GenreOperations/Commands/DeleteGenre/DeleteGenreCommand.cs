using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g=>g.Id == GenreId);

            if(genre is null)
            {
                throw new InvalidOperationException("Bu Id'e Sahip Bir Tür Bulunmamakta");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }

    }
}