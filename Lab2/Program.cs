using System.Reflection.Metadata;
using Lab2;

Console.WriteLine("Välkomen till butiken -* GIISEN *-\n");


// Skapar en lista med både användarnamn och lösenord
List<Customer> CustomerList = new List<Customer>();
CustomerList.Add(new Customer("Knatte","123"));
CustomerList.Add(new Customer("Fnatte","321"));
CustomerList.Add(new Customer("Tjatte","213"));


//Skapar en lista med bara användarnamn
List<string> CustomerNameList = new List<string>();
CustomerNameList.Add(new string("Knatte"));
CustomerNameList.Add(new string("Fnatte"));
CustomerNameList.Add(new string("Tjatte"));

//Skapar en lista med bara lösenord
List<string> CustomerPasswordList = new List<string>();
CustomerPasswordList.Add(new string("123"));
CustomerPasswordList.Add(new string("321"));
CustomerPasswordList.Add(new string("213"));

string currentUser = string.Empty;
bool meny1 = true;
string inputMeny1 = string.Empty;
bool inlogg = false;
bool CustomerNamnOK=false;
bool CustomerPassOk=false;

    Console.WriteLine("\nVälj 1 om du är ny kund och vill skapa en profil\n" +
                      "\nVälj 2 om du redan är kund och vill logga in");
    inputMeny1 = Console.ReadLine();

while (meny1)
{
    if (inputMeny1 == "1")
    {
        Console.WriteLine("Skriv in ditt användarnamn:");
        string newCustomerName = Console.ReadLine();
        Console.WriteLine("Skriv in ditt lösenord:");
        string newCustomerPassword = Console.ReadLine();
        Customer Kund4 = new Customer(newCustomerName, newCustomerPassword); //Här skulle jag vilja ha ett annat namn på Kund4, ex newCustomerName
        CustomerNameList.Add(new string(Kund4.CustomerName));
        Console.WriteLine("Toppen! Nästa steg blir att logga in.");
    }
    else if (inputMeny1 == "2")
    {

    }
    else
    {
        Console.WriteLine("Du gjorde ett ogiltigt val, välj 1 eller 2");
    }


    while (!inlogg)
    {
        Console.WriteLine("Dags att logga in\n");
        Console.WriteLine("Skriv in ditt användarnamn: ");
        string inputName = Console.ReadLine();

        foreach (string name in CustomerNameList)
        {
            if (inputName == name)
            {
                currentUser = name;
                CustomerNamnOK=true;
            }
        }


        if (!CustomerNamnOK)
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

        while (!CustomerPassOk)
        {
            Console.WriteLine("Skriv in ditt lösenord:");
            string inputPassword = Console.ReadLine();
            //bool passOK = CustomerPasswordList.Contains(inputPassword); //Här måste jag hitta ett sätt att jämföra lösenord med rätt person, inte Contains

            foreach (string password in CustomerPasswordList)
            {
                if (inputName == password)
                {
                    CustomerPassOk = true;
                }
            }

            if (!CustomerPassOk)
            {
                Console.WriteLine("Lösenordet är fel, försök igen");
            }
        }

        
    }
}


Console.WriteLine("\nVälkommen in!");
