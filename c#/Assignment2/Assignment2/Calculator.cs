using System;

namespace Assignment2
{
    public class Calculator : ICalculator
    {
        private dynamic _result;

        public void AddNumbers(int num1, int num2, int num3 = 0)
        {
                SetResult ( num1 + num2 + num3 );
        }

        public void AddTwoFloat(float num1, float num2)
        {
                SetResult ( num1 + num2 );
        }
        public void SetResult(dynamic num)
        { 
            this._result = num;
            //Console.WriteLine("Ans is: " + _result);
        }

        public virtual dynamic GetResult()
        {
            return _result;
        }

    }
}
