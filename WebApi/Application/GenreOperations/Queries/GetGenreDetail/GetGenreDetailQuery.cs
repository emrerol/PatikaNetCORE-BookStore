using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g=>g.IsActive && g.Id==GenreId);

            if(genre is null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı");
            }
            return _mapper.Map<GenreDetailViewModel>(genre);
        }

    }


    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}