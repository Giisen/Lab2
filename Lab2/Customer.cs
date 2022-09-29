using System.Diagnostics;
using System.Xml.Linq;

namespace Lab2;

public class Customer
{
    private string _CustomerName;

    public string CustomerName
    {
        get { return _CustomerName; }
        set { _CustomerName = value; }
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

    

    private List<Products> _CartList;

    public List<Products> CartList
    {
        get { return _CartList; }
        set { _CartList = value; }
    }



    public Customer(string name, string password)  //Varför måste denna ha en konstruktor i Products? eller ärva från Products?
        
    {
        _CustomerName = name;
        CustomerPassword = password;
        _CartList = new List<Products>();
        
    }


    public override string ToString()
    {
        string stringKundvagn = $"Namn: {CustomerName}\n";
        stringKundvagn += $"Lösenord: {CustomerPassword}\n";
        string display = string.Empty;


        var distinktLista = CartList.Select(p => p.ProduktNamn).Distinct(); //Tar ut distinkta produktnamn.

        foreach (var prod in distinktLista)
        {
            var produkter = CartList.FirstOrDefault(p => p.ProduktNamn == prod);
            var antalProdukter = CartList.Where(p => p.ProduktNamn == prod).Count();
            display = $"{produkter}\t {antalProdukter} st {produkter}";
            Console.WriteLine();
            stringKundvagn += $"Antal produkter: {antalProdukter}";
        }

        stringKundvagn += $"Kundvagn:\n{display}\n";

        return stringKundvagn;
    }





}