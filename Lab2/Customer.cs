using System.Diagnostics;

namespace Lab2;

public class Customer: Products
{
    private readonly string _CustomerName;

    public string CustomerName
    {
        get { return _CustomerName; }
        private set { }
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
    }



    public Customer(string name, string password)
    {
        _CustomerName = name;
        CustomerPassword = password;
        
    }


    public int TotalPris;

    public Customer(string namn, decimal pris, int antal, int totalpris) : base()
    {
        ProductName = namn;
        Price = pris;
        Antal = antal;
        totalpris = (int)(pris * antal);
        TotalPris = totalpris;


    }


    //public string ToString()
    //{

    //    //string printInfo = CartList; //($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: {CartList}");
    //    return ToString(CartList);

    //}


}