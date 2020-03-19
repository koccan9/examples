using System;

namespace Factory_Pattern_Example1      //Creation OOP pattern.Factory Pattern
{
    interface IShape
    {
        void Draw();
    }
    class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Triangle");
        }
    }
    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square");
        }
    }
    enum ShapeType
    {
        Triangle, Square
    }
    interface IAbstractShapeFactory
    {
        IShape GetShape(ShapeType st);
    }
    class ConcreteShapeFactory : IAbstractShapeFactory
    {
        public IShape GetShape(ShapeType st)
        {
            if (st == ShapeType.Square)
            {
                return new Square();
            }
            return new Triangle();
        }
    }
    static class FactoryTester//static test functions
    {
        private static IAbstractShapeFactory _shapeFactory;
        static FactoryTester()//static constructor
        {
            _shapeFactory = new ConcreteShapeFactory();
        }
        public static void TestFactory()//test scenario1
        {
            IShape triangle = _shapeFactory.GetShape(ShapeType.Triangle);
            IShape square = _shapeFactory.GetShape(ShapeType.Square);
            triangle.Draw();
            square.Draw();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            FactoryTester.TestFactory();
        }
    }
}
