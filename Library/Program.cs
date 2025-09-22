namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Elsa", "Amanda", "Simon", "Per", "Bengt" };
            int[] password = { 1234, 9999, 1111, 5050, 6969 };
            string[] books = { "Harry potter", "Where the Crawdads Sing", "It", "It Ends With us", "Lord of the Flies" };
            bool[] borrowedBook = new bool[5];
            string[,] nameLoans = new string[5, 5];

            int attempts = 3;
            int userLogin = -1;

            while (attempts > 0)
            {
                Console.WriteLine("Skriv in användarnamn.");
                string username = Console.ReadLine();

                Console.WriteLine("Skriv in din PIN-Kod.");
                bool validPin = int.TryParse(Console.ReadLine(), out int userPassword);

                if (!validPin)
                {
                    Console.WriteLine("Fel PIN-Kod. Vänligen försök igen.");
                    attempts--;
                    continue;
                }

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == username && password[i] == userPassword)
                    {
                        userLogin = i;
                        break;
                    }
                }

                if (userLogin != -1)
                {
                    Console.WriteLine($"Välkommen {username}");
                    break;
                }
                else{
                    Console.WriteLine("Fel användarnamn eller lösenord. Försök igen.");
                    attempts--;
                }
            }

            if (userLogin == -1)
            {
                Console.WriteLine("För många felaktiga svar, starta om programmet för att fösöka att logga in!");
                return;
            }

            Console.WriteLine("1. Visa böcker");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");

        }

    }


}
