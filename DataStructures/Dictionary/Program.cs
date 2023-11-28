namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Print();

            dic.Set("Sinar", "sinar@gmail.com");
            dic.Set("Elvis", "elvis@gmail.com");
            dic.Print();

            dic.Set("Tane", "tane@gmail.com");
            dic.Set("Gerti", "gerti@gmail.com");
            dic.Set("Arist", "arist@gmail.com");

            // dic.Set("rArist", "rarist@gmail.com");
            // dic.Set("tArist", "tarist@gmail.com");
            // dic.Set("yArist", "yarist@gmail.com");

            dic.Print();

            Console.WriteLine(dic.Get("Tane"));
            Console.WriteLine(dic.Get("Sinar"));
            Console.WriteLine(dic.Get("Elviaaa"));

            dic.Remove("Sinar");
            dic.Remove("Elvis");
            dic.Remove("Tane");
            dic.Remove("Gerti");
            dic.Remove("Arist");
            dic.Print();
            dic.Set("Sinar", "sinar@gmail.com");
            dic.Print();
        }
    }
}