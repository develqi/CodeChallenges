public record class ExchangeTree(string Currency, string? ParentCurency, double Conversionrate)
{
    public double ToUsdConversionrate { get; init; }
}