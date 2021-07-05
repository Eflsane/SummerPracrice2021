using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.Common.Dependencies;
using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryThreeLayer2021.ConsolePL
{
    class Program
    {
        private static ILogic _bll;


        private static User user;

        [STAThread]
        static void Main(string[] args)
        {
           _bll = DependencyResolver.Instance.BLL;


            /*Console.WriteLine(_bll.GetUserByNameAndPass("mouth", "1234"));
            Console.WriteLine(_bll.GetUserByNameAndPass("mouth", "1234"));

            try
            {
                Console.WriteLine(_bll.GetUserByName("mouth"));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey(); */


            //Saving to BD
            /*OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();


            Console.WriteLine(_bll.AddBook("Patato attack!", "Desc", new DateTime(2001, 04, 12), "mouth", 1, null, openFileDialog.FileName));
            */


            //Loading and saving file from BD
            /*BookFileContainer container = _bll.GetBookFile(2);

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.ShowDialog();

            container.FileName = folderBrowserDialog.SelectedPath + "\\" + container.FileName;

            Console.WriteLine(_bll.ConvertByteArchToFileAndSave(container));

            */

            //Reading date from console in custom format
            /*string s = Console.ReadLine();
            string format = "yyyy-MM-dd";
            DateTime dateTime;
            Console.WriteLine(DateTime.TryParseExact(s, format, new CultureInfo("en-US"), DateTimeStyles.None, out dateTime));

            Console.WriteLine(dateTime);

            Console.ReadKey();*/

            DrawAndProcessInterface();

        }

        public static void DrawAndProcessInterface()
        {
            bool isUserSigned = false;
            
            while(true)
            {
                isUserSigned = DrawStartInterface();
                if(isUserSigned)
                {
                    if (user == null)
                    {
                        Console.WriteLine("Some shit happened");
                        Console.ReadKey();
                        return;
                    }

                    //bool isTimeToTop = false;
                    while (!DrawBacicInterface())
                    {
                        
                    }
                }
            }
        }

        public static bool DrawStartInterface()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");
            Console.WriteLine("Welcome to your doom library. Where you want to start?");
            Console.WriteLine("1: I am not registered user, sign me up");
            Console.WriteLine("2: I have alredy joined your doom, let me sign in");
            Console.WriteLine("3: I am your master! Register me as admin, machine!");
            Console.WriteLine("4: Run away");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        return DrawRegisterInterace(false);
                        
                    }
                case "2":
                    {
                        return DrawSigninInterface();
                    }
                case "3":
                    {
                        return DrawAdminRegisterInterace();
                    }
                case "4":
                    {
                        Environment.Exit(0);
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private static bool DrawRegisterInterace(bool isAdminRegister)
        {
            Console.Clear();

            Console.WriteLine("Doom library");

            Console.WriteLine("Show your username:");

            string username = Console.ReadLine();

            try
            {
                _bll.GetUserByName(username);
                Console.WriteLine("This user already exist. Do you have a brain illness?");
                Console.WriteLine("Returning to main menu");
                Console.WriteLine("Press a key");
                Console.ReadKey();

                return false;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                Console.WriteLine("Are you male or female? Type M or F(X for exit to main screen");
                bool sex = false;
                try
                {
                    switch (Console.ReadLine().ToLower())
                    {
                        case "m":
                            {
                                sex = false;
                                break;
                            }
                        case "f":
                            {
                                sex = true;
                                break;
                            }
                        case "x":
                            {
                                return false;
                            }
                        default:
                            {
                                throw new ArgumentOutOfRangeException();
                                break;
                            }
                    }
                }
                catch(ArgumentOutOfRangeException internalException)
                {

                }

                Console.WriteLine("Do you want to hide yourself? Enter nickname(optional):");
                string customName = Console.ReadLine();

                if (!_bll.AddUser(username, password, sex, customName = customName.Equals("")? null: customName))
                {
                    Console.WriteLine("Error occured. Regestry not complete");
                    Console.WriteLine("Returning to main menu");
                    Console.WriteLine("Press a key");
                    Console.ReadKey();

                    return false;
                }


                user = _bll.GetUserByName(username);
                
                Console.WriteLine("Register complete ");
                Console.WriteLine("Doom is awaiting of you, user ");
                Console.WriteLine("Press a key");
                Console.ReadKey();

                return true;
            }
        }

        private static bool DrawSigninInterface()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");

            Console.WriteLine("Show your username:");

            string username = Console.ReadLine();

            try
            {
                _bll.GetUserByName(username);

                Console.WriteLine("Enter your password:");

                string password = Console.ReadLine();

                if(!_bll.GetUserByNameAndPass(username, password))
                {
                    Console.WriteLine("Incorrect password");
                    Console.WriteLine("Returning to main menu");
                    Console.WriteLine("Press a key");
                    Console.ReadKey();
                    return false;
                }

                user = _bll.GetUserByName(username);

                return true;
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("This user not exist. Do you have a brain illness?");
                Console.WriteLine("Returning to main menu");
                Console.WriteLine("Press a key");
                Console.ReadKey();
                return false;
            }
        }

        public static bool DrawAdminRegisterInterace()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");

            Console.WriteLine("Show your admin pass:");

            string adminPass = Console.ReadLine();

            if (!_bll.CheckAdminPass(adminPass))
            {
                Console.WriteLine("Incorrect password");
                Console.WriteLine("Returning to main menu");
                Console.WriteLine("Press a key");
                Console.ReadKey();
                return false;
            }

            return DrawRegisterInterace(true);
        }

        public static bool DrawBacicInterface()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");
            Console.WriteLine("Welcome " + user);

            Console.WriteLine("What can I do for you, " + user);

            Console.WriteLine("1. Show me your books");
            Console.WriteLine("2. Show me authors");
            Console.WriteLine("3. Show me genres");
            Console.WriteLine("4. Show me my favorite books");
            Console.WriteLine("5. Show me my profile");
            Console.WriteLine("6. Begone out of here");
            Console.WriteLine("7. Jump out from profile");

            switch(Console.ReadLine())
            {
                case "1":
                    {
                        while(!DrawBooksInterface());
                        return false;
                    }
                case "6":
                    {
                        Environment.Exit(0);
                        return true;
                    }
                case "7":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private static bool DrawBooksInterface()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");
            Console.WriteLine("Welcome " + user);
            Console.WriteLine("X. Back to main screen");
            Console.WriteLine("F. Find books by criteria");

            List<Book> books = _bll.GetAllBooks();
            if (user.IsAdmin)
            {
                Console.WriteLine("A. Add book");
            }

            if (books.Count <= 0) Console.WriteLine("No books in library at this moment");
            else
            {
                for (int i = 0; i < books.Count; i++)
                {

                    Author author = _bll.GetAuthorByID(books[i].AuthorID);
                    Console.WriteLine(i + ". " + author.Secondname + " " + author.Firstname + " - " + books[i].Name);
                }
            }

            string input = Console.ReadLine().ToLower();

            if (input == "f")
            {
                while (!DrawSearchBookBasicInterface()) ;
            }
            else if (input == "x") return true;
            else if (input == "a" && user.IsAdmin)
            {
                DrawAddBookInterface();
            }
            else
            {
                int bookIndex = -1;
                if (int.TryParse(input, out bookIndex))
                {
                    if (bookIndex > -1 && bookIndex < books.Count)
                    {
                        DrawSingleBookInterface(books[bookIndex]);
                    }
                }
            }

            return false;
        }

        private static bool DrawSearchBookBasicInterface()
        {
            Console.WriteLine("Choose search criteria");
            Console.WriteLine("1. By book name");
            Console.WriteLine("2. By auhtor");
            Console.WriteLine("3. By genre");
            Console.WriteLine("4. By year");
            Console.WriteLine("5. By year interval");
            Console.WriteLine("X. Go back");

            List<Book> searchResult = new List<Book>();
            string searchQuerry = "";

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    {
                        Console.WriteLine("Enter book's name");
                        searchQuerry = Console.ReadLine();
                        searchResult = _bll.FindBooksByName(searchQuerry);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Enter author firstname or secondname:");
                        searchQuerry = Console.ReadLine();
                        searchResult = _bll.FindBooksByAuthor(searchQuerry);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Available genres:");
                        foreach (Genre genre in _bll.GetAllGenres())
                        {
                            Console.WriteLine(genre.Name);
                        }
                        Console.WriteLine("Enter genre:");
                        searchQuerry = Console.ReadLine();
                        searchResult = _bll.FindBooksByAuthor(searchQuerry);
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Enter year:");
                        searchQuerry = Console.ReadLine();

                        int year = 0;
                        if(!int.TryParse(searchQuerry, out year))
                        {
                            Console.WriteLine("Sorry, master, wrong input provided");
                            return false;
                        }

                        searchResult = _bll.FindBooksByYear(year);
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Enter first year:");
                        searchQuerry = Console.ReadLine();

                        int year1 = 0;
                        if (!int.TryParse(searchQuerry, out year1))
                        {
                            Console.WriteLine("Sorry, master, wrong input provided");
                            return false;
                        }

                        Console.WriteLine("Enter second year:");
                        searchQuerry = Console.ReadLine();

                        int year2 = 0;
                        if (!int.TryParse(searchQuerry, out year2) || year1 > year2)
                        {
                            Console.WriteLine("Sorry, master, wrong input provided");
                            return false;
                        }

                        searchResult = _bll.FindBooksByYearMultiple(year1, year2);
                        break;
                    }
                case "x":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }

            Console.Clear();

            Console.WriteLine("What I fond on your question:");

            if(searchResult.Count <= 0)
            {
                Console.WriteLine("Nothing found, sorry (><)");
                Console.WriteLine("Press any key");
                Console.ReadKey();

                return true;
            }

            for(int i = 0; i < searchResult.Count; i++)
            {
                Author author = _bll.GetAuthorByID(searchResult[i].AuthorID);
                Console.WriteLine(i + ". " + author.Secondname + " " + author.Firstname + " - " + searchResult[i].Name);
            }

            Console.WriteLine("Enter book number to proceed to the book. Otherwise enter anything else and go back");

            string input = Console.ReadLine();
            int bookIndex = -1;
            if(int.TryParse(input, out bookIndex))
            {
                if(bookIndex > -1 && bookIndex < searchResult.Count)
                {
                    DrawSingleBookInterface(searchResult[bookIndex]);
                }
            }

            return true;
        }

        private static void DrawAddBookInterface()
        {
            Console.Clear();

            Console.WriteLine("Enter book name");
            string bookName = Console.ReadLine();

            Console.WriteLine("Enter book description");
            string bookDesc = Console.ReadLine();

            Console.WriteLine("Enter date of book publication()");
            string dateString = Console.ReadLine();
            string format = "yyyy-MM-dd";
            DateTime pubDate;
            if(!DateTime.TryParseExact(dateString, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out pubDate))
            {
                Console.WriteLine("Incorrect date! Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Search for which author book will be added");
            Console.WriteLine("Enter author secondname or firstname");
            List<Author> authors =  _bll.FindAuthors(Console.ReadLine());
            if(authors.Count <= 0)
            {
                Console.WriteLine("No authors found. Maybe you want add one? Go to the 'Show me authors' menu");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine(i + ". " + authors[i].Secondname + " " + authors[i].Firstname);
            }
            Console.WriteLine("Choose your author by typing his number in the list");
            string listNumer = Console.ReadLine();
            int listIndex = -1;
            if(!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < authors.Count))
            {
                Console.WriteLine("Incorrect input! Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Choose file with book");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose file with book";

            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    Console.WriteLine("Operation canceled. Return to HQ");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    return;
                }


                _bll.AddBook(bookName, bookDesc, pubDate, user.Username, authors[listIndex].ID, fileName: openFileDialog.FileName);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File not found. Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }
        }

        private static void DrawSingleBookInterface(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
