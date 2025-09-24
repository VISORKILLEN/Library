namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //Here i have a start point for when the user wants to log out.
        start:
            //Here i have som diffrenet datatypes with arrays, so  that the user can login with username and pin-code.
            //Then also that there are 5 different books you can borrow.
            string[] names = {"Elsa", "Amanda", "Simon", "Per", "Bengt" };
            int[] password = { 1234, 9999, 1111, 5050, 6969 };
            string[] books = { "Harry potter", "Where the Crawdads Sing", "It", "It Ends With us", "Lord of the Flies" };
            int attempts = 3;
            int userLogin = -1;

            //Here is i have a while loop so the user can try to log in with pin-code and username
            while (attempts > 0)
            {
                Console.WriteLine("Skriv in användarnamn.");
                string username = Console.ReadLine();

                Console.WriteLine("Skriv in din PIN-Kod.");
                bool validPin = int.TryParse(Console.ReadLine(), out int userPassword);
                //Here is what happens if you have the right username but wrong pin-code
                if (!validPin)
                {
                    Console.WriteLine("Fel PIN-Kod. Vänligen försök igen.");
                    attempts--;
                    continue;
                }
                //These lines of code is so that if the username and pinkod match it makes the user log in oke ans makes the next if  statement.
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == username && password[i] == userPassword)
                    {
                        userLogin = i;
                        break;
                    }
                }
                //If the user puts in the right username and PIN-code it says a WriteLine , if it has the wrong username a different WriteLine happens.
                //Also if íts the right username and PIN-code it breaks and goes to out of the loop and gets to the menu.
                if (userLogin != -1)
                {
                    Console.WriteLine($"Välkommen {username}");
                    break;
                }
                else
                {
                    Console.WriteLine("Fel användarnamn. Försök igen.");
                    attempts--;
                }
            }
            //If you puts in wrong login 3 times the program says restart to try to log in again.

            if (userLogin == -1)
            {
                Console.WriteLine("För många felaktiga svar, starta om programmet för att fösöka att logga in!");
                return;
            }

        //Here I have some Console.WriteLines and so the user knows what options there are.
        //Also a "menu: so that there is a point where the user can go back too, so the can pick another choice in the menu
        menu:
            Console.WriteLine("Välj vad du vill göra!");
            Console.WriteLine("1. Visa böcker");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");

            string menuChoice = Console.ReadLine();
            

            switch (menuChoice)
            {
                case "1":
                    Console.WriteLine($"{books[0]}, {books[1]}, {books[2]}, {books[3]}, {books[4]}");

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "2":

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "3":

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "4":

                    Console.WriteLine("Klicka på Enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    goto menu;

                case "5":
                    goto start;
                 
            }
        }



    }


}
