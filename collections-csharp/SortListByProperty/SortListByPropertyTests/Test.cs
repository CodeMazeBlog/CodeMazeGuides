using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortListByProperty.Tests
{
    [TestClass]
    public class Test
    {
        private static List<Book> _books;
        private static List<Book> _booksSortedTitle;
        private static List<Book> _booksSortedAuthorPages;
        private static List<Book> _booksSortedPages;

        private static readonly Book gatsby = new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 279 };
        private static readonly Book lotr = new Book { Title = "The Lord Of The Rings", Author = "J.R.R. Tolkien", Pages = 1216 };
        private static readonly Book pride = new Book { Title = "Pride & Prejudice", Author = "Jane Austen", Pages = 329 };
        private static readonly Book emma = new Book { Title = "Emma", Author = "Jane Austen", Pages = 1036 };

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

            Assert.AreEqual(_booksSortedTitle.Count, sortedList.Count);

            for (int i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(_booksSortedTitle[i].Title, sortedList[i].Title);

                Assert.AreEqual(_booksSortedTitle[i].Author, sortedList[i].Author);

                Assert.AreEqual(_booksSortedTitle[i].Pages, sortedList[i].Pages);
            }
        }

        [TestMethod]
        public void WhenOrderByAuthorThenByPages_ThenNewListIsSortedByAuthorAndPages()
        {
            var sort = new Sort();
            var sortedList = sort.SortByAuthorAndPagesUsingLinq(_books);

            Assert.AreEqual(_booksSortedAuthorPages.Count, sortedList.Count);

            for (int i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(_booksSortedAuthorPages[i].Title, sortedList[i].Title);

                Assert.AreEqual(_booksSortedAuthorPages[i].Author, sortedList[i].Author);

                Assert.AreEqual(_booksSortedAuthorPages[i].Pages, sortedList[i].Pages);
            }
        }

        [TestMethod]
        public void WhenUsingIComparableByPages_ThenSameListIsSortedByPages()
        {
            _books.Sort();

            Assert.AreEqual(_booksSortedPages.Count, _books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                Assert.AreEqual(_booksSortedPages[i].Title, _books[i].Title);

                Assert.AreEqual(_booksSortedPages[i].Author, _books[i].Author);

                Assert.AreEqual(_booksSortedPages[i].Pages, _books[i].Pages);
            }
        }

        [TestMethod]
        public void WhenUsingIComparerByTitle_ThenSameListIsSortedByTitle()
        {
            _books.Sort(new SortBookByTitle());

            Assert.AreEqual(_booksSortedTitle.Count, _books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                Assert.AreEqual(_booksSortedTitle[i].Title, _books[i].Title);

                Assert.AreEqual(_booksSortedTitle[i].Author, _books[i].Author);

                Assert.AreEqual(_booksSortedTitle[i].Pages, _books[i].Pages);
            }
        }

        [TestMethod]
        public void WhenUsingComparisonDelegateByTitle_ThenSameListIsSortedByTitle()
        {
            var bookComparer = new Comparison<Book>(Sort.CompareBooks);

            _books.Sort(bookComparer);

            Assert.AreEqual(_booksSortedTitle.Count, _books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                Assert.AreEqual(_booksSortedTitle[i].Title, _books[i].Title);

                Assert.AreEqual(_booksSortedTitle[i].Author, _books[i].Author);

                Assert.AreEqual(_booksSortedTitle[i].Pages, _books[i].Pages);
            }
        }

        [TestMethod]
        public void WhenUsingComparisonDelegateLambdaByTitle_ThenSameListIsSortedByTitle()
        {
            _books.Sort((x, y) => x.Title.CompareTo(y.Title));

            Assert.AreEqual(_booksSortedTitle.Count, _books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                Assert.AreEqual(_booksSortedTitle[i].Title, _books[i].Title);

                Assert.AreEqual(_booksSortedTitle[i].Author, _books[i].Author);

                Assert.AreEqual(_booksSortedTitle[i].Pages, _books[i].Pages);
            }
        }
    }
}