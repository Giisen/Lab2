using System.Diagnostics;

namespace Lab2;

public class Customer
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



    public  override  string  ToString()
    {
        var stringKundvagn= $"{CustomerName}\n";
        stringKundvagn = $"{CustomerPassword}\n";

        return stringKundvagn;
    }




    private List<Cart> _CartList;

    public List<Cart> CartList
    {
        get { return _CartList; }
        set { _CartList = value; }
    }



    public Customer(string name, string password)  //Varför måste denna ha en konstruktor i Products? eller ärva från Products?
        
    {
        _CustomerName = name;
        CustomerPassword = password;
        _CartList = new List<Cart>();
        
    }

    //Försöker fixa en totalkostnad för hela varukorgen
  
    //public int VarukorgKostnad()
    //{
    //    int VarukorgKostnad = TotalPrisEnhet;
    //    return VarukorgKostnad;
    //}

   
    //public string ToString()
    //{

    //    //string printInfo = CartList; //($"Ditt namn: {CustomerName} Ditt lösenord är: {CustomerPassword} Din kunvagn består just nu av: {CartList}");
    //    return ToString(CartList);

    //}


}