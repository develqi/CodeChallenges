namespace UnitTests;

public record class ConvertData(string FromCurrency, string ToCurrency, double Amount, double ExpectedResult);

public class ConvertTheoryData : TheoryData<ConvertData>
{
    public ConvertTheoryData()
    {
        // Direct convert
        Add(new ConvertData("USD", "CAD", 1, 1.34)); // Multiply
        Add(new ConvertData("CAD", "USD", 1.34, 1)); // Division
        Add(new ConvertData("CAD", "USD", 1, 0.74626865671641784)); // Division
                                          
        Add(new ConvertData("CAD", "GBP", 1, 0.58)); // Multiply
        Add(new ConvertData("GBP", "CAD", 0.58, 1)); // Division
        Add(new ConvertData("GBP", "CAD", 1, 1.7241379310344829)); // Division
                                          
        Add(new ConvertData("USD", "EUR", 1, 0.86)); // Multiply
        Add(new ConvertData("EUR", "USD", 0.86, 1)); // Division
        Add(new ConvertData("EUR", "USD", 1, 1.1627906976744187)); // Division

        // 2 Composite convert
        Add(new ConvertData("CAD", "EUR", 1.34, 0.86)); // CAD to EUR => CAD to USD(Division), USD to EUR(Multiply)
        Add(new ConvertData("EUR", "CAD", 0.86, 1.34)); // EUR to CAD => EUR to USD(Division), USD to CAD(Multiply)

        Add(new ConvertData("USD", "GBP", 1, 0.7772)); // USD to GBP => USD to CAD(Multiply), CAD to GBP(Multiply)
        Add(new ConvertData("GBP", "USD", 0.7772, 1)); // GBP to USD => GBP to CAD(Division), CAD to USD(Division)

        // 3 Composite convert
        Add(new ConvertData("GBP", "EUR", 0.7772, 0.86)); // GBP to EUR => GBP to CAD(Division), CAD to USD(Division), USD to EUR(Multiply)
        Add(new ConvertData("EUR", "GBP", 0.86, 0.7772)); // EUR to GBP => EUR to USD(Division), USD to CAD(Multiply), CAD to GBP(Multiply)
    }
}