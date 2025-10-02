namespace IT_CSU.Numbers;

public class NumberForConvertion : NumberAbstract
{
    private byte NewBase { get; set; }

    public void SetValues(string number, byte originalBase, byte newBase)
    {
        OldBase = originalBase;
        NewBase = newBase;
        if (number.IsNegativeNumberAsString()) IsNegativeNumber = true;
        NumberAsDecimal = number.ConvertToDecimal(OldBase);
        Value = NumberAsDecimal.ConvertFromDecimal(NewBase);

    }

    public (string, byte, byte) GetValues()
    {
        return (Value, OldBase, NewBase);
    }
    
}