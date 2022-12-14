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
        // Diverse variabler
        Customer? currentUser = null;
        string inputMeny1 = string.Empty;
        bool inlogg = false;
        bool CustomerNamnOK = false;
        bool CustomerPassOk = false;
        bool loggaut = true;
        string valutaText=String.Empty;

        

        List<Customer> CustomerList = new List<Customer>();


        var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var file = Path.Combine(desktop, "KristerUsers.txt");
        if (File.Exists(file))
        {
            using (StreamReader sr = new StreamReader(file))
            {
                var line = sr.ReadLine();


                while (line != null)
                {
                    var split = line.Split(',');
                    string discount = split[0];
                    string userName = split[1];
                    string passw = split[2];



                    if (discount == "Basic")
                    {
                        CustomerList.Add(new Customer($"{userName}", $"{passw}"));
                    }

                    if (discount == "Bronze")
                    {
                        CustomerList.Add(new Bronze($"{userName}", $"{passw}"));
                    }

                    if (discount == "Silver")
                    {
                        CustomerList.Add(new Silver($"{userName}", $"{passw}"));
                    }

                    if (discount == "Gold")
                    {
                        CustomerList.Add(new Gold($"{userName}", $"{passw}"));
                    }
                    line = sr.ReadLine();

                }
            }
        }
        else
        {
            //Skapar en lista med användarnamn och lösenord
            CustomerList.Add(new Bronze("k", "l"));
            CustomerList.Add(new Silver("Knatte", "123"));
            CustomerList.Add(new Customer("Fnatte", "321"));
            CustomerList.Add(new Gold("Tjatte", "213"));
        }




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
                    string newCustomerName = String.Empty;
                    string newCustomerPassword = String.Empty;
                    bool testNull = true;
                    while (testNull)
                    {
                        Console.WriteLine("Ange ett användarnamn:");
                        newCustomerName = Console.ReadLine();
                        Console.WriteLine("Ange ett lösenord:");
                        newCustomerPassword = Console.ReadLine();

                        if (newCustomerName.Length == 0 || newCustomerPassword.Length == 0)
                        {
                            Console.WriteLine("Användarnamn eller lösenord kan inte vara tomt.");
                            Console.ReadKey();
                            testNull = true;
                        }
                        else
                        {
                            testNull=false;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Välj din rabattnivå :-) :\n" +
                                      "1. Bronze, 5% rabatt\n" +
                                      "2. Silver, 10% rabatt\n" +
                                      "3. Gold, 15% rabatt");
                    string inputRabatt = Console.ReadLine();

                    switch (inputRabatt)
                    {
                        case "1":
                        {
                            CustomerList.Add(new Bronze(newCustomerName, newCustomerPassword));
                            break;
                        }
                        case "2":
                        {
                            CustomerList.Add(new Silver(newCustomerName, newCustomerPassword));
                            break;
                        }
                        case "3":
                        {
                            CustomerList.Add(new Gold(newCustomerName, newCustomerPassword));
                            break;
                        }

                        default:
                        {
                            CustomerList.Add(new Customer(newCustomerName, newCustomerPassword));
                            Console.WriteLine("Ok, ingen rabatt till dig :-)");
                            Console.ReadKey();
                            break;
                        }
                    }


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


            //Skriver kunderna till filen KristerUsers.txt som läggs på skrivbordet

            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var kund in CustomerList)
                {
                    if (kund is Bronze bronze)
                    {
                        sw.Write("Bronze,");
                        sw.Write($"{kund.CustomerName},");
                        sw.WriteLine(kund.CustomerPassword);

                    }
                    else if(kund is Silver silver)
                    {
                        sw.Write("Silver,");
                        sw.Write($"{kund.CustomerName},");
                        sw.WriteLine(kund.CustomerPassword);

                    }
                    else if(kund is Gold gold)
                    {
                        sw.Write("Gold,");
                        sw.Write($"{kund.CustomerName},");
                        sw.WriteLine(kund.CustomerPassword);

                    }
                    else
                    {
                        sw.Write("Basic,");
                        sw.Write($"{kund.CustomerName},");
                        sw.WriteLine(kund.CustomerPassword);
                    }
                }
            }




            Shop.Valuta();
            double valuta = 1.0;
            bool valutabool = false;
            while (!valutabool)
            {

                string inputValuta = Console.ReadLine();
                switch (inputValuta)
                {
                    case "1":
                        valuta = 1.0;
                        valutaText = $"{Shop.valutaLista[0]}";
                        valutabool = true;
                        break;

                    case "2":
                        valuta = 0.12;
                        valutaText = $"{Shop.valutaLista[1]}";
                        valutabool = true;
                        break;

                    case "3":
                        valuta = 100.0;
                        valutaText = $"{Shop.valutaLista[2]}";
                        valutabool = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, var god försök igen");
                        valutabool = false;
                        break;
                }

            }

            Products.ProdList.Clear();
            Products.CreateList(valuta, valutaText); 





            //----------------------------------------------Inlogg klar, nu in i butiken---------------------------------------------------------------        


            while (visaButik)
            {

                Shop.VisaButik();

                string inputMeny2 = Console.ReadLine();

                while (handla)
                {
                    if (inputMeny2 == "1")
                    {
                        
                        Shop.Handla();

                        string inputHandla = Console.ReadLine();
                        int inputantal = 0;
                        
                        if (inputHandla == "1")
                        {

                            // Provar Try and Catch
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
                                currentUser.CartList.Add(new Products($"{Products.ProdList[0].ProduktNamn}", Products.ProdList[0].Pris, inputantal));
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
                                currentUser.CartList.Add(new Products($"{Products.ProdList[1].ProduktNamn}", Products.ProdList[1].Pris, inputantal));
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
                                currentUser.CartList.Add(new Products($"{Products.ProdList[2].ProduktNamn}", Products.ProdList[2].Pris, inputantal));
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
                            Console.WriteLine("Du har gjort ett ogiltigt val, du kan endast bland produkterna som finns i lager.");
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

