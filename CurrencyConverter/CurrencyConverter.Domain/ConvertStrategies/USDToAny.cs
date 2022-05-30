namespace Domain;

/// <summary>
/// Convert any currency to USD by multiply
/// </summary>
public class USDToAny : ConvertStrategy
{
    private readonly string _toCurrency;

    public USDToAny(List<ExchangeTree> exchanges, string toCurrency, double amount) : base(amount, exchanges) 
    {
        _toCurrency = toCurrency;
    }

    public override double Convert()
    {
        return _amount * _exchanges.FindUSDToAnyConversionRate(_toCurrency);
    }
}
