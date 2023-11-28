namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FNV-1a
            Hash hash = new Hash();
            hash.Hash32("This is Original Text");
            hash.Hash64("This is Original Text");
        }
    }
}