using System.ComponentModel.Design;
using System.IO;
using Lab2;


class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Välkomen till butiken -* GIISEN *-\n");


        // Skapar en lista med både användarnamn och lösenord
        List<Customer> CustomerList = new List<Customer>();
        CustomerList.Add(new Customer("k", "l")); //Ta bort denna vid inlämning
        CustomerList.Add(new Customer("Knatte", "123"));
        CustomerList.Add(new Customer("Fnatte", "321"));
        CustomerList.Add(new Customer("Tjatte", "213"));


        // Skapar en lista med produkter
        List<Products> ProdList = new List<Products>();
        ProdList.Add(new Products("Midrange disc", 169, 1));
        ProdList.Add(new Products("Bag", 999, 1));
        ProdList.Add(new Products("Basket", 1999, 1));


        // Skapar en lista till vår kundvagn
        //List<Products> CList = new List<Products>(); //Skapar en kundvagn längre ner
        



            // Diverse variabler
        Customer? currentUser = null;
        bool meny1 = true;
        string inputMeny1 = string.Empty;
        bool inlogg = false;
        bool CustomerNamnOK = false;
        bool CustomerPassOk = false;
        bool visaButik = true;
        bool handla = true;


        // Första menyn (meny1) för att välja ny användare eller logga in befintlig
        Console.WriteLine("\nVälj 1 om du är ny kund och vill skapa en profil" +
                          "\nVälj 2 om du redan är kund och vill logga in");

        inputMeny1 = Console.ReadLine();

        while (meny1)
        {
            if (inputMeny1 == "1")
            {
                Console.WriteLine("Ange ett användarnamn:");
                string newCustomerName = Console.ReadLine();
                Console.WriteLine("Ange ett lösenord:");
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
                Console.Clear();
                Console.WriteLine("Logga in genom att skriva in ditt användarnamn: ");
                string inputName = Console.ReadLine();
                foreach (var cust in CustomerList)
                {
                    if (cust.CustomerName == inputName) // Jämför inputname med alla CustomerName i min Customerlista.
                    {
                        CustomerNamnOK = true;
                        currentUser = cust; //Får CustomerName på currentUser
                    }
                }


                if (!CustomerNamnOK)
                {
                    Customer.CustomerMeny();

                    string inputX = Console.ReadLine();

                    if (inputX == "1")
                    {
                        inputMeny1 = "1"; // Undrar om denna gör något?
                        break;
                    }
                    else if (inputX == "2")
                    {
                        break;
                    }
                    else if (inputX == "3")
                    {

                        Environment.Exit(0);

                    }
                    else
                    {
                        Console.WriteLine("Du gjorde ett ogiltigt val, välj 1,2 eller 3");
                    }


                }

                while (!CustomerPassOk && currentUser != null)
                {
                    Console.WriteLine("Skriv in ditt lösenord:");
                    string inputPassword = Console.ReadLine();

                    currentUser.TestLogin(CustomerNamnOK, inputPassword);

                    if (currentUser.logInOk)
                    {
                        CustomerPassOk = true; //Borde kunna tabort denna och bara använda logInOk.....
                    }

                }

                inlogg = true;
                meny1 = false;

            }
        }

        
        List<Customer> CartList = new List<Customer>(); //Skapar en kundvagn, kan man få namnet på denna samma som currentUser?

        while (visaButik)
        {
            
            Shop.VisaButik();
            
            string inputMeny2 = Console.ReadLine();

            while (handla)
            {
                if (inputMeny2 == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Vi har dessa kanonprodukter:\n");
                    foreach (var prod in ProdList)
                    {
                        Console.WriteLine($" {prod.ProductName}--------{prod.Price} kr st");
                    }

                    Shop.Handla();
                    

                    string inputHandla = Console.ReadLine();
                    Console.WriteLine("Hur många vill du köpa?");
                    int inputantal = Int32.Parse(Console.ReadLine()); // måste lägga till try() Catch()



                    if (inputHandla == "1")
                    {
                        CartList.Add(new Customer("Midrange disc", 169, inputantal,169));
                        
                        Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                        string input = Console.ReadLine().ToLower();
                        if (input == "n")
                        {
                            break;
                        }
                    }

                    else if (inputHandla == "2")
                    {
                        CartList.Add(new Customer("Bag", 999, inputantal,999));

                        Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                        string input = Console.ReadLine().ToLower();
                        if (input == "n")
                        {
                            break; 
                        }

                    }
                    else if (inputHandla == "3")
                    {
                        CartList.Add(new Customer("Basket", 1999, inputantal,1999));
                        Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                        string input = Console.ReadLine().ToLower();
                        if (input == "n")
                        {
                            break; 
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Du har gjort ett ogiltigt val, du kan endast välja 1, 2 eller 3");
                        Console.ReadLine();
                    }

                }
                else if (inputMeny2 == "2")
                {
                    Console.WriteLine($"Du har lagt följande produkter i varukorgen:");


                    
                    foreach (var prod in CartList)
                    {
                        Console.WriteLine($"{prod.ProductName} {prod.Antal} st, med ett totalpris: {prod.TotalPrisEnhet}");
                    }

                    

                    Console.WriteLine("Vill du gå vidare till kassan (j) för ja (n) för nej?");
                    string inputVarukorg = Console.ReadLine().ToLower();
                    if (inputVarukorg == "n")
                    {
                        visaButik = false;
                        break;
                    }
                    else
                    {
                        inputMeny2 = "3";
                    }
                    
                }
                else if (inputMeny2 == "3")
                {
                    Console.WriteLine("Dags att betala...");
                    //Cart.Kassa();
                    Console.ReadLine();
                    visaButik = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Du gjorde ett ogiltigt val");
                }
            }


        }

        



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


