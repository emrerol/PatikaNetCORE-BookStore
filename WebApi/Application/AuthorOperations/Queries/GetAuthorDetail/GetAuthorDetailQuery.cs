using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperarions.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        

        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorViewModelById  Handle()
        {
            var author = _dbContext.Authors.Where(a=>a.Id  == AuthorId).SingleOrDefault();
            if(author is null){
                throw new InvalidOperationException("Yazar Bulunamadı");
            }
            AuthorViewModelById authorViewModelById = _mapper.Map<AuthorViewModelById>(author);
            return authorViewModelById;
        }

    }

     public class AuthorViewModelById
     {
         public string Name {get; set;}
         public string  Surname { get; set; }
         public DateTime DateOfBirth { get; set; }
     }
}