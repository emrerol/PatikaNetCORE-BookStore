using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksByIdQuery(BookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public BooksViewModelById Handle(int id)
        {
            var book = _dbContext.Books.Where(b => b.Id == id).SingleOrDefault();
            BooksViewModelById vmId = new BooksViewModelById();
            vmId.Title = book.Title;
            vmId.Genre = ((GenreEnum)book.GenreId).ToString();
            vmId.PageCount = book.PageCount;
            vmId.PublishDate = book.PublishDate.Date.ToString("gg/MM/yyy");  
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