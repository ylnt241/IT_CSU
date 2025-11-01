namespace IT_CSU.Numbers;

public abstract class NumberAbstract
{
    protected bool IsNegativeNumber;
    protected string Value;
    protected byte OldBase;
    protected decimal NumberAsDecimal {get;set;}

    // {
    //     var (number, originalBase, newBase) = UserInput.GetInput();
    //     if (number.IsNegativeNumberAsString()) isNegativeNumber = true;
    //     Value = number;
    //     OldBase = originalBase;
    // }

    public void ToDecimalNumberSystem()
    {
        NumberAsDecimal = Value.ConvertToDecimal(OldBase);
    }
    public decimal GetDecimalValue()
    {
        return NumberAsDecimal;
    }

    public string GetValue()
    {
        return Value;
    }

    public byte GetOldBase()
    {
        return OldBase;
    }
}
