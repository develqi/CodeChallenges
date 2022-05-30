namespace Domain;

/// <summary>
/// Convert USD to USD for example
/// </summary>
public class SameConvert : ConvertStrategy
{
    public SameConvert(double amount, List<ExchangeTree> exchanges = default) : base(amount, exchanges) { }

    public override double Convert() => _amount;
}
