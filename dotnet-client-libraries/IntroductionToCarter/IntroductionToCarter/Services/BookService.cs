using IntroductionToCarter.Contracts;
using IntroductionToCarter.Data;
using IntroductionToCarter.Data.Exceptions;
using IntroductionToCarter.Data.Models;
using IntroductionToCarter.Services.Abstractions;
using MassTransit;

namespace IntroductionToCarter.Services;

public class BookService(IUnitOfWork unitOfWork) : IBookService
{
    public async Task<BookResponse> CreateAsync(CreateBookRequest createBookRequest, CancellationToken cancellationToken = default)
    {
        var book = new Book
        {
            Id = NewId.NextSequentialGuid(),
            Title = createBookRequest.Title,
            Author = createBookRequest.Author,
            ISBN = createBookRequest.ISBN,
            Year = createBookRequest.Year
        };

        unitOfWork.BookRepository.Insert(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BookResponse(
            book.Id,
            book.Title,
            book.Author,
            book.ISBN,
            book.Year);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await unitOfWork.BookRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new BookNotFoundException(id);

        unitOfWork.BookRepository.Remove(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<BookResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var books = await unitOfWork.BookRepository
            .GetAllAsync(cancellationToken);

        var bookResponses = new List<BookResponse>();

        foreach (var book in books)
        {
            bookResponses.Add(
                new BookResponse(
                    book.Id,
                    book.Title,
                    book.Author,
                    book.ISBN,
                    book.Year));
        }

        return bookResponses;
    }

    public async Task<BookResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await unitOfWork.BookRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new BookNotFoundException(id);

        return new BookResponse(
            book.Id,
            book.Title,
            book.Author,
            book.ISBN,
            book.Year);
    }

    public async Task UpdateAsync(Guid id, UpdateBookRequest updateBookRequest, CancellationToken cancellationToken = default)
    {
        var book = await unitOfWork.BookRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new BookNotFoundException(id);

        book.Title = updateBookRequest.Title;
        book.Author = updateBookRequest.Author;
        book.ISBN = updateBookRequest.ISBN;
        book.Year = updateBookRequest.Year;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
