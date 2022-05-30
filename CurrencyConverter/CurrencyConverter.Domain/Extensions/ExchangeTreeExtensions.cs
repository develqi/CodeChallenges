
public static class ExchangeTreeExtensions
{    
    public static double FindUSDToAnyConversionRate(this List<ExchangeTree> exchanges, string toCurrency)
    {
        return exchanges.First(exchange => exchange.Currency == toCurrency).ToUsdConversionrate;
    }

    public static double FindAnyToUSDConversionRate(this List<ExchangeTree> exchanges, string fromCurrency)
    {
        return exchanges.First(exchange => exchange.Currency == fromCurrency).ToUsdConversionrate;
    }

    public static double FindParentToUSDConversionRate(this List<ExchangeTree> exchanges, string parrentCurrency)
    {
        return exchanges.First(exchange => exchange.Currency == parrentCurrency).ToUsdConversionrate;
    }
}
