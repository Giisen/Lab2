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
        _CartList = new List<Products>();
    }

    //Försöker fixa en totalkostnad för hela varukorgen
  
    public int VarukorgKostnad()
    {
        int VarukorgKostnad = TotalPrisEnhet;
        return VarukorgKostnad;
    }

    public int TotalPrisEnhet;
    public Customer(string namn, decimal pris, int antal, int totalprisenhet) : base()
    {
        ProductName = namn;
        Price = pris;
        Antal = antal;
        totalprisenhet = (int)(pris * antal);
        TotalPrisEnhet = totalprisenhet;
    }


    //public string ToString()
    //{

    //    //string printInfo = CartList; //($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: {CartList}");
    //    return ToString(CartList);

    //}


}