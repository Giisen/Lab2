namespace Lab2;

public class Gold : Customer
{
    public Gold(string name, string password) : base(name, password)
    {
        Rabatt = 0.85F;
    }
}