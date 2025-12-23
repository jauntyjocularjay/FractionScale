using System;

namespace DMBTools
{
    public class FractionScale
    {
        public static readonly FractionScale zero = new FractionScale(0, 0);
        int _numerator;
        public int Numerator { get; set; }
        readonly int _denominator;
        public int Denominator { get; }
        public FractionScale(int num, int den)
        {
            _numerator = num;
            _denominator = den;
        }
        public FractionScale(int integer) : this(integer, 1) { }
        public FractionScale(FractionScale f) : this(f._numerator, f._denominator) { }
        public FractionScale() : this(0, 0) { }

        public int GetNumerator()
        {
            return _numerator;
        }
        public void SetNumerator(int n)
        {
            _numerator = n;
        }
        public int GetDenominator()
        {
            return _denominator;
        }
        public void Decrement()
        {
            _numerator -= 1;
        }
        public void Decrement(int amount)
        {
            _numerator -= amount;
        }
        public void Increment()
        {
            _numerator += 1;
        }
        public void Increment(int amount)
        {
            _numerator += amount;
        }
        public int ToInt()
        {
            return _numerator / _denominator;
        }
        public int ToIntFloor()
        {
            return (int)Math.Floor(this.ToFloat());
        }
        public int ToIntCeiling()
        {
            return (int)Math.Ceiling(this.ToFloat());
        }
        public double ToDouble()
        {
            return (double)_numerator / (double)_denominator;
        }
        public float ToFloat()
        {
            return (float)_numerator / (float)_denominator;
        }
        override public string ToString()
        {
            return $"{_numerator} / {_denominator}";
        }
        public bool IsFull()
        {
            return _numerator >= _denominator;
        }
        FractionScale Add(FractionScale f)
        {
            if (this.Denominator == f.Denominator)
            {
                return new FractionScale(this.Numerator + f.Numerator, this.Denominator);
            }
            else
            {
                int new_denominator = this.Denominator * f.Denominator;

                FractionScale fraction_a = new FractionScale
                (
                    this.Numerator * f.Denominator,
                    new_denominator
                );
                FractionScale fraction_b = new FractionScale
                (
                    f.Numerator * this.Denominator,
                    new_denominator
                );
                return fraction_a.Add(fraction_b);
            }
        }
    }
}
