using System;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public int BookId {get; set;}
        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public BooksViewModelById Handle()
        {
            var book = _dbContext.Books.Where(b => b.Id == BookId).SingleOrDefault();
            if(book is null){
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BooksViewModelById vmId =  _mapper.Map<BooksViewModelById>(book);
            return vmId;
        }
    }

    public class BooksViewModelById
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}