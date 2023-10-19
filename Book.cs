using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ready
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Genres { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Annotation { get; set; }
        public string ISBN { get; set; }
        public bool KeywordFoundInAnnotation { get; set; }

        //выборка информации о книге, без аннотации
        public void PrintInfo()
        {
            Console.WriteLine($"Название книги: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Жанры: {string.Join(", ", Genres)}");
            Console.WriteLine($"Дата публикации: {PublicationDate.ToShortDateString()}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine();
        }
    }
}
