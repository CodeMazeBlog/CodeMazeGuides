using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualKeywordInEFCore.Models
{
    public class AuthorInjected
    {
        private ICollection<BookInjected>? _books;

        public AuthorInjected() { }

        private AuthorInjected(ILazyLoader lazyLoader) => LazyLoader = lazyLoader;

        private ILazyLoader? LazyLoader { get; set; }

        public int AuthorInjectedId { get; set; }
        public string? FullName { get; set; }

        public ICollection<BookInjected>? Books
        {
            get => LazyLoader.Load(this, ref _books);
            set => _books = value;
        }
    }
}
