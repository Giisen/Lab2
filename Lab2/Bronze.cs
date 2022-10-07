namespace Lab2;

public class Bronze : Customer
{

    public Bronze(string name, string password) : base(name, password)
    {
        Rabatt = (decimal)0.95;
    }
}