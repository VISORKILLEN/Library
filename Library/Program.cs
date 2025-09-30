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

            //For how many log in attempts and to se what user is logged in
            int attempts = 3;
            int userLogin = -1;

        //Here i have a start point for when the user wants to log out.
        start:
            Console.Clear();
            Console.WriteLine("Välkommen till bibloteket hemsida.");
            Console.WriteLine("");
            Console.WriteLine("Vänligen skriv in användarnamn för att börja logga in.");
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
                    Console.WriteLine("");
                    Console.WriteLine("Fel användarnamn eller lösenord. Försök igen.");
                    Console.WriteLine("Skriv in användarnamn.");
                }
            }

            //what happens if you fail 3 times to log in
            if (userLogin == -1)
            {
                Console.WriteLine("");
                Console.WriteLine("För många felaktiga svar, starta om programmet för att fösöka att logga in!");
                return;
            }

        // A menu start point and the whole meny. And to make it look better
        menu:
            Console.Clear();
            Console.WriteLine("Välj vad du vill göra!");
            Console.WriteLine("1. Visa böcker");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");
            string menuChoice = Console.ReadLine();
            Console.WriteLine("");

            switch (menuChoice)
            {
                //Code to check how many books are left to borrow.
                case "1":
                    Console.WriteLine("Tillgängliga böcker att låna:");
                    availableBooks();
                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "2":
                    Console.WriteLine("Vilken bok skulle du vilja låna? Skriv numret:");
                    availableBooks();

                    bool validToLoan = int.TryParse(Console.ReadLine(), out int loanChoices);
                    if (validToLoan && loanChoices >= 1 && loanChoices <= books.Length)
                    {
                        int index = loanChoices - 1;
                        if (amountBooks[index] > 0)
                        {
                            amountBooks[index]--;
                            booksLoaned[userLogin][index]++;
                            Console.WriteLine($"Du har lånat {books[index]}.");
                        }
                        else
                        {
                            Console.WriteLine("Den boken är tyvärr helt slut.");
                        }
                    }

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "3":
                    Console.WriteLine("Vilken bok skulle du vilja lämna tillbaka? Skriv en siffra");
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (booksLoaned[userLogin][i] > 0)
                        {
                            Console.WriteLine($"{i + 1}. {books[i]} - Du har lånat {booksLoaned[userLogin][i]} exemplar");
                        }
                    }

                    bool validReturns = int.TryParse(Console.ReadLine(), out int returnChoices);

                    if (validReturns && returnChoices >= 1 && returnChoices <= books.Length)
                    {
                        int index = returnChoices - 1;
                        if (booksLoaned[userLogin][index] > 0)
                        {
                            amountBooks[index]++;
                            booksLoaned[userLogin][index]--;
                            Console.WriteLine($"Du har lämnat tillbaka {books[index]}.");
                        }
                        else
                            Console.WriteLine("Tyvärr felaktig inlämmning");
                    }
                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "4":

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "5":

                    Console.WriteLine("Du har loggat ut!");
                    Console.ReadLine();
                    goto start;

                default:
                    Console.WriteLine("Ogiltligt val. Vänligen försök igen.");
                    Console.WriteLine("");
                    goto menu;

            }
        }

        static void availableBooks()
        {
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]} - {amountBooks[i]} finns kvar.");
            }
        }

    }


}
