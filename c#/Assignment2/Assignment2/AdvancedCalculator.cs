using System;

namespace Assignment2
{
    public class AdvancedCalculator : Calculator
    {
        public void Power(int num, int power)
        {
                var result = Math.Pow(num,power);
                SetResult(result);
                
        }

        public override dynamic GetResult()
        {
            return base.GetResult() * 1000000;
        }

    }
}
