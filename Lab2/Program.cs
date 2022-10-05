using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Channels;
using System.Xml.Linq;
using Lab2;


class Program
{
    public static void Main(string[] args)
    {

        // Skapar en lista med både användarnamn och lösenord
        List<Customer> CustomerList = new List<Customer>();
        CustomerList.Add(new Bronze("k", "l"));
        CustomerList.Add(new Silver("Knatte", "123"));
        CustomerList.Add(new Customer("Fnatte", "321"));
        CustomerList.Add(new Gold("Tjatte", "213"));


        // Skapar en lista med produkter
        List<Products> ProdList = new List<Products>();
        ProdList.Add(new Products("Midrange", 169, 1));
        ProdList.Add(new Products("Väska   ", 999, 1));
        ProdList.Add(new Products("Korg    ", 1999, 1));

        // Diverse variabler
        Customer? currentUser = null;
        string inputMeny1 = string.Empty;
        bool inlogg = false;
        bool CustomerNamnOK = false;
        bool CustomerPassOk = false;
        bool loggaut = true;
        

        //----------------------------------------------Meny1----------------------------------------------------------

        while (loggaut)
        {
            bool visaButik = true;
            bool handla = true;
            bool meny1 = true;

            while (meny1)
            {
                Console.Clear();
                Console.WriteLine("Välkomen till butiken ----***** GIISEN *****----\n" +
                                  "\nVälj 1 om du är ny kund och vill skapa en profil" +
                                  "\nVälj 2 om du redan är kund och vill logga in");

                inputMeny1 = Console.ReadLine();


                if (inputMeny1 == "1")
                {
                    Console.WriteLine("Ange ett användarnamn:");
                    string newCustomerName = Console.ReadLine();
                    Console.WriteLine("Ange ett lösenord:");
                    string newCustomerPassword = Console.ReadLine();
                    Console.WriteLine("Välj din rabattnivå :-) :\n" +
                                      "1. Basic, ingen rabatt\n" +
                                      "2. Bronze, 5% rabatt\n" +
                                      "3. Silver, 10% rabatt\n" +
                                      "4. Gold, 15% rabatt");
                    string inputRabatt = Console.ReadLine();

                    switch (inputRabatt)
                    {
                        case "1":
                        {
                            CustomerList.Add(new Customer(newCustomerName, newCustomerPassword));
                            break;
                        }
                        case "2":
                        {
                            CustomerList.Add(new Bronze(newCustomerName, newCustomerPassword));
                                break;
                        }
                        case "3":
                        {
                            CustomerList.Add(new Silver(newCustomerName, newCustomerPassword));
                            break;
                        }
                        case "4":
                        {
                            CustomerList.Add(new Gold(newCustomerName, newCustomerPassword));
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Du har gjort ett ogiltigt val, vänligen välj rabatt");
                            Console.ReadKey();
                            break;
                        }
                    }


                    //Lägger till kund i CustomerList
                    //CustomerList.Add(new Customer(newCustomerName, newCustomerPassword));
                    meny1 = false;
                }
                else if (inputMeny1 == "2")
                {
                    meny1 = false;
                }
                else
                {
                    Console.WriteLine("Du gjorde ett ogiltigt val, välj 1 eller 2");
                    Console.ReadLine();
                    continue;
                }




                //----------------------------------------------Logga in--------------------------------------------------------------

                

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
                            currentUser = cust;
                            inlogg = true;
                        }
                    }


                    if (!CustomerNamnOK)
                    {
                        Customer.CustomerMeny();

                        string inputX = Console.ReadLine();

                        if (inputX == "1")
                        {
                            meny1 = true;
                            break;

                        }
                        else if (inputX == "2")
                        {
                            
                        }
                        else if (inputX == "3")
                        {

                            Environment.Exit(0);

                        }
                        else
                        {
                            Console.WriteLine("Du gjorde ett ogiltigt val, välj 1, 2 eller 3");
                        }

                    }

                }
            }




            while (!CustomerPassOk && currentUser != null)
            {
                Console.WriteLine("Skriv in ditt lösenord:");
                string inputPassword = Console.ReadLine();

                currentUser.TestLogin(CustomerNamnOK, inputPassword);

                if (currentUser.logInOk)
                {
                    CustomerPassOk = true;
                }
                else
                {
                    Console.WriteLine("Lösenordet är fel, var god försök igen.");
                }

            }




            //----------------------------------------------Inlogg klar, nu in i butiken---------------------------------------------------------------        

            
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
                            Console.WriteLine($"{prod.ProduktNamn}\t{prod.Pris} kr st");
                        }


                        // Vilka produkter vill du köpa?
                        Shop.Handla();

                        string inputHandla = Console.ReadLine();
                        int inputantal = 0;

                        if (inputHandla == "1")
                        {

                            try
                            {
                                Console.WriteLine("Hur många vill du köpa?");
                                inputantal = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Du kan endast mata in en siffra, var god gör om dina val.");

                            }

                            catch (Exception e)
                            {
                                Console.WriteLine("Du har gjort ett ogiltigt val, vänligen mata in en siffra");
                            }

                            if (inputantal > 0)
                            {
                                currentUser.CartList.Add(new Products("Midrange", 169, inputantal));
                            }

                            Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                            string input = Console.ReadLine().ToLower();
                            if (input == "n")
                            {
                                break;
                            }
                        }

                        else if (inputHandla == "2")
                        {
                            try
                            {
                                Console.WriteLine("Hur många vill du köpa?");
                                inputantal = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Du kan endast mata in en siffra, var god gör om dina val.");

                            }

                            catch (Exception e)
                            {
                                Console.WriteLine("Du har gjort ett ogiltigt val, vänligen mata in en siffra");
                            }


                            if (inputantal > 0)
                            {
                                currentUser.CartList.Add(new Products("Väska   ", 999, inputantal));
                            }

                            Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                            string input = Console.ReadLine().ToLower();
                            if (input == "n")
                            {
                                break;
                            }

                        }
                        else if (inputHandla == "3")
                        {
                            try
                            {
                                Console.WriteLine("Hur många vill du köpa?");
                                inputantal = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Du kan endast mata in en siffra, var god gör om dina val.");

                            }

                            catch (Exception e)
                            {
                                Console.WriteLine("Du har gjort ett ogiltigt val, vänligen mata in en siffra");
                            }


                            if (inputantal > 0)
                            {
                                currentUser.CartList.Add(new Products("Korg     ", 1999, inputantal));
                            }

                            Console.WriteLine("Vill du fortsätta handla (j) för ja (n) för nej?");
                            string input = Console.ReadLine().ToLower();
                            if (input == "n")
                            {
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine(
                                "Du har gjort ett ogiltigt val, du kan endast bland produkterna som finns i lager, välj en siffra tack.");
                            Console.ReadLine();
                        }

                    }




                    //------------------------------------------------Visa kundvagnen---------------------------------------------------
                    

                    else if (inputMeny2 == "2")
                    {

                        

                        Console.WriteLine(currentUser);

                        Console.WriteLine("\nVill du gå vidare till kassan (j) för ja (n) för nej?");
                        string inputVarukorg = Console.ReadLine().ToLower();
                        if (inputVarukorg == "n")
                        {
                            visaButik = true;
                            break;
                        }
                        else if (inputVarukorg == "j")
                        {
                            inputMeny2 = "3";
                        }
                        else
                        {
                            Console.WriteLine("\nDu har gjort ett ogiltigt val, välj 'j' eller 'n'");
                            Console.ReadLine();
                            inputMeny2 = "2";
                        }

                    }



                    //---------------------------------------------Visa kassan---------------------------------------------------------------



                    else if (inputMeny2 == "3")
                    {
                        Console.WriteLine("\n\nDags att betala...");
                        Console.WriteLine("Tryck på valfri tangent för att betala");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Tack för din beställning, den skickas inom kort!");
                        currentUser.CartList.Clear();
                        Environment.Exit(0);
                        visaButik = false;
                        break;
                    }
                    
                    //Logga ut användare
                    else if (inputMeny2 == "4")
                    {
                        inlogg = false;
                        CustomerPassOk = false;
                        CustomerNamnOK = false;
                        visaButik = false;
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("Du gjorde ett ogiltigt val");
                        Console.ReadLine();
                        break;

                    }
                    
                }
                
            }
            
        }
    }
}

