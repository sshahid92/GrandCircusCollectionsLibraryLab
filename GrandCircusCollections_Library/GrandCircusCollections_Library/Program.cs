using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusCollections_Library
{
    class Program
    {
        static bool sortLoop = true;
        static bool searchLoop = true;
        static bool programLoop = true;

        static void Main(string[] args)
        {

            // Declare library
            Console.WriteLine("Welcome to the library!");
            List<Library> libraryBooks = new List<Library>
            {
                new Library() { Author = "Robert Greene", Title = "48 Laws of Power", CheckedOut = false },
                new Library() { Author = "Robert Greene", Title = "Mastery", CheckedOut = true },
                new Library() { Author = "Sun Tzu", Title = "Art of War", CheckedOut = false },
                new Library() { Author = "Malcolm Gladwell", Title = "Outliers", CheckedOut = true },
                new Library() { Author = "Timothy Ferriss", Title = "The 4-Hour Wokweek", CheckedOut = false },
                new Library() { Author = "Charles Duhigg", Title = "The Power of Habit", CheckedOut = true },
                new Library() { Author = "Napolean Hille", Title = "Think and Grow Rich", CheckedOut = false },
                new Library() { Author = "George R. R. Martin", Title = "A Game of Thrones", CheckedOut = false },
                new Library() { Author = "Walter Isaacson", Title = "Leonardo da Vinci", CheckedOut = false },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Philosopher's Stone", CheckedOut = true },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Chamber of Secrets", CheckedOut = true },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Prizoner of Azkaban", CheckedOut = false },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Goblet of Fire", CheckedOut = false },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Order of the Phoenix", CheckedOut = false },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Half Blood Prince", CheckedOut = false },
                new Library() { Author = "J. K. Rowling", Title = "Harry Potter and the Deathly Hallows", CheckedOut = true }
            };
            

            while (programLoop)
            {
                int answer;
                do
                {
                Start:
                    Console.WriteLine("\nYou can do the following\n\t1) View all the books in the library\n\t2) Sort the library by 'Author' or 'Title'\n\t3) Search for a book by 'Author' or 'Title'\n\t4) Check out a book\n\t5) Return a book\n\t6) Quit");
                    bool isNum = int.TryParse(Console.ReadLine(), out answer);
                    if (!isNum)
                    {
                        goto Start;
                    }
                } while (answer < 0 || answer > 6);

                switch (answer)
                {
                    case 1:
                        //View all the books in the library
                        while (sortLoop)
                        {

                            var sortType = "author";
                            SortLibray(sortType, "Here are your results:", libraryBooks);
                        }
                        sortLoop = true;
                        break;


                    case 2:
                        //sort by title or author
                        while (sortLoop)
                        {
                            Console.WriteLine("Sort by 'author' or 'title'?");
                            var sortType = Console.ReadLine().ToLower();
                            SortLibray(sortType, "Here are your results:", libraryBooks);
                        }
                        sortLoop = true;
                        break;


                    case 3:
                        //search book by author or title
                        string searchType;
                        do
                        {
                            Console.WriteLine("Search by 'author' or 'title'?");
                            searchType = Console.ReadLine().ToLower();
                        } while (searchType != "author" && searchType != "title");
                        while (searchLoop)
                        {
                            Console.WriteLine($"Enter a {searchType} to search");
                            var searchString = Console.ReadLine().ToLower();
                            SearchLibrary(searchType, searchString, libraryBooks);
                        }
                        searchLoop = true;
                        break;


                    case 4:
                        //display if the book is checked out or not. if not give option to check out
                        Console.WriteLine("Which book would you like to check out?\nEnter a book title.");
                        string bookTitle = Console.ReadLine().ToLower();
                        Console.WriteLine("Enter the authors name.");
                        string authorName = Console.ReadLine().ToLower();
                        foreach (Library book in libraryBooks)
                        {
                            if(book.Author.ToLower().Contains(authorName) && book.Title.ToLower().Contains(bookTitle) && book.CheckedOut == false)
                            {
                                Console.WriteLine($"Do you wish to check out {book.Title} by {book.Author}? (y/n)");
                                string checkout = Console.ReadLine();
                                if (checkout == "y")
                                {
                                    book.CheckedOut = true;
                                    Console.WriteLine($"{book.Title} by {book.Author} was successfully checked out!");
                                }
                                break;
                            }
                            else if (book.Author.ToLower().Contains(authorName) && book.Title.ToLower().Contains(bookTitle) && book.CheckedOut == true)
                            {
                                Console.WriteLine($"{book.Title} by {book.Author} is already checked out!");
                                break;
                            }
                            else if (book.Author.ToLower().Contains(authorName) == false || book.Title.ToLower().Contains(bookTitle) == false)
                            {
                                continue;
                                
                            }
                            else
                            {
                                Console.WriteLine("Could not find your search. Try again.");
                            }

                        }
                        break;


                    case 5:
                        //return a book
                        Console.WriteLine("Which book would you like to return?\nEnter a book title.");
                        string bookReturnTitle = Console.ReadLine().ToLower();
                        Console.WriteLine("Enter the authors name.");
                        string authorReturnName = Console.ReadLine().ToLower();
                        foreach (Library book in libraryBooks)
                        {
                            if (book.Author.ToLower().Contains(authorReturnName) && book.Title.ToLower().Contains(bookReturnTitle) && book.CheckedOut == true)
                            {
                                Console.WriteLine($"Do you wish to return {book.Title} by {book.Author}? (y/n)");
                                string returnBook = Console.ReadLine();
                                if (returnBook == "y")
                                {
                                    book.CheckedOut = false;
                                    Console.WriteLine($"{book.Title} by {book.Author} was successfully returned!");
                                }
                                break;
                            }
                            else if (book.Author.ToLower().Contains(authorReturnName) && book.Title.ToLower().Contains(bookReturnTitle) && book.CheckedOut == false)
                            {
                                Console.WriteLine($"{book.Title} by {book.Author} is already returned!");
                                break;
                            }
                            else if (book.Author.ToLower().Contains(authorReturnName) == false || book.Title.ToLower().Contains(bookReturnTitle) == false)
                            {
                                continue;

                            }
                            else
                            {
                                Console.WriteLine("Could not find your search. Try again.");
                            }

                        }
                        break;

                    case 6:
                        programLoop = false;
                        break;
                } 
            }

            
            

            //TO DO: add a book. Just need some time to implment this
            Library newBook = new Library() { Author = "Some Guy", Title = "Much Book", CheckedOut = false };

            int index = libraryBooks.BinarySearch(newBook);

            if (index < 0)
            {
                libraryBooks.Insert(~index, newBook);
            }

        }


        
        static void SortLibray(string sortType, string message, List<Library> dictionaryInput)
        {

            switch (sortType)
            {
                case "title":
                    //sort by title
                    IEnumerable<Library> queryTitle = from books in dictionaryInput
                                                      orderby books.Title
                                                      select books;
                    string author1 = "Author";
                    string bookheader1 = "Title";
                    string avai1 = "Availability";
                    Console.WriteLine($"{bookheader1.PadRight(50)} {author1.PadRight(25)} {avai1}");
                    Console.WriteLine("======================================================================================================");
                    foreach (Library book in queryTitle)
                    {
                        Console.WriteLine($"{book.Title.PadRight(50)} {book.Author.PadRight(25)} Checked Out Status: {book.CheckedOut}");
                    }
                    sortLoop = false;
                    break;

                case "author":
                    //sort by Author
                    IEnumerable<Library> queryAuthor = from books in dictionaryInput
                                                       orderby books.Author
                                                       select books;
                    string author = "Author";
                    string bookheader = "Title";
                    string avai = "Availability";
                    Console.WriteLine($"{author.PadRight(25)} {bookheader.PadRight(50)} {avai}");
                    Console.WriteLine("=====================================================================================================");
                    foreach (Library book in queryAuthor)
                    {
                        Console.WriteLine($"{book.Author.PadRight(25)} {book.Title.PadRight(50)} Checked Out: {book.CheckedOut}");
                    }
                    sortLoop = false;
                    break;


                default:
                    Console.WriteLine("That was not a valid response.");
                    sortLoop = true;
                    break;
            }


        }

        static void SearchLibrary(string searchType, string searchWord, List<Library> dictionaryInput)
        {
            switch (searchType)
            {
                case "author":
                    //search book by author
                    var authorSearchResult = dictionaryInput.Where(a => a.Author.ToLower().Contains(searchWord)).ToList();
                    string author = "Author";
                    string bookheader = "Title";
                    string avai = "Availability";
                    Console.WriteLine($"{author.PadRight(25)} {bookheader.PadRight(50)} {avai}");
                    Console.WriteLine("=====================================================================================================");
                    foreach (Library book in authorSearchResult)
                    {
                        Console.WriteLine($"{book.Author.PadRight(25)} {book.Title.PadRight(50)} Checked Out: {book.CheckedOut}");
                    }
                    searchLoop = false;
                    break;



                case "title":
                    //search book by title
                    var titleSearchResult = dictionaryInput.Where(a => a.Title.ToLower().Contains(searchWord)).ToList();
                    string author1 = "Author";
                    string bookheader1 = "Title";
                    string avai1 = "Availability";
                    Console.WriteLine($"{bookheader1.PadRight(50)} {author1.PadRight(25)} {avai1}");
                    Console.WriteLine("======================================================================================================");
                    foreach (Library book in titleSearchResult)
                    {
                        Console.WriteLine($"{book.Title.PadRight(50)} {book.Author.PadRight(25)} Checked Out Status: {book.CheckedOut}");
                    }
                    searchLoop = false;
                    break;



                default:
                    Console.WriteLine("That was not a valid response.");
                    searchLoop = true;
                    break;
            }
            



        }


    }
}
