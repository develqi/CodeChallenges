using Domain;

namespace UnitTests;

public class Currency_Converter_Unit_Tests
{
    [Theory]
    [ClassData(typeof(ConvertTheoryData))]
    public void Amount_and_ExpectedResult_Test(ConvertData data)
    {
        // Arrange
        var converter = new CurrencyConverter(); // ToDo: Use DI to create CurrencyConverter instance

        // Tuple
        // !!! واقعا خوانا نیست

        var conversionRates = new List<Tuple<string, string, double>>
        {
            new Tuple<string, string, double>("USD", "CAD", 1.34),
            new Tuple<string, string, double>("CAD", "GBP", 0.58),
            new Tuple<string, string, double>("USD", "EUR", 0.86),
        };

        converter.UpdateConfiguration(conversionRates);

        // Act & Assert
        converter.Convert(data.FromCurrency, data.ToCurrency, data.Amount).Should().Be(data.ExpectedResult);
    }
}

