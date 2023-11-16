using System;
using System.Collections.Generic;
using Xunit;

namespace Lab2ready.Tests
    {
    public class UnitTest1
    {
        [Fact]
        public void AddBook_ShouldAddBookToCatalog()
        {
            Catalog catalog = new Catalog();
            Book book = new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "34091827465" };

            catalog.AddBook(book);

            Assert.Contains(book, catalog.books); //проверяем, что книга добавилась в каталог
        }

        [Theory]
        [InlineData("War", 1)]
        [InlineData("Make a Peace", 1)]
        [InlineData("Peace", 3)]
        [InlineData("Five", 0)]
        public void SearchByTitle_ShouldReturnMatchingBooks(string searchTerm, int expectedCount)
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book { Title = "War and Peace", Author = "Lev Tolstoy", ISBN = "19281301313" });
            catalog.AddBook(new Book { Title = "Eat, pray, Peace", Author = "Liz Gilbert", ISBN = "129182917389" });
            catalog.AddBook(new Book { Title = "Make a Peace", Author = "Maria Bazilevich", ISBN = "55531317389" });

            List<Book> result = catalog.SearchByTitle(searchTerm);

            Assert.Equal(expectedCount, result.Count); //сравниваем количества найденных книг
        }

        [Theory]
        [InlineData("Lev Tolstoy", "War and Peace")]
        [InlineData("Liz Gilbert", "Eat, pray, Peace")]
        [InlineData("Maria Bazilevich", "Do good things")]
        public void SearchByAuthor_ShouldReturnMatchingBooks(string searchTerm, string expectedBookTitle)
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book { Title = "War and Peace", Author = "Lev Tolstoy", ISBN = "19281301313" });
            catalog.AddBook(new Book { Title = "Eat, pray, Peace", Author = "Liz Gilbert", ISBN = "129182917389" });
            catalog.AddBook(new Book { Title = "Make a Peace", Author = "Maria Bazilevich", ISBN = "55531317389" });
            catalog.AddBook(new Book { Title = "Do good things", Author = "Maria Bazilevich", ISBN = "46731317389" });

            List<Book> result = catalog.SearchByAuthor(searchTerm);

            Assert.Contains(result, book => book.Title == expectedBookTitle); // проверяем наличие книги с ожидаемым заголовком
        }


        [Theory]
        [InlineData("19281301313", "War and Peace")]
        [InlineData("129182917389", "Eat, pray, Peace")]
        [InlineData("46731317389", "Do good things")]
        public void SearchByISBN_ShouldReturnMatchingBooks(string searchTerm, string expectedBookTitle)
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book { Title = "War and Peace", Author = "Lev Tolstoy", ISBN = "19281301313" });
            catalog.AddBook(new Book { Title = "Eat, pray, Peace", Author = "Liz Gilbert", ISBN = "129182917389" });
            catalog.AddBook(new Book { Title = "Make a Peace", Author = "Maria Bazilevich", ISBN = "55531317389" });
            catalog.AddBook(new Book { Title = "Do good things", Author = "Maria Bazilevich", ISBN = "46731317389" });

            List<Book> result = catalog.SearchByISBN(searchTerm);

            Assert.Contains(result, book => book.Title == expectedBookTitle); // проверяем наличие книги с ожидаемым заголовком
        }

        [Theory]
        [InlineData("War", 1)]
        [InlineData("Make pray good and", 4)]
        [InlineData("Peace", 3)]
        [InlineData("in", 2)]
        [InlineData("craziness", 0)]
        public void SearchByKeywords_ShouldReturnMatchingBooks(string searchTerm, int expectedCount)
            {
                Catalog catalog = new Catalog();
                catalog.AddBook(new Book { Title = "War and Peace", Author = "Lev Tolstoy", ISBN = "19281301313", Annotation = "A novel about war and peace" });
                catalog.AddBook(new Book { Title = "Eat, pray, Peace", Author = "Liz Gilbert", ISBN = "129182917389", Annotation = "A journey of self-discovery" });
                catalog.AddBook(new Book { Title = "Make a Peace", Author = "Maria Bazilevich", ISBN = "55531317389", Annotation = "Promoting peace in the world" });
                catalog.AddBook(new Book { Title = "Do good things", Author = "Maria Bazilevich", ISBN = "46731317389", Annotation = "A guide to doing good in life" });

                List<Book> result = catalog.SearchByKeywords(searchTerm.Split().ToList());

                Assert.Equal(expectedCount, result.Count);
            }
        }
    }