using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projekt___Biblioteka_Ksiazek
{
    public interface IWorkWithLibrary
    {
        bool doWeHaveThisBookInLibrary(string bookName);
        string[] getAllBooksFromThisAuthor(string AuthorName);
        void getAllAuthors();
        void removeAuthorWithBooks(string AuthorName);
        void addAuthor();
        void addBookToAuthor(string book);
        int getLibrarySize();

    }
    public class WorkWithLibrary : IWorkWithLibrary
    {
        Storage storage = new Storage();

        public void addAuthor()
        {
            Author author = makeAuthor();
            Console.WriteLine();
            Console.WriteLine("Czy chcesz dodać samego autora?(tak/nie)");
            string doWeWannaAddBook = Console.ReadLine().ToLower().Trim();
            switch (doWeWannaAddBook)
            {
                case "tak":
                    storage.addAuthorWithBookToLibrary(author, null);
                    break;
                case "nie":
                    string[] books = addBooks();
                    storage.addAuthorWithBookToLibrary(author, books);
                    break;
                    default:
                    Console.WriteLine("błąd");
                    break;
            }

        }
        public void addDefaultAuthorWithBooks(Author author, string[] books)
        {
            storage.addAuthorWithBookToLibrary(author, books);
        }
        public void addBookToAuthor(string book)
        {
            Console.WriteLine("Do jakiego autora chcesz dodać książkę?");
            string author = Console.ReadLine().ToLower().Trim();

            Author author2 = storage.getAuthorByName(author);
            bool isInArray = false;
            foreach (Author element in storage.authors())
            {
                if(element == author2)
                {
                    isInArray = true;
                }
            }
            if(isInArray)
            storage.addBookToAuthor(author2 , book);
        }

        public bool doWeHaveThisBookInLibrary(string bookName)
        {
            return storage.containsBook(bookName);
        }

        public void getAllAuthors()
        {
            storage.getAuthors();
        }

        public string[] getAllBooksFromThisAuthor(string AuthorName)
        {
            Author author = storage.getAuthorByName(AuthorName);
            bool isInArray = false;
            foreach (Author element in storage.authors())
            {
                if (element == author)
                {
                    isInArray = true;
                }
            }
            if (isInArray)
            {
                return storage.getBooksFromAuthor(author);
            }

            return new string[0];
        }

        public int getLibrarySize()
        {
            return storage.size();
        }

        public void removeAuthorWithBooks(string AuthorName)
        {
            storage.removeAuthorWithBooksFromLibrary(AuthorName);
        }

        public void removeBookFromAuthor(string AuthorName, string book)
        {
            Author author = storage.getAuthorByName(AuthorName);
            bool isInArray = false;
            foreach (Author element in storage.authors())
            {
                if (element == author)
                {
                    isInArray = true;
                }
            }
            if (isInArray)
            {

                storage.removeBookFromAuthor(author, book);
                Console.WriteLine("Książka została usunięta \n");
                return;
            }
            Console.WriteLine("Takiej książki nie ma");

        }
        public void printLibrary()
        {
            Console.WriteLine(storage.printLibrary());
        }


        //-------------------------------------------------------------------------------------------------------------------------
        private string[] addBooks()
        {
            string czyDodajemyDalej = "tak";
            List<string> books = new List<string>();
            while (czyDodajemyDalej.Equals("tak"))
            {
                Console.WriteLine("\nPodaj książkę jaką chcesz dodać");
                books.Add(Console.ReadLine().ToLower().Trim());

                Console.WriteLine();
                Console.WriteLine("Czy chcesz dodać kolejne książki?(tak/nie)");
                do
                {
                    czyDodajemyDalej = Console.ReadLine().ToLower().Trim();
                } while (!(czyDodajemyDalej.Equals("tak") || czyDodajemyDalej.Equals("nie")));
            }
            return books.ToArray();
        }

        private Author makeAuthor()
        {
            Console.WriteLine("Podaj imię autora: ");
            string authorName = Console.ReadLine().ToLower().Trim();
            Console.WriteLine("Podaj wiek autora: ");
            int authorAge = int.Parse(Console.ReadLine().ToLower().Trim());
            Console.WriteLine("Czy autor żyje(tak/nie)");
            string cayZyje = Console.ReadLine().ToLower().Trim();
            bool isAlive;
            switch (cayZyje)
            {
                case "tak":
                    isAlive = true;
                    break;
                case "nie":
                    isAlive = false;
                    break;
                default:
                    isAlive = false;
                    break;
            }
            Author author = new Author(authorName, authorAge, isAlive);
            return author;
        }
    }
}
