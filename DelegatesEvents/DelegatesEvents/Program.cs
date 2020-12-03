using System;

namespace DelegatesEvents
{
    class Program
    {
        //Declare Delegates
        delegate int CalcDelegate(int a, int b);

        //Declare Multicast Delegate
        delegate void MulticastCalcDelegate(int a, int b);

        static void Main(string[] args)
        {
            
  
            MyCalculator myCalc = new MyCalculator();

            //Add reference of Method to the Delegate
            CalcDelegate calcDelegate = new CalcDelegate(myCalc.Add);
            //Invoke Delegate
            int result = calcDelegate(3, 4);
            //Console.WriteLine(result);

            //Delegate referencing Anonymous Function
            CalcDelegate calcDelegateAnonymous = (a, b) => { int sum = a + b; return sum; };

            //Invoke Delegate
            result = calcDelegateAnonymous(5, 6);
            //Console.WriteLine(result);

            //Add Methods to Multicast Delegate and Invoke
            MyCalculatorMultiCast mycalcObj = new MyCalculatorMultiCast();
            MulticastCalcDelegate multiCalcDelegate = mycalcObj.Add;
            multiCalcDelegate += mycalcObj.Subtract;
            multiCalcDelegate(5, 7);
            multiCalcDelegate -= mycalcObj.Add;
            multiCalcDelegate(5, 7);
            Console.Read();

        }

        
    }

    public class MyCalculator
    {
        //Method that we will add to Delegate
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class MyCalculatorMultiCast
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }
    }
}
