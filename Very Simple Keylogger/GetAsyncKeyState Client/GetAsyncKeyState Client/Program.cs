using System.IO;
using System.Net.Sockets;

static class Program
{
    static void Main(string[] args)
    {
        TcpClient tc = new TcpClient("localhost", 4444);
        
        while (true)
        {
            Console.WriteLine((char)tc.GetStream().ReadByte());
        }
    }
}