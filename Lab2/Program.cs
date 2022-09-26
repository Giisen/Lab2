using System.IO;
using Lab2;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Välkomen till butiken -* GIISEN *-\n");




// Skapar en lista med både användarnamn och lösenord
        List<Customer> CustomerList = new List<Customer>();
        CustomerList.Add(new Customer("Knatte", "123"));
        CustomerList.Add(new Customer("Fnatte", "321"));
        CustomerList.Add(new Customer("Tjatte", "213"));


/*
//Skapar en lista med bara användarnamn
List<string> CustomerNameList = new List<string>();
CustomerNameList.Add(new string("Knatte"));
CustomerNameList.Add(new string("Fnatte"));
CustomerNameList.Add(new string("Tjatte"));

//Customer[,] CustomerArray = new Customer[4,2];
//CustomerArray

//Skapar en lista med bara lösenord
List<string> CustomerPasswordList = new List<string>();
CustomerPasswordList.Add(new string("123"));
CustomerPasswordList.Add(new string("321"));
CustomerPasswordList.Add(new string("213"));
*/

// Diverse variabler
        Customer? currentUser = null; // Sätter currentUser till null.
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

                //Lägger till nyKund i CustomerList
                Customer nyKund = new Customer(newCustomerName, newCustomerPassword); 
                CustomerList.Add(new Customer(newCustomerName, newCustomerPassword));

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
                foreach (var cust in CustomerList)
                {
                    if (cust.CustomerName == inputName)// Jämför inputname med alla CustomerName i min Customerlista.
                    {
                        CustomerNamnOK=true;
                        currentUser = cust; //Får CustomerName på currentUser
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

                while (!CustomerPassOk && currentUser != null)
                {
                    Console.WriteLine("Skriv in ditt lösenord:");
                    string inputPassword = Console.ReadLine();

                    currentUser.TestLogin(CustomerNamnOK, inputPassword);  //Härifrån fattar jag inte!!!
                    
                    if (currentUser.logInOk == true)
                    {
                        CustomerPassOk = true;
                    }

                }
                inlogg = true;
                meny1 = false;

            }
        }



        Console.WriteLine("\nVälkommen in!");
    }
}


/*   Här nedan kan jag använda en textfil

// Hänvisning till min textfil där användare och password är sparat
StreamReader sr = new StreamReader("C:\\Users\\krist\\Documents\\GitHub\\Lab2\\Users.txt");
// Läser första raden
string line = sr.ReadLine();
// Läs varje rad tills raden är null
while (line != null)
{
    // Skriv ut raden i filen
    Console.WriteLine(line);
    // Läs nästa rad
    line = sr.ReadLine();
}
//Stänger filen
sr.Close();
Console.ReadLine();



//Console.WriteLine("\nVälkommen in!");

*/


