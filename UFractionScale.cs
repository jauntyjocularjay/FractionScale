using System.Collections;
using System.Collections.Generic;

public class UFractionScale
{
    uint numerator;
    readonly uint denominator;
    bool isPositive;

    public UFractionScale(uint num, uint den, bool isPos=true)
    {
        numerator = num;
        denominator = den;
        isPositive = isPos;
    }
    public UFractionScale(uint integer, bool isPos=true)
    {
        numerator = integer;
        denominator = integer;
        isPositive = isPos;
    }
    public UFractionScale(UFractionScale f)
    {
        numerator = f.numerator;
        denominator = f.denominator;
    }
    public uint Get()
    {
        return numerator;
    }
    public uint GetNumerator()
    {
        return numerator;
    }
    public void SetNumerator(uint n)
    {
        numerator = n;
    }
    public uint GetDenominator()
    {
        return denominator;
    }
    public void Decrement()
    {
        Decrement(1);
    }
    public void Decrement(uint amount)
    {
        if(isPositive && numerator < amount)
        {
            numerator = amount-numerator;
            isPositive = !isPositive;
        }
        else if(!isPositive)
        {
            numerator += amount;
        }
        else 
        {
            numerator -= amount;
        }
    }
    public void Increment()
    {
        Increment(1);
    }
    public void Increment(uint amount)
    {
        if(!isPositive && numerator - amount < 1 && numerator != amount)
        {
            numerator += amount;
            isPositive = true;
        }
        else if(!isPositive && numerator == amount)
        {
            numerator = 0;
            isPositive = true;
        }
        else if (!isPositive)
        {
            numerator -= amount;
        }
        else
        {
            numerator += amount;
        }
    }
    public uint ToInt()
    {
        return numerator / denominator;
    }
    public double ToDouble()
    {
        return (double) numerator / (double) denominator;
    }
    public float ToFloat()
    {
        return (float) numerator / (float) denominator;
    }
    override public string ToString()
    {
        return $"{numerator} / {denominator}";
    }
    public bool Full()
    {
        return numerator >= denominator;
    }

    public bool IsPositive()
    {
        return isPositive;
    }

    public bool IsNegative()
    {
        return !isPositive;
    }
}
