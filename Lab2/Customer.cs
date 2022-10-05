using System.Data.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Lab2;

public class Customer
{
    private readonly string _CustomerName;

    public string CustomerName
    {
        get { return _CustomerName; }


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

    private float _Rabatt;

    public float Rabatt
    {
        get { return _Rabatt; }
        set { _Rabatt = value; }
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
        Rabatt = 1.0F;
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
                          "1. för att skapa ny användare\n" +
                          "2. för att försöka logga in igen\n" +
                          "3. för att stänga programmet.");
    }

    public virtual double Discount()
    {
        return Rabatt;
    }
    


    //Metod för totalsumman för kundvagnen
    public int KundvagnTotal()
    {
        int totalsumma = 0;
        int summa = 0;
        foreach (var prod in CartList)
        {
            summa = (prod.Pris * prod.Antal);
            totalsumma += summa;
        }
        return totalsumma;
    }





    // Visar kundvagnen
    public override string ToString()
    {
        Console.Clear();
        Console.WriteLine($"\n****** Välkommen till din kundvagn ******\n");

        string stringKundvagn = $"Namn: {CustomerName}\n";
        stringKundvagn += $"Lösenord: {CustomerPassword}\n\n";

        var antProd = 0;
        var distinktLista = CartList.Select(p => p.ProduktNamn).Distinct(); //Tar ut distinkta produktnamn.

        stringKundvagn += ("\nProdukter:\n");
        foreach (var prod in distinktLista)
        {
            var produkter = CartList.FirstOrDefault(p => p.ProduktNamn == prod);
            antProd = CartList.Where(p => p.ProduktNamn == prod).Sum(p => p.Antal);
            int totalpris = antProd * produkter.Pris;
            stringKundvagn += ($"\n{produkter.ProduktNamn}\t antal: {antProd} st\t styckpris: {produkter.Pris} kr\tsumma: {totalpris} kr");
        }


        stringKundvagn += $"\n\nSumman av din kundvagn: {KundvagnTotal()} kr";
        stringKundvagn += $"\nRabatt:"+ Math.Floor((1.0F-Rabatt) *100)+"%";
        stringKundvagn += $"\nAtt betala: {Math.Floor(KundvagnTotal()*Rabatt)} kr";

        return stringKundvagn;
    }
}