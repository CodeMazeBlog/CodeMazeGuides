using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SortListByProperty.Tests
{
    [TestClass]
    public class Test
    {
        private static List<Book> _books;
        private static List<Book> _booksSortedTitle;
        private static List<Book> _booksSortedAuthorPages;
        private static List<Book> _booksSortedPages;

        private static readonly Book gatsby = new Book
        {
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            Pages = 279
        };

        private static readonly Book lotr = new Book
        {
            Title = "The Lord Of The Rings",
            Author = "J.R.R. Tolkien",
            Pages = 1216
        };

        private static readonly Book pride = new Book
        {
            Title = "Pride & Prejudice",
            Author = "Jane Austen",
            Pages = 329
        };

        private static readonly Book emma = new Book
        {
            Title = "Emma",
            Author = "Jane Austen",
            Pages = 1036
        };

        public Test()
        {
            CreateBookData();
            CreateBookDataSortedByTitle();
            CreateBookDataSortedByAuthorPages();
            CreateBookDataSortedByPages();
        }

        private static void CreateBookData()
        {
            _books = new List<Book>
            {
                gatsby,
                lotr,
                pride,
                emma
            };
        }

        private static void CreateBookDataSortedByTitle()
        {
            _booksSortedTitle = new List<Book>
            {
                emma,
                pride,
                gatsby,
                lotr
            };
        }

        private static void CreateBookDataSortedByAuthorPages()
        {
            _booksSortedAuthorPages = new List<Book>
            {
                gatsby,
                lotr,
                pride,
                emma
            };
        }

        private static void CreateBookDataSortedByPages()
        {
            _booksSortedPages = new List<Book>
            {
                gatsby,
                pride,
                emma,
                lotr
            };
        }

        [TestMethod]
        public void WhenOrderByTitle_ThenNewListIsSortedByTiTle()
        {
            var sort = new Sort();
            var sortedList = sort.SortByTitleUsingLinq(_books);

            CollectionAssert.AreEqual(_booksSortedTitle, sortedList);
        }

        [TestMethod]
        public void WhenOrderByAuthorThenByPages_ThenNewListIsSortedByAuthorAndPages()
        {
            var sort = new Sort();
            var sortedList = sort.SortByAuthorAndPagesUsingLinq(_books);

            CollectionAssert.AreEqual(_booksSortedAuthorPages, sortedList);
        }

        [TestMethod]
        public void WhenUsingIComparableByPages_ThenSameListIsSortedByPages()
        {
            _books.Sort();

            CollectionAssert.AreEqual(_booksSortedPages, _books);
        }

        [TestMethod]
        public void WhenUsingIComparerByTitle_ThenSameListIsSortedByTitle()
        {
            _books.Sort(new SortBookByTitle());

            CollectionAssert.AreEqual(_booksSortedTitle, _books);
        }

        [TestMethod]
        public void WhenUsingComparisonDelegateByTitle_ThenSameListIsSortedByTitle()
        {
            var bookComparer = new Comparison<Book>(Sort.CompareBooks);

            _books.Sort(bookComparer);

            CollectionAssert.AreEqual(_booksSortedTitle, _books);
        }

        [TestMethod]
        public void WhenUsingComparisonDelegateLambdaByTitle_ThenSameListIsSortedByTitle()
        {
            _books.Sort((x, y) => x.Title.CompareTo(y.Title));

            CollectionAssert.AreEqual(_booksSortedTitle, _books);
        }
    }
}