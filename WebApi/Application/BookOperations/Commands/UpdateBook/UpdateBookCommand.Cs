using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
       
        public int BookId{get; set;}
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id ==BookId);

            if (book is null)
                throw new Exception("Böyle bir kitap bulunamadı");


            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;

            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }


    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}