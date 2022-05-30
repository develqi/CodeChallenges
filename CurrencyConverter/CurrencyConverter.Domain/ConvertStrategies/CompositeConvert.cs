namespace Domain;

/// <summary>
/// Convert composite path. First convert any currency to USD and the convert USD to the result currency
/// </summary>
public class CompositeConvert : ConvertStrategy
{
    private readonly string _toCurrency;
    private readonly string _fromCurrency;

    public CompositeConvert(List<ExchangeTree> exchanges, string fromCurrency, string toCurrency, double amount) : base(amount, exchanges)
    {
        _toCurrency = toCurrency;
        _fromCurrency = fromCurrency;
    }

    public override double Convert()
    {
        return _amount / _exchanges.FindAnyToUSDConversionRate(_fromCurrency) 
                       * _exchanges.FindUSDToAnyConversionRate(_toCurrency);
    }
}