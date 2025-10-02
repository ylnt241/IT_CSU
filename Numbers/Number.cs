namespace IT_CSU.Numbers;

public class Number
    : NumberAbstract
{
    public void SetValues(string number, byte originalBase)
    {
        OldBase = originalBase;
        if (number.IsNegativeNumberAsString()) IsNegativeNumber = true;
        Value = number;
        NumberAsDecimal = number.ConvertToDecimal(OldBase);
    }


}