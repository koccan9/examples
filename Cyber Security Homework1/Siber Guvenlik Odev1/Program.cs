using System;
using System.IO;
using System.Diagnostics;
namespace CyberSecurityHomework1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo ps_nmap = new ProcessStartInfo();
            ps_nmap.RedirectStandardOutput = true;//redirect child stdout
            ps_nmap.RedirectStandardError = true;//redirect child stderr
            ps_nmap.FileName = "nmap";//process to create
            ps_nmap.Arguments = "-F 127.0.0.1";// -F means fast scan
            Process process_nmap = new Process();
            process_nmap.StartInfo = ps_nmap;
            process_nmap.Start();//CreateProcess
            StreamWriter sr_out = new StreamWriter("nmap result.txt");
            StreamWriter sr_err = new StreamWriter("nmap error if exists.txt");
            StreamReader stdout = process_nmap.StandardOutput;//child process's standard output stream.
            StreamReader stderr = process_nmap.StandardError;//child process's standard error stream.
            sr_out.WriteLine(stdout.ReadToEnd());
            sr_err.WriteLine(stderr.ReadToEnd());
            sr_err.Close();//allways must do
            sr_out.Close();//allways must do
            process_nmap.WaitForExit();//wait for process to finish
            int nmap_exit_code = process_nmap.ExitCode;//best practice
            Console.WriteLine("nmap was finished exit code is " + nmap_exit_code);
            Console.ReadKey(true);//hang console until user presses a key
        }
    }
}
