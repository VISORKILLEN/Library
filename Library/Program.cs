namespace Library
{
    internal class Program
    {

        public static string[] books = { "Harry potter and the Goblet of Fire", "Where the Crawdads Sing", "It", "It Ends With us", "Lord of the Flies" };
        public static int[] amountBooks = { 3, 11, 6, 4, 8 };

        static void Main(string[] args)
        {
            //Here i have som diffrenet datatypes with arrays, so  that the user can login with username and pin-code.
            //Then also that there are 5 different books you can borrow. And How many of evry book there is.
            string[] names = { "Elsa", "Amanda", "Simon", "Per", "Bengt" };
            int[] password = { 1234, 9999, 1111, 5050, 6969 };

            //A jaggedArray to keep track of which book every user has borrowed
            int[][] booksLoaned = new int[names.Length][];
            for (int i = 0; i < booksLoaned.Length; i++)
            {
                booksLoaned[i] = new int[books.Length];
            }

            //Code so that you can login in again
            bool running = true;

            while (running)
            {
                //For how many log in attempts and to se what user is logged in
                int attempts = 3;
                int userLogin = -1;

                //Here i have a start point for when the user wants to log out.

                Console.Clear();
                Console.WriteLine("Välkommen till bibloteket hemsida.");
                Console.WriteLine("\nVänligen skriv in användarnamn för att börja logga in.");

                //A loop so the user can try to log in with pin-code and username
                while (attempts > 0)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine("Vänligen skriv in användarnamn för att logga in.");
                    string username = Console.ReadLine();
                    Console.WriteLine("Skriv in din PIN-Kod.");
                    bool validPin = int.TryParse(Console.ReadLine(), out int userPassword);

                    //To see if PIN-code is correct
                    if (!validPin)
                    {
                        attempts--;
                        continue;
                    }
                    //To see if the username and pinkod match it makes the user login.
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == username && password[i] == userPassword)
                        {
                            userLogin = i;
                            break;
                        }
                    }

                    //If the user logs in or fail to do so
                    if (userLogin != -1)
                    {
                        Console.WriteLine($"Välkommen {username}");
                        break;
                    }

                    //To lower the attempts when failed login
                    attempts--;

                    //to write when you have attempts left 
                    if (attempts > 0)
                    {
                        Console.WriteLine("\nFel användarnamn eller lösenord. Försök igen.");
                        Console.WriteLine("Skriv in användarnamn.");
                    }
                }

                //what happens if you fail 3 times to log in
                if (userLogin == -1)
                {
                    Console.WriteLine("\nFör många felaktiga svar, starta om programmet för att fösöka att logga in!");
                    return;
                }

                //menu loop to have a starting point when logged in
                bool loggedIn = true;
                while (loggedIn)
                {
                    Console.Clear();
                    Console.WriteLine("Välj vad du vill göra!");
                    Console.WriteLine("1. Visa böcker");
                    Console.WriteLine("2. Låna bok");
                    Console.WriteLine("3. Lämna tillbaka bok");
                    Console.WriteLine("4. Mina lån");
                    Console.WriteLine("5. Logga ut");
                    string menuChoice = Console.ReadLine();

                    //Made cases for every menu choice
                    switch (menuChoice)
                    {
                        case "1":

                            //takes the "availableBooks and applies here
                            Console.WriteLine("\nTillgängliga böcker att låna:");
                            availableBooks();

                            //Tells the user to press "Enter to go back to menu.
                            Console.WriteLine("\nKlicka på Enter för att gå tillbaka till menyn");
                            Console.ReadLine();
                            break;

                        case "2":

                            //Takes the "availableBooks and see what books are available
                            Console.WriteLine("\nVilken bok skulle du vilja låna? Skriv numret:");
                            availableBooks();

                            //tries to see what number input the user puts in
                            bool validToLoan = int.TryParse(Console.ReadLine(), out int loanChoices);

                            //Checks if the input is valid in the books array
                            if (validToLoan && loanChoices >= 1 && loanChoices <= books.Length)
                            {
                                int index = loanChoices - 1;

                                //Checks so that there is som books left to borrow
                                if (amountBooks[index] > 0)
                                {
                                    //Lowers the amount of available books, and increase books borrowed for the user
                                    amountBooks[index]--;
                                    booksLoaned[userLogin][index]++;
                                    Console.WriteLine($"Du har lånat {books[index]}.");
                                }

                                //if there aren't any books left
                                else
                                {
                                    Console.WriteLine("Den boken är tyvärr helt slut.");
                                }
                            }

                            Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                            Console.ReadLine();
                            break;

                        case "3":
                            bool hasBook = false;

                            //Loop to se what books the user has borrowed
                            for (int i = 0; i < books.Length; i++)
                            {
                                if (booksLoaned[userLogin][i] > 0)
                                {
                                    Console.WriteLine("\nVilken bok skulle du vilja lämna tillbaka? Skriv en siffra");
                                    hasBook = true;
                                }
                            }

                            //Error code if the user hasen't loaned anything
                            if (!hasBook)
                            {
                                Console.WriteLine("Du lånar ingen bok just nu.");
                            }

                            //A loop to see what books are borrowed by that user.
                            for (int i = 0; i < books.Length; i++)
                            {
                                if (booksLoaned[userLogin][i] > 0)
                                {
                                    Console.WriteLine($"{i + 1}. {books[i]} - Du har lånat {booksLoaned[userLogin][i]} exemplar");
                                }
                            }

                            //Read the user input on which book the want to return
                            bool validReturns = int.TryParse(Console.ReadLine(), out int returnChoices);

                            //Checks if the input is a valid number in range
                            if (validReturns && returnChoices >= 1 && returnChoices <= books.Length)
                            {
                                int index = returnChoices - 1;

                                //Checks if the user have any copies to return
                                if (booksLoaned[userLogin][index] > 0)
                                {
                                    //Increases available copies to borrow, lowers the borrowed copies of the user.
                                    amountBooks[index]++;
                                    booksLoaned[userLogin][index]--;
                                    Console.WriteLine($"Du har lämnat tillbaka {books[index]}.");
                                }

                                //Error message if u try to input something that is not there.
                                else
                                {
                                    Console.WriteLine("Tyvärr felaktig inlämmning");
                                }
                            }
                            Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                            Console.ReadLine();
                            break;

                        case "4":

                            bool hasLoaned = false;

                            //Loop to se what books the user has borrowed
                            for (int i = 0; i < books.Length; i++)
                            {
                                if (booksLoaned[userLogin][i] > 0)
                                {
                                    Console.WriteLine($"\nDina lånade böcker är {books[i]} - {booksLoaned[userLogin][i]} exemplar.");
                                    hasLoaned = true;
                                }
                            }

                            //Error code if the user hasen't loaned anything.
                            if (!hasLoaned)
                            {
                                Console.WriteLine("Du lånar ingen bok just nu.");
                            }
                            Console.WriteLine("\nKlicka på Enter för att gå tillbaka till menyn");
                            Console.ReadLine();
                            break;

                        case "5":

                            //Goes back to start and logs out user
                            Console.WriteLine("\nDu har loggat ut!");
                            Console.ReadLine();
                            loggedIn = false;
                            break;

                        //If the choose anything outside of the menu choices
                        default:
                            Console.WriteLine("\nOgiltligt val. Vänligen försök igen.");
                            break;
                    }
                }
            }
        }
        //Loop that checks how many books are left to borrow.
        static void availableBooks()
        {
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]} - {amountBooks[i]} finns kvar.");
            }
        }
    }
}