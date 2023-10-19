using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ready
{
    public class Catalog
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> SearchByTitle(string searchByTitle)
        {
            return books.Where(book => book.Title.Contains(searchByTitle)).ToList();
        }

        public List<Book> SearchByAuthor(string searchByAuthor)
        {
            return books.Where(book => book.Author.Contains(searchByAuthor)).ToList();
        }

        public List<Book> SearchByISBN(string searchByISBN)
        {
            return books.Where(book => book.ISBN == searchByISBN).ToList();
        }

        public List<Book> SearchByKeywords(List<string> keywords)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (keywords.Count(keyword => book.Title.Contains(keyword) || book.Annotation.Contains(keyword)) != 0)
                    result.Add(book);
            }
            return result;
        }
    }
}
