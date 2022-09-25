using Lab2;
Console.WriteLine("Välkomen till butiken -* GIISEN *-\n");

Customer Kund1 = new Customer("Knatte", "123");
Customer Kund2 = new Customer("Fnatte", "321");
Customer Kund3 = new Customer("Tjatte", "213");


bool meny1 = true;
while (meny1)
{
    Console.WriteLine("\nVälj 1 om du är ny kund och vill skapa en profil\n" +
                      "\nVälj 2 om du redan är kund och vill logga in");
    string inputMeny1 = Console.ReadLine();

    switch (inputMeny1)
    {
        case "1":
            Console.WriteLine("Skriv in ditt användarnamn: ");
            string newCustomerName = Console.ReadLine();
            Console.WriteLine("Skriv in ditt lösenord: ");
            string newCustomerPassword = Console.ReadLine();
            Customer Kund4 = new Customer(newCustomerName, newCustomerPassword); //Här skulle jag vilja ha ett annat namn på Kund4, ex newCustomerName
            meny1 = false;
            break;

        case "2":
            Console.WriteLine("Skriv in ditt användarnamn: ");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("Skriv in ditt lösenord: ");
            string CustomerPassword = Console.ReadLine();
            meny1 = false;
            break;

        default:
            Console.WriteLine("Du gjorde ett ogiltigt val, välj 1 eller 2");
            meny1 = true;
            break;
    }
}