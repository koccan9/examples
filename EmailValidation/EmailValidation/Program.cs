using System.Text.RegularExpressions;

static class Program
{
    static void Main(String[] args)
    {
        string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        string string_input=Console.ReadLine();
        if(new Regex(pattern).IsMatch(string_input))
        {
            Console.WriteLine("Matches");
        }
        else
        {
            Console.WriteLine("Does not match");
        }
    }
}