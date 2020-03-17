using System;
using Microsoft.Extensions.DependencyInjection;

namespace Facade_with_DI
{
    interface ICalculator
    {
        int Add(int a, int b);
        int Sub(int a, int b);
        int Mult(int a, int b);
        int Div(int a, int b);
    }
    interface IArrayOperations
    {
        int Sum(int[] arr);
        int Avg(int[] arr);
    }
    class ConcreteCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
    class ConcreteArrayOperations : IArrayOperations
    {
        public int Avg(int[] arr)
        {
            return Sum(arr) / arr.Length;
        }

        public int Sum(int[] arr)
        {
            var result = 0;
            Array.ForEach(arr, x => result += x);
            return result;
        }
    }
    class ArithmeticFacade
    {
        private ICalculator _calculator;//DI
        private IArrayOperations _operations;//DI
        public ArithmeticFacade(ICalculator calculator, IArrayOperations operations)
        {
            _calculator = calculator;
            _operations = operations;
        }
        public int Add(int a,int b)
        {
            return _calculator.Add(a, b);
        }
        public int Multiply(int a, int b)
        {
            return _calculator.Mult(a, b);
        }
        public int Subtract(int a,int b)
        {
            return _calculator.Sub(a, b);
        }
        public int Divide(int a,int b)
        {
            return _calculator.Div(a, b);
        }
        public int ArrayAverage(int[] arr)
        {
            return _operations.Avg(arr);
        }
        public int ArraySum(int[] arr)
        {
            return _operations.Sum(arr);
        }
    }
    class Program
    {
        private static ArithmeticFacade arithmetic;
        static void InitDependencies()//DI
        {
            var sc = new ServiceCollection();
            sc.AddSingleton<ICalculator, ConcreteCalculator>();
            sc.AddSingleton<IArrayOperations, ConcreteArrayOperations>();
            sc.AddSingleton<ArithmeticFacade>();
            var sp = sc.BuildServiceProvider();
            arithmetic = sp.GetService<ArithmeticFacade>();
        }
        static void TestFacade()
        {
            InitDependencies();
            Console.WriteLine("Add " + arithmetic.Add(4, 3));
            Console.WriteLine("Multiply " + arithmetic.Multiply(4, 3));
            Console.WriteLine("Divide " + arithmetic.Divide(4, 2));
            Console.WriteLine("Subtract " + arithmetic.Subtract(4, 3));
            Console.WriteLine("ArrayAverage " + arithmetic.ArrayAverage(new int[] { 3, 3, 3 }));
            Console.WriteLine("ArraySum " + arithmetic.ArraySum(new int[] { 3, 3, 3 }));
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            TestFacade();
            Console.ReadKey(true);
        }
    }
}
