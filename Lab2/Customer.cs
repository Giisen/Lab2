using System.Diagnostics;
using System.Xml.Linq;

namespace Lab2;

public class Customer
{
    private readonly string _CustomerName;

    public string CustomerName
    {
        get { return _CustomerName;}
       
        
    }
    
    private string _CustomerPassword;

    public string CustomerPassword
    {
        get { return _CustomerPassword; }
        set { _CustomerPassword = value; }
    }


    private bool _logInOk;

    public bool logInOk

    {
        get { return _logInOk; }
        set { _logInOk = value; }
    }


    private List<Products> _CartList;

    public List<Products> CartList
    {
        get { return _CartList; }
        set { _CartList = value; }
    }


    public Customer(string name, string password)

    {
        _CustomerName = name;
        CustomerPassword = password;
        _CartList = new List<Products>();

    }

    

    public bool TestLogin(bool namn, string password)
    {

        if (namn == true && password == CustomerPassword)
        {
            logInOk = true;

        }

        return logInOk;
    }


    public static void CustomerMeny()
    {
        Console.Clear();
        Console.WriteLine("\nAnvändaren finns inte, vill du skapa en ny användare?\n" +
                          "1 för att skapa ny användare\n" +
                          "2 för att försöka logga in igen\n" +
                          "3 för att stänga programmet.");
    }

    

    

    // Visar kundvagnen
    public override string ToString()
    {
        Console.Clear();
        Console.WriteLine($"\n****** Välkommen till din kundvagn ******\n");
        //Console.WriteLine($"{CustomerName}");
        string stringKundvagn = $"Namn: {CustomerName}\n";
        stringKundvagn += $"Lösenord: {CustomerPassword}\n\n";
        string display = string.Empty;
        int summa = 0;
        int totalsumma = 0;

        var distinktLista = CartList.Select(p => p.ProduktNamn).Distinct(); //Tar ut distinkta produktnamn.

        //var nyLista = from cart in CartList select cart;
        stringKundvagn+=("\nProdukter:\n");
        foreach (var prod in CartList)
        {
            //var antalProdukter = distinktLista.Where(p => p. == prod).Count();
            //var produkter = distinktLista.FirstOrDefault(p => p.ProduktNamn == prod);
            //var pris = distinktLista.FirstOrDefault(x => x.Pris == prod);
            ////var prods = prod.ProduktNamn;
            //display = $"{produkter}\t {antalProdukter} st {produkter}";
            //Console.WriteLine("Nedan skirver ut alla prod");
            //Console.WriteLine(prod);
            //Console.WriteLine("bryter rad och skriver ut produkter");
            //Console.WriteLine(produkter);
            
            summa = (prod.Pris * prod.Antal);
            stringKundvagn += $"{prod.ProduktNamn} \t{prod.Pris} per st\tantal: {prod.Antal}\ttotalpris: {summa} kr\n";

            totalsumma += summa;

            //Console.WriteLine($"Produkterna är: {prods}");

            //Console.WriteLine($"Priset är {pris}");

        }
        stringKundvagn += $"\nSumman av din kundvagn: {totalsumma} kr";

        //stringKundvagn += $"Kundvagn:\n{display}\n";

        return stringKundvagn;
    }





}