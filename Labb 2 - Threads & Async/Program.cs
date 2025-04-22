namespace Labb_2___Threads___Async
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Välkommen till Racet!");

            // kalla manageRace klassen
            ManageRace manageRace = new ManageRace();
            manageRace.StartRace();
        }
    }
}
