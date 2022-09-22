static class Program
{
    const string letters = "asdfghjklşiçömnbvcxzqwertyuıopğü";
    const int length = 4;
    static void Main(string[] args)
    {
        var str = "";
        var random = new Random();
        for(var i = 0; i < length; i++)//we have generated our random password
        {
            str += letters[random.Next(0, letters.Length)];
        }
        Console.WriteLine("DEBUG for str: " + str);
        var str2 = "";
        for(int i = 0; i < str.Length; )//we are cracking the password with bruteforce that we created
        {
            char ch = letters[random.Next(0, letters.Length)];
            if (ch == str[i])
            {
                i++;
                str2 += ch;
            }
        }
        Console.WriteLine("DEBUG for str2: " + str2);
        Console.WriteLine(str + " == " + str2);
        Console.ReadKey(true);
    }
}