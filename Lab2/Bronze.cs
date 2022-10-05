namespace Lab2;

public class Bronze : Customer
{

    public Bronze(string name, string password) : base(name, password)
    {
        Rabatt = 0.95F;
    }
}