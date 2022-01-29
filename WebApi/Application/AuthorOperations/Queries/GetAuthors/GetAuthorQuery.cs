using System;
using WebApi.DbOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.Application.AuthorOperarions.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authorList = _dbContext.Authors.ToList();
            List<AuthorViewModel> viewModels = _mapper.Map<List<AuthorViewModel>>(authorList);
            return viewModels;
        }
    }

    public class AuthorViewModel
    {
        public string Name {get; set;}
        public string  Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}