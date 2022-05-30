namespace Domain;

public interface ICurrencyConverter
{
    /// <summary>
    /// Clears any prior configuration.
    /// </summary>
    void ClearConfiguration();

    /// <summary>
    /// Converts the specified amount to the desired currency.
    /// </summary>
    double Convert(string fromCurrency, string toCurrency, double amount);

    /// <summary>
    /// Updates the configuration. Rates are inserted or replaced internally.
    /// </summary>
    void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates);

    // من موافق استفاده از 
    // Tuple
    // در این قسمت نیستم. 
    // خوانایی مناسبی در موقع استفاده از مقادیر آن ندارد
    // به جای آن پیشنهاد میکنم یک کلاس با خصوصیات مشخص تعریف شود
    // و لیستی از نمونه های آن کلاس، به این متد پاس داده شود
 }

public class CurrencyConverter : ICurrencyConverter
{
    private List<ExchangeTree>? _exchages;
    private readonly object _lockObject = new();

    public void ClearConfiguration() => _exchages = default;

    public double Convert(string fromCurrency, string toCurrency, double amount)
    {
        if (_exchages == null || !_exchages.Any())
            throw new ArgumentNullException("There are no conversion rates!");

        lock (_lockObject)
        {
            return new ConvertStrategyResolver(_exchages)
                  .GetConvertStrategy(fromCurrency, toCurrency, amount)
                  .Convert();
        }
    }

    public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
    {
        lock (_lockObject)
        {
            // ارز 
            // USD
            // به عنوان ارز واحد در نظر گرفته شده
            // و به صورت دستی  یک درخت تو در تو از ارزها تعریف شده است
            // در صورت نیاز، سورس مربوط به ایجاد درخت داینامیک نوشته خواهد شد

            // نرخ تبدیل تمام ارزها به 
            // USD
            // فقط یکبار محاسبه می شود
            // و در این کلاس که به صورت 
            // Singleton
            // نمونه سازی می شود نگهداری می شود

            // ToDo: Map Tuple<string, string, double> to List<ExchangeTree> dynamically
            _exchages = new List<ExchangeTree>
            {
                new ExchangeTree("USD", null, 1) { ToUsdConversionrate = 1 },
            };

            AddExchangeItem("CAD", "USD", 1.34);
            AddExchangeItem("GBP", "CAD", 0.58);
            AddExchangeItem("EUR", "USD", 0.86);

            // Inline method
            void AddExchangeItem(string currency, string parrentCurrency, double conversionRate)
            {
                var exchange = new ExchangeTree(currency, parrentCurrency, conversionRate)
                {
                    ToUsdConversionrate = conversionRate * _exchages.FindParentToUSDConversionRate(parrentCurrency)
                };
                _exchages.Add(exchange);
            }
        }
    }
}