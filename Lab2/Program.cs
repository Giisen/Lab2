using Lab2;

Console.WriteLine("Välkomen till butiken -* GIISEN *-\n");

List<Customer> CustomerList = new List<Customer>();
CustomerList.Add(new Customer("Knatte", "321"));
CustomerList.Add(new Customer("Fnatte", "123"));
CustomerList.Add(new Customer("Tjatte", "213"));


bool meny1 = true;
string inputMeny1 = string.Empty;
bool inlogg = false;
while (meny1)
{
    Console.WriteLine("\nVälj 1 om du är ny kund och vill skapa en profil\n" +
                      "\nVälj 2 om du redan är kund och vill logga in");
     inputMeny1 = Console.ReadLine();

    if (inputMeny1 == "1")
    {
        Console.WriteLine("Skriv in ditt användarnamn: ");
        string newCustomerName = Console.ReadLine();
        Console.WriteLine("Skriv in ditt lösenord: ");
        string newCustomerPassword = Console.ReadLine();
        Customer Kund4 = new Customer(newCustomerName, newCustomerPassword); //Här skulle jag vilja ha ett annat namn på Kund4, ex newCustomerName
        meny1 = false;
        Console.WriteLine("Toppen! Nästa steg blir att logga in.");
        break;
    }
}

while (!inlogg)
{
    Console.WriteLine("Dags att logga in\n");
    Console.WriteLine("Skriv in ditt användarnamn: ");
    string inputName = Console.ReadLine();

    if (CustomerList.Any(user => user.CustomerName != inputName)) // && user.CustomerPassword != inputPassword))
    {
        Console.WriteLine("\nAnvändaren finns inte, vill du skapa en ny användare?\n" +
                          "Skriv 1 för att skapa ny användare eller 2 för att stänga programmet.");
        string inputX = Console.ReadLine();

        if (inputX == "1")
        {
            inputMeny1 = "1";
            break;
        }
        else if (inputX == "2")
        {

            Environment.Exit(0);

        }
        else
        {
            Console.WriteLine("Du gjorde ett ogiltigt val, välj 1 eller 2");
        }


    }

    Console.WriteLine("Skriv in ditt lösenord: ");
    string inputPassword = Console.ReadLine();


        
    }
}



    else
{
    Console.WriteLine("Du gjorde ett ogiltigt val, välj 1 eller 2");
}
}

Console.WriteLine("\nVälkommen in!");
//foreach (var item in CustomerList)
//{
//    Console.WriteLine(item.CustomerName);
//}

