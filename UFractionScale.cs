using System.Collections;
using System.Collections.Generic;

namespace DMBTools
{
    public class UFractionScale
    {
        public static UFractionScale zero = new UFractionScale(0, 0);
        uint numerator;
        readonly uint denominator;
        bool isPositive;

        public UFractionScale(uint num, uint den, bool isPos = true)
        {
            numerator = num;
            denominator = den;
            isPositive = isPos;
        }
        public UFractionScale(int num, int den, bool isPos = true) : this((uint)num, (uint)den, isPos) { }
        public UFractionScale(uint integer, bool isPos = true) : this(integer, integer, isPos) { }
        public UFractionScale(int integer, bool isPos = true) : this((uint)integer, (uint)integer, isPos) { }
        public UFractionScale(UFractionScale f) : this(f.numerator, f.denominator, f.isPositive) { }
        public UFractionScale() : this(0, 0, true) { }

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
            if (isPositive && numerator < amount)
            {
                numerator = amount - numerator;
                isPositive = !isPositive;
            }
            else if (!isPositive)
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
            if (!isPositive && numerator - amount < 1 && numerator != amount)
            {
                numerator += amount;
                isPositive = true;
            }
            else if (!isPositive && numerator == amount)
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
        public void Increment(int amount)
        {
            Increment((uint)amount);
        }
        public void Reset()
        {
            numerator = 0;
        }
        public uint ToInt()
        {
            return numerator / denominator;
        }
        public double ToDouble()
        {
            return (double)numerator / (double)denominator;
        }
        public float ToFloat()
        {
            return (float)numerator / (float)denominator;
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


}

