static class Program
{
    static void Main(string[] args)
    {
        if(args.Length != 2)
        {
            Console.WriteLine("wrong usage");
            return;
        }
        FileStream fs = File.OpenRead(args[0]);
        StreamReader sr = new StreamReader(fs);
        var pass = args[1];
        for(var i = sr.ReadLine(); i != null; i = sr.ReadLine())
        {
            if(pass == i)
            {
                Console.WriteLine("password is " + i);
                return;
            }
        }
        Console.WriteLine("password could not be found");
    }
}