using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    
    public class UpdateGenreCommand
    {
        public int GenreId {get; set;}
        private readonly BookStoreDbContext _dbContext;

        public UpdateGenreViewModel Model {get; set;}
        
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g=>g.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Bu Id'e Sahip Bir Tür Bulunmamakta");
            }
            if(_dbContext.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Bu İsme Sahip Başka Bir Tür Zaten Mevcut");
            }

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive {get; set;} = true;
    }
}