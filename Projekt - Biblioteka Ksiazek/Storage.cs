using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Projekt___Biblioteka_Ksiazek
{
    public interface IStorage
    {
        void addBookToAuthor(Author key, string value);
        void addAuthorWithBookToLibrary(Author key, string[] value);
        string[] getBooksFromAuthor(Author key);
        int size();
    }
    public class Storage : IStorage
    {
        private Dictionary<Author, string[]> library = new Dictionary<Author, string[]>();
        public Author[] authors()
        {
            return library.Keys.ToArray();
        }

        public bool containsBook(string value)
        {
            foreach (string[] booksArray in library.Values)
            {
                if (booksArray != null && booksArray.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void removeBookFromAuthor(Author key, string bookToRemove)
        {
            if (library.ContainsKey(key))
            {
                string[] booksArray = library[key];

                if (booksArray != null && booksArray.Contains(bookToRemove))
                {
                    List<string> booksList = booksArray.ToList();
                    booksList.Remove(bookToRemove);
                    library[key] = booksList.ToArray();
                }
            }
        }
        public void getAuthors()
        {
            foreach(Author authors in library.Keys)
            {
                Console.WriteLine("--" + authors.ToString());
            }
        }

        public string[] getBooksFromAuthor(Author key)
        {
            if (library.ContainsKey(key))
            {
                return library[key];
            }
            return new string[0];
        }
        public Author getAuthorByName(string authorName)
        {
            foreach (Author author in library.Keys)
            {
                if (author.Name.Equals(authorName))
                {
                    return author;
                }
            }
            return null;
        }

        public void addBookToAuthor(Author key, string value)
        {
            if (library.ContainsKey(key))
            {
                string[] booksArray = library[key];
                Array.Resize(ref booksArray, booksArray.Length + 1);
                booksArray[booksArray.Length - 1] = value;
                library[key] = booksArray;
            }
            else
            {
                Console.WriteLine("nie ma takiego autora!");
            }
        }

        public void addAuthorWithBookToLibrary(Author key, string[] value)
        {
            library.Add(key, value);
        }

        public void removeAuthorWithBooksFromLibrary(string AuthorName)
        {
            foreach (Author author in library.Keys)
            {
                if(author.Name.Equals(AuthorName)) {
                    library.Remove(author);
                    Console.WriteLine("Autor z książkami został usunięty \n");
                    return;
                }
            }
            Console.WriteLine("Nie mamy takiego autora\n");
        }

        public int size()
        {
            return library.Count;
        }

        public virtual string printLibrary()
        {
            string result = "Library Contents:\n";

            foreach (var entry in library)
            {
                result += $"Author: {entry.Key.Name}\n";
                result += "Books:\n";

                foreach (var book in entry.Value)
                {
                    result += $"- {book}\n";
                }
            }

            return result;
        }
    }
}
