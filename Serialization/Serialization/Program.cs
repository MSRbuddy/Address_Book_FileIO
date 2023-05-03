namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Serialization and Deserialization!*****");
            Console.WriteLine("-------------------------------------------------\n");

            SerializeDeserialize sd = new SerializeDeserialize();
            sd.Serialization(); 
            sd.Deserialization();
        }
    }
}