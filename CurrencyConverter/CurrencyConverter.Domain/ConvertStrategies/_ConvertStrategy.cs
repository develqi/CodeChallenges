namespace Domain;

public abstract class ConvertStrategy
{
    protected readonly double _amount;
    protected readonly List<ExchangeTree> _exchanges;

    public ConvertStrategy(double amount, List<ExchangeTree> exchanges)
    {
        _amount = amount;
        _exchanges = exchanges;
    }
    
    public abstract double Convert();
}