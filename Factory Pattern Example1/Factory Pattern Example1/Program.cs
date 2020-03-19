using System;

namespace Factory_Pattern_Example1
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
    static class ShapeFactory
    {
        public static IShape GetShape(ShapeType st)
        {
            if (st == ShapeType.Square)
            {
                return new Square();
            }
            return new Triangle();
        }
    }
    class Program
    {
        static void TestFactory()
        {
            IShape tr = ShapeFactory.GetShape(ShapeType.Triangle);
            IShape sqr = ShapeFactory.GetShape(ShapeType.Square);
            tr.Draw();
            sqr.Draw();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            TestFactory();
        }
    }
}
