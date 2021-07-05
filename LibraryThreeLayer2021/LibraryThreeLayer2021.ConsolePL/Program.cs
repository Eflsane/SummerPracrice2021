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
        //Some comms about how this thing work
        /*About bool functions
         * For almost every function that returns bool value it means: "Are this function ready to close?", 
         * except all sign-related fuctions for which it means "Is operation complited successfully?"
         */

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
                case "2":
                    {
                        while (!DrawAuthorsInterface()) ;
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
                        while(!DrawSingleBookInterface(books[bookIndex]));
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
                    while(!DrawSingleBookInterface(searchResult[bookIndex]));
                }
            }

            return true;
        }

        private static void DrawAddBookInterface(long authorID = -1)
        {
            Console.Clear();

            Console.WriteLine("Enter book name");
            string bookName = Console.ReadLine();

            Console.WriteLine("Enter book description");
            string bookDesc = Console.ReadLine();

            Console.WriteLine("Enter date of book publication(yyyy-mm-dd)");
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


            if(authorID < 1)
            {
                Console.WriteLine("Search for which author book will be added");
                Console.WriteLine("Enter author secondname or firstname");
                List<Author> authors = _bll.FindAuthors(Console.ReadLine());
                if (authors.Count <= 0)
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
                if (!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < authors.Count))
                {
                    Console.WriteLine("Incorrect input! Abort mission!");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    return;
                }

                authorID = authors[listIndex].ID;
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


                if(!_bll.AddBook(bookName, bookDesc, pubDate, user.Username, authorID, fileName: openFileDialog.FileName))
                {
                    Console.WriteLine("An error occured. Abort mission!");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File not found. Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }
        }

        private static bool DrawSingleBookInterface(Book book)
        {
            Console.Clear();

            Console.WriteLine("Name: " + book.Name);

            Author author = _bll.GetAuthorByID(book.AuthorID);
            Console.WriteLine("Author: " + author.Secondname + " " + author.Firstname);

            Console.WriteLine("Publication date: " + book.PublicationDate.Year);

            List<Genre> genres = _bll.GetGenresOfBookById(book.ID);
            string genresList = "";
            foreach (Genre genre in genres) genresList += genre.Name + " | ";
            Console.WriteLine("Genre: " + genresList);

            Console.WriteLine("Description: " + book.Desc);

            Console.WriteLine("X. Go back");
            Console.WriteLine("1. Download book to your pc");
            Console.WriteLine("2. Look for other books of this author");
            Console.WriteLine("3. Choose genre from this book and find others with this genre");

            if(user.IsAdmin)
            {
                Console.WriteLine("4. Change book attributes");
                Console.WriteLine("5. Correct author's attributes");
                Console.WriteLine("6. Change author to another");
                Console.WriteLine("7. Add genre to book");
                Console.WriteLine("8. Remove genre from book");
                Console.WriteLine("9. Delete book");
            }

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "x":
                    {
                        return true;
                    }
                case "1":
                    {
                        Console.WriteLine("Choose folder for download");
                        BookFileContainer container = _bll.GetBookFile(book.ID);

                        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                        folderBrowserDialog.Description = "Choose place to download";

                        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                        {
                            Console.WriteLine("Operation canceled. Return to HQ");
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                            return false;
                        }

                        container.FileName = folderBrowserDialog.SelectedPath + "\\" + container.FileName;

                        try
                        {
                            _bll.ConvertByteArchToFileAndSave(container);
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            Console.WriteLine(e.Message + ". Go back");
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                            return false;
                        }
                        Console.WriteLine("File downloaded succesfuly.");
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                        return false;
                    }
                case "2":
                    {
                        while (!DrawSingleAuthorInterface(author));
                        return false;
                    }
                case "3":
                    {
                        Console.WriteLine("Type genre number to proceed or type something else to cancel");
                        for(int i = 0; i < genres.Count; i++)
                        {
                            Console.WriteLine(i + ". " + genres[i].Name);
                        }

                        string genreNumber = Console.ReadLine();
                        int genreIndex = -1;

                        if(!int.TryParse(genreNumber, out genreIndex) || !(genreIndex > -1 && genreIndex < genres.Count))
                        {
                            Console.WriteLine("Operation canceled");
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                            return false;
                        }

                        //while (!DrawSingleGenreInterface(genres[genreIndex]));
                        return false;
                    }
                default:
                    {
                        if (!user.IsAdmin) return false;
                        
                        switch (input)
                        {
                            case "4":
                                {
                                    Console.WriteLine("Choose which attribute to change");
                                    Console.WriteLine("1. Name");
                                    Console.WriteLine("2. Description");
                                    Console.WriteLine("3. Publication date");
                                    Console.WriteLine("4. Book File");

                                    switch(Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.WriteLine("Enter new book name:");
                                                string newName = Console.ReadLine();

                                                if(newName.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if(!_bll.UpdateBook(book.ID, newName, book.Desc, book.PublicationDate, book.AuthorID))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }

                                        case "2":
                                            {
                                                Console.WriteLine("Enter new book description:");
                                                string newDesc = Console.ReadLine();

                                                if (newDesc.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateBook(book.ID, book.Name, newDesc, book.PublicationDate, book.AuthorID))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        case "3":
                                            {
                                                Console.WriteLine("Enter new book publication date(yyyy-mm-dd):");
                                                string stringDate = Console.ReadLine();

                                                if (stringDate.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                string format = "yyyy-MM-dd";
                                                DateTime pubDate;
                                                if (!DateTime.TryParseExact(stringDate, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out pubDate))
                                                {
                                                    Console.WriteLine("Incorrect date! Abort mission!");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateBook(book.ID, book.Name, book.Desc, pubDate, book.AuthorID))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        case "4":
                                            {
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
                                                        return false;
                                                    }


                                                    _bll.UpdateBookFie(book.ID, openFileDialog.FileName);
                                                    Console.WriteLine("Changes successfully saved");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }
                                                catch (FileNotFoundException e)
                                                {
                                                    Console.WriteLine("File not found. Abort mission!");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Operation canceled. Going back");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                    }
                                }
                            case "5":
                                {
                                    Console.WriteLine("Choose which attribute to change");
                                    Console.WriteLine("1. Secondname");
                                    Console.WriteLine("2. Firstname");


                                    switch(Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.WriteLine("Enter new author secondname:");
                                                string newSecondname = Console.ReadLine();

                                                if (newSecondname.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateAuthor(book.AuthorID, newSecondname, author.Firstname, author.BirthDate))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        case "2":
                                            {
                                                Console.WriteLine("Enter new author firstname:");
                                                string newFirstname = Console.ReadLine();

                                                if (newFirstname.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateAuthor(book.AuthorID, author.Secondname, newFirstname, author.BirthDate))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Operation canceled. Going back");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                    }
                                }
                            case "6":
                                {
                                    Console.WriteLine("Search for new author for the book");
                                    Console.WriteLine("Enter author secondname or firstname");
                                    List<Author> authors = _bll.FindAuthors(Console.ReadLine());
                                    if (authors.Count <= 0)
                                    {
                                        Console.WriteLine("No authors found. Maybe you want add one? Go to the 'Show me authors' menu");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }
                                    for (int i = 0; i < authors.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + authors[i].Secondname + " " + authors[i].Firstname);
                                    }
                                    Console.WriteLine("Choose your author by typing his number in the list");
                                    string listNumer = Console.ReadLine();
                                    int listIndex = -1;
                                    if (!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < authors.Count))
                                    {
                                        Console.WriteLine("Incorrect input! Abort mission!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }


                                    if(!_bll.UpdateBook(book.ID, book.Name, book.Desc, book.PublicationDate, authors[listIndex].ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Changes successfully saved");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return false;
                                }
                            case "7":
                                {
                                    List<Genre> allGenres = _bll.GetAllGenres();
                                    if (allGenres.Count <= 0)
                                    {
                                        Console.WriteLine("No genres found. Maybe you want add one? Go to the 'Show me genres' menu");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }
                                    for (int i = 0; i < allGenres.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + allGenres[i].Name);
                                    }
                                    Console.WriteLine("Choose genre by typing it's number in the list");
                                    string listNumer = Console.ReadLine();
                                    int listIndex = -1;
                                    if (!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < allGenres.Count))
                                    {
                                        Console.WriteLine("Incorrect input! Abort mission!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    if(!_bll.AddGenreToBook(book.ID, allGenres[listIndex].ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Changes successfully saved");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return false;
                                }
                            case "8":
                                {
                                    if(genres.Count <= 0)
                                    {
                                        Console.WriteLine("No genres attached to this book");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }
                                    for(int i = 0; i < genres.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + genres[i].Name);
                                    }
                                    Console.WriteLine("Choose genre by typing it's number in the list");
                                    string listNumer = Console.ReadLine();
                                    int listIndex = -1;
                                    if (!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < genres.Count))
                                    {
                                        Console.WriteLine("Incorrect input! Abort mission!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    if (!_bll.DeleteGenreFromBook(book.ID, genres[listIndex].ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Changes successfully saved");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return false;
                                }
                            case "9":
                                {
                                    if(!_bll.DeleteBookByID(book.ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Book has successfully deleted");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return true;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
            }
        }

        private static bool DrawAuthorsInterface()
        {
            Console.Clear();

            Console.WriteLine("Doom library ");
            Console.WriteLine("Welcome " + user);
            Console.WriteLine("X. Back to main screen");
            Console.WriteLine("F. Find authors");

            List<Author> authors = _bll.GetAllAuthors();
            if (user.IsAdmin)
            {
                Console.WriteLine("A. Add author");
            }

            if (authors.Count <= 0) Console.WriteLine("No authors in library at this moment");
            else
            {
                for (int i = 0; i < authors.Count; i++)
                {
                    Console.WriteLine(i + ". " + authors[i].Secondname + " " + authors[i].Firstname + " " + authors[i].BirthDate.Year);
                }
            }

            string input = Console.ReadLine().ToLower();

            if (input == "f")
            {
                while (!DrawSearchAuthorBasicInterface()) ;
            }
            else if (input == "x") return true;
            else if (input == "a" && user.IsAdmin)
            {
                DrawAddAuthorInterface();
            }
            else
            {
                int authorIndex = -1;
                if (int.TryParse(input, out authorIndex))
                {
                    if (authorIndex > -1 && authorIndex < authors.Count)
                    {
                        while (!DrawSingleAuthorInterface(authors[authorIndex])) ;
                    }
                }
            }

            return false;
        }

        private static bool DrawSearchAuthorBasicInterface()
        {

            List<Author> searchResult = new List<Author>();
            string searchQuerry = "";

            Console.WriteLine("Enter author firstname or secondname:");
            searchQuerry = Console.ReadLine();
            searchResult = _bll.FindAuthors(searchQuerry);


            Console.Clear();

            Console.WriteLine("What I fond on your question:");

            if (searchResult.Count <= 0)
            {
                Console.WriteLine("Nothing found, sorry (><)");
                Console.WriteLine("Press any key");
                Console.ReadKey();

                return true;
            }

            for (int i = 0; i < searchResult.Count; i++)
            {
                Console.WriteLine(i + ". " + searchResult[i].Secondname + " " + searchResult[i].Firstname + " " + searchResult[i].BirthDate.Year);
            }

            Console.WriteLine("Enter author number to proceed to the author. Otherwise enter anything else and go back");

            string input = Console.ReadLine();
            int authorIndex = -1;
            if (int.TryParse(input, out authorIndex))
            {
                if (authorIndex > -1 && authorIndex < searchResult.Count)
                {
                    while (!DrawSingleAuthorInterface(searchResult[authorIndex]));
                }
            }

            return true;
        }

        private static void DrawAddAuthorInterface()
        {
            Console.Clear();

            Console.WriteLine("Enter author secondname");
            string authorSecondname = Console.ReadLine();

            Console.WriteLine("Enter author firstname");
            string authorFirstname = Console.ReadLine();

            Console.WriteLine("Enter date of book publication(yyyy-mm-dd)");
            string dateString = Console.ReadLine();
            string format = "yyyy-MM-dd";
            DateTime birthDate;
            if (!DateTime.TryParseExact(dateString, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out birthDate))
            {
                Console.WriteLine("Incorrect date! Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }

             if(!_bll.AddAuthor(authorSecondname, authorFirstname, birthDate))
            {
                Console.WriteLine("An error occured. Abort mission!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }

        private static bool DrawSingleAuthorInterface(Author author)
        {
            Console.Clear();

            Console.WriteLine("Secondname: " + author.Secondname);

            Console.WriteLine("Firstname: " + author.Firstname);

            Console.WriteLine("Birth date: " + author.BirthDate.Year + " " + author.BirthDate.Month + " " + author.BirthDate.Day);

            Console.WriteLine("X. Go back");

            if(user.IsAdmin)
            {
                Console.WriteLine("A. Add new author's book");
                Console.WriteLine("R. Remove book of author");
                Console.WriteLine("C. Correct author's attributes");
                Console.WriteLine("D. Delete author");
            }
            

            List<Book> books = _bll.GetBooksByAuthorID(author.ID);
            if(books.Count <= 0)
            {
                Console.WriteLine("This author doesn't have published books yet");
            }
            else
            {
                for(int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine(i + ". " + books[i].Name + " " + books[i].PublicationDate.Year);
                }
            }


            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "x":
                    {
                        return true;
                    }
                default:
                    {
                        int bookIndex = -1;
                        if(int.TryParse(input, out bookIndex) && (bookIndex > -1 && bookIndex < books.Count))
                        {
                            while (!DrawSingleBookInterface(books[bookIndex]));
                            return false;
                        }

                        if (!user.IsAdmin) return false;

                        switch (input)
                        {
                            case "a":
                                {
                                    DrawAddBookInterface(author.ID);
                                    return false;                                    
                                }
                            case "r":
                                {
                                    if (books.Count <= 0)
                                    {
                                        Console.WriteLine("No books attached to this author");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }
                                    for (int i = 0; i < books.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + books[i].Name + " " + books[i].PublicationDate.Year);
                                    }
                                    Console.WriteLine("Choose book by typing it's number in the list");
                                    string listNumer = Console.ReadLine();
                                    int listIndex = -1;
                                    if (!int.TryParse(listNumer, out listIndex) || !(listIndex > -1 && listIndex < books.Count))
                                    {
                                        Console.WriteLine("Incorrect input! Abort mission!");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    if (!_bll.DeleteBookByID(books[listIndex].ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Book successfully deleted");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return false;
                                }
                            case "c":
                                {
                                    Console.WriteLine("Choose which attribute to change");
                                    Console.WriteLine("1. Secondname");
                                    Console.WriteLine("2. Firstname");
                                    Console.WriteLine("3. Birth date");


                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.WriteLine("Enter new author secondname:");
                                                string newSecondname = Console.ReadLine();

                                                if (newSecondname.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateAuthor(author.ID, newSecondname, author.Firstname, author.BirthDate))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        case "2":
                                            {
                                                Console.WriteLine("Enter new author firstname:");
                                                string newFirstname = Console.ReadLine();

                                                if (newFirstname.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateAuthor(author.ID, author.Secondname, newFirstname, author.BirthDate))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        case "3":
                                            {
                                                Console.WriteLine("Enter new author's birth date(yyyy-mm-dd):");
                                                string stringDate = Console.ReadLine();

                                                if (stringDate.Equals(string.Empty))
                                                {
                                                    Console.WriteLine("Empty string detected. Operation canceled");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                string format = "yyyy-MM-dd";
                                                DateTime birthDate;
                                                if (!DateTime.TryParseExact(stringDate, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out birthDate))
                                                {
                                                    Console.WriteLine("Incorrect date! Abort mission!");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                if (!_bll.UpdateAuthor(author.ID, author.Secondname, author.Firstname, birthDate))
                                                {
                                                    Console.WriteLine("An error occured. Nothing happend");
                                                    Console.WriteLine("Press any key");
                                                    Console.ReadKey();
                                                    return false;
                                                }

                                                Console.WriteLine("Changes successfully saved");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Operation canceled. Going back");
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                                return false;
                                            }
                                    }
                                }
                            case "d":
                                {
                                    if(!_bll.DeleteAuthor(author.ID))
                                    {
                                        Console.WriteLine("An error occured. Nothing happend");
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.WriteLine("Author has successfully deleted");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    return true;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
            }
        }
    }
}
