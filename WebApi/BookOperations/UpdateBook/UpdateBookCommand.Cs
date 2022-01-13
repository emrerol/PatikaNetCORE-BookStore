using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {

    public UpdateBookModel Model {get; set;}
    private readonly BookStoreDbContext _dbContext;
    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public void Handle(int id)
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);

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