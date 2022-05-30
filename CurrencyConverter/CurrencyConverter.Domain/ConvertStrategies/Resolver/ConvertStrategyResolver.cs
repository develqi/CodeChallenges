using Domain;

/// <summary>
/// Return best strategy to convert currencies
/// </summary>
public class ConvertStrategyResolver
{
    private readonly List<ExchangeTree> _exchanges;

    public ConvertStrategyResolver(List<ExchangeTree> exchanges) => _exchanges = exchanges;

    public ConvertStrategy GetConvertStrategy(string fromCurrency, string toCurrency, double amount)
    {
        if (fromCurrency == toCurrency)
            return new SameConvert(amount);

        if (fromCurrency == "USD")
            return new USDToAny(_exchanges, toCurrency, amount);

        if (toCurrency == "USD")
            return new AnyToUSD(_exchanges, fromCurrency, amount);

        return new CompositeConvert(_exchanges, fromCurrency, toCurrency, amount);
    }
}
