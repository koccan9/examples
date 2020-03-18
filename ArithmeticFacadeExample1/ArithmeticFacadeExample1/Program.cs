using System;

namespace FacadeFunctional1
{
    delegate int Adder(int a, int b);
    delegate int Subtractor(int a, int b);
    delegate int Multiplier(int a, int b);
    delegate int Divider(int a, int b);
    class Calculator
    {
        private Adder _adder;
        private Subtractor _subtractor;
        private Multiplier _multiplier;
        private Divider _divider;
        public Calculator()
        {
            _adder = (x, y) => x + y;//lambda expression
            _subtractor = (x, y) => x - y;//lambda expression
            _multiplier = (x, y) => x * y;//lambda expression
            _divider = (x, y) => x / y;//lambda expression
        }
        public int Add(int a, int b)
        {
            return _adder(a, b);
        }
        public int Sub(int a, int b)
        {
            return _subtractor(a, b);
        }
        public int Div(int a, int b)
        {
            return _divider(a, b);
        }
        public int Mult(int a, int b)
        {
            return _multiplier(a, b);
        }
    }
    class ArrayOperations
    {
        private Action<int[]> _adder;//array adder
        private int _sum;//temp array sum
        public ArrayOperations()
        {
            _adder = (x) =>
            {
                var result = 0;
                Array.ForEach(x, y =>
                {
                    result += y;
                });
                _sum = result;
            };
        }
        public int ArraySum(int[] arr)
        {
            _adder(arr);
            return _sum;
        }
    }
    class ArithmeticFacade
    {
        private ArrayOperations _arrays;
        private Calculator _calc;
        public ArithmeticFacade()
        {
            _arrays = new ArrayOperations();
            _calc = new Calculator();
        }
        public int SumArray(int[] arr)
        {
            return _arrays.ArraySum(arr);
        }
        public int Add(int a, int b)
        {
            return _calc.Add(a, b);
        }
        public int Sub(int a, int b)
        {
            return _calc.Sub(a, b);
        }
        public int Mul(int a, int b)
        {
            return _calc.Mult(a, b);
        }
        public int Div(int a, int b)
        {
            return _calc.Div(a, b);
        }
    }
    class Program
    {
        static void TestFacade()
        {
            var facade = new ArithmeticFacade();
            Console.WriteLine("Add " + facade.Add(4, 3));
            Console.WriteLine("Mul " + facade.Mul(4, 3));
            Console.WriteLine("Div " + facade.Div(8, 2));
            Console.WriteLine("Sub " + facade.Sub(12, 5));
            Console.WriteLine("SumArray " + facade.SumArray(new int[] { 4, 4, 3 }));
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            TestFacade();
            Console.ReadKey(true);
        }
    }
}
