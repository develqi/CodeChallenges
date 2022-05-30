namespace Domain;

/// <summary>
/// Convert any currency to USD by division
/// </summary>
public class AnyToUSD : ConvertStrategy
{
    private readonly string _fromCurrency;

    public AnyToUSD(List<ExchangeTree> exchanges, string fromCurrency, double amount) : base(amount, exchanges) 
    {
        _fromCurrency = fromCurrency;
    }

    public override double Convert()
    {
        return _amount / _exchanges.FindAnyToUSDConversionRate(_fromCurrency);
    }
}
