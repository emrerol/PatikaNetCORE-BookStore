using AutoMapper;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.AuthorOperarions.Queries.GetAuthors;
using WebApi.Application.AuthorOperarions.Queries.GetAuthorDetail;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book, BooksViewModelById>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre,GenresViewModel>();

            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Genre, UpdateGenreViewModel>();

            CreateMap<Author, AuthorViewModel>();

            CreateMap<Author, AuthorViewModelById>();
            
            

        }
    }
}