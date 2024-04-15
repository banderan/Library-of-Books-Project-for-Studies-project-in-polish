using Projekt___Biblioteka_Ksiazek;

namespace TestBiblioteki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkWithLibrary library = new WorkWithLibrary();
            string czyZamykamyBibliotekę = "tak";
            string[] metodyBiblioteki = { "Dodawanie Autora", "dodawanie książki do autora", "sprawdzenie czy mamy te książkę",
                "zwracanie wszystkich autorów", "zwracanie wszystkich książek od tego autora", "zwracanie wielkości naszej biblioteki",
                "usuwanie autora wraz z jego książkami", "usuwanie książek od Autora","wydrukuj bibliotekę" ,"!!WYKONAJ PRZYKŁADOWĄ BIBLIOTEKĘ!!"};

            Console.WriteLine("WARNING: \n nie używaj poskich znaków ani interpunkcji,\n wszystkie dane będą z małej litery ze względu na zabezpieczenia kodu \n");
            Console.WriteLine("Aplikacja \"Bibioteka\"  \n" +
                "--------------------------------------------------" +
                "\nCelem projektu jest stworzenie aplikacji konsolowej, która umożliwi użytkownikom zarządzanie kolekcją książek. Aplikacja pozwoli na" +
                " poruszanie się i edytowanie jej zawartości poprzez pisanie na konsoli.\n" +
                "----------------------------------------------\n JAK SIĘ PORUSZAĆ \n----------------------------------------------\n" +
                "Zaraz ukaże ci się menu biblioteki możesz z niego bezpiecznie kożystać za pomocą konsoli. Pisz uważnie ponieważ nawet małe błędy spowodują ponowne uruchomienie menu\n");
            Console.WriteLine("Czy wiesz jak należy kożystać z aplikacji?(tak/nie)");
            string akceptacja = Console.ReadLine().Trim();
            if (akceptacja.Equals("tak"))
            {
                czyZamykamyBibliotekę = "nie";
            }else
            {
                Console.WriteLine("\nPoczytaj sobie wszystko jeszcze trochę i wróć jak będziesz gotowy/a");
                
                if(Console.ReadLine().Equals("jajo")) 
                {
                easterEgg();
                }
                return;
            }

            Console.WriteLine();
            while (czyZamykamyBibliotekę.Equals("nie"))
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("MENU");
                Console.WriteLine("-----------------------------------------------------");
                foreach (string element in metodyBiblioteki)
                {
                    Console.WriteLine("--" +  element + "--");
                }
                Console.WriteLine();
                Console.WriteLine("Co chcesz zrobić?(wpisz opcję z menu)");
                Console.WriteLine();
                string opcjaZMeny = Console.ReadLine().Trim();
                switch (opcjaZMeny.ToLower())
                {
                    case "dodawanie autora":
                        library.addAuthor();
                        break;

                    case "dodawanie ksiazki do autora":
                        Console.WriteLine("-------------");
                        Console.WriteLine("jaka to książka?");
                        Console.WriteLine("-------------");
                        library.addBookToAuthor(print());
                        break;

                    case "sprawdzenie czy mamy te ksiazke":
                        Console.WriteLine("-------------");
                        Console.WriteLine("O jaką książkę ci chodzi?");
                        Console.WriteLine("-------------");
                        bool czyJaMamy= library.doWeHaveThisBookInLibrary(print());
                        if (czyJaMamy)
                        {
                            Console.WriteLine("-------------");
                            Console.WriteLine("Tak, mamy tę książkę!");
                        }
                        else
                        {
                            Console.WriteLine("-------------");
                            Console.WriteLine("Nie, niestety nie mamy tej książki!");
                        }
                        break;

                    case "zwracanie wszystkich autorow":
                        library.getAllAuthors(); 
                        break;

                    case "zwracanie wszystkich ksiazek od tego autora":
                        Console.WriteLine("-------------");
                        Console.WriteLine("O kogo ci chodzi? Jeśli go mamy to ci go pokażemy.");
                        Console.WriteLine("-------------");
                        string[] books = library.getAllBooksFromThisAuthor(print());
                        foreach (string element in books)
                        {
                            Console.WriteLine("--{0}",element);
                        }
                        break;

                    case "zwracanie wielkosci naszej biblioteki":
                        Console.WriteLine("-------------");
                        int rozmiarBiblioteki = library.getLibrarySize();
                        Console.WriteLine("Rozmiar naszej biblioteki: {0} Autorów którzy mają wiele książek", rozmiarBiblioteki);
                        break;

                    case "usuwanie autora wraz z jego ksiazkami":
                        Console.WriteLine("-------------");
                        Console.WriteLine("O jakiego autora ci chodzi?");
                        Console.WriteLine("-------------");
                        library.removeAuthorWithBooks(print());
                        break;

                    case "usuwanie ksiazek od autora":
                        Console.WriteLine("-------------");
                        Console.WriteLine("O jaką książkę i jakiego autora ci chodzi?");
                        Console.WriteLine("--podaj autora--");
                        string autor = print();
                        Console.WriteLine("--podaj książkę");
                        string book = print();
                        library.removeBookFromAuthor(autor,book);
                        break;

                    case "wydrukuj biblioteke":
                        Console.WriteLine("-------------");
                        library.printLibrary();
                        Console.WriteLine("-------------");
                        break;

                    case "wykonaj przykladowa biblioteke":
                        getDefaultLibrary();
                        Console.WriteLine("przykładowa biblioteka została utworzona");
                        break;

                    default:
                        Console.WriteLine("Popełniłeś/aś błąd w pisowni bądź nie mamy takiej opcji.");
                        Console.WriteLine("spróbuj ponownie!");
                        break;
                }


                Console.WriteLine();
                Console.WriteLine("czy chcesz zamknąć bibliotekę?(tak/nie)");
                do
                {
                    czyZamykamyBibliotekę = Console.ReadLine().ToLower().Trim();
                } while (!(czyZamykamyBibliotekę.Equals("tak") || czyZamykamyBibliotekę.Equals("nie")));
                Console.WriteLine();
                Console.WriteLine("===================zamknięcie okna======================");
                Console.WriteLine();
                Console.WriteLine();
            }
            void easterEgg()
            {
                Console.WriteLine("   _____\n /       \\\n/         \\\n|   _   _ |\n|  | | |  |\n|  | | |  |\n|  |___|  |\n\\         /\n \\_______/");
                Console.WriteLine("nieźle masz easter egg-a!");
            }

            void getDefaultLibrary()
            {

                Author adamMickiewicz = new Author("adam mickiewicz", 57, false);
                string[] dziełaMickiewicza = { "oda do młodości", "sonety", "konrad wallenrod", "dziady i", "dziady iii", "pan tadeusz" };
                library.addDefaultAuthorWithBooks(adamMickiewicz, dziełaMickiewicza);

                Author georgeOrwell = new Author("george orwell", 47, false);
                string[] dzielaOrwella = { "rok 1984", "folwark zwierzęcy", "brak tchu", "corka proboszcza", "biranskie dni" };
                library.addDefaultAuthorWithBooks(georgeOrwell, dzielaOrwella);

                Author remigiuszMroz = new Author("remigiusz mroz", 37, true);
                string[] dzielaMroza = { "ekspocycja", "trawers", "przepasc", "kasacja", "zarzut", "predkosc ucieczki" };
                library.addDefaultAuthorWithBooks(remigiuszMroz, dzielaMroza);

                Author olgaTokarczuk = new Author("olga tokarczuk", 60, true);
                string[] dzielaOlgi = { "podroz ludzi ksiegi", "e.e.", "bieguni", "empuzjon", "obcy", "rubiez", "fryzjer", "pomiedzy" };
                library.addDefaultAuthorWithBooks(olgaTokarczuk, dzielaOlgi);
            }
            string print()
            {
                string book = Console.ReadLine().ToLower().Trim();
                return book;
            }
        }
    }
}
