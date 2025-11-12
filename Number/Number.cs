namespace IT_CSU.Number;

public abstract class Number
{
    protected Number(byte oldBase)
    {
        OldBase = oldBase;
    }

    public bool IsNegativeNumber { get; protected set; }
    protected string? Value { get; }
    protected byte OldBase { get; }
    protected byte NewBase { get; }
}