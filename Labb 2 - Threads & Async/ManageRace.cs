namespace Labb_2___Threads___Async
{
    public class ManageRace
    {
        // i den här klassen hanterar vi allt i själva tävlingen

        // metod som hanterar sälva racet och startar den
        public void StartRace()
        {
            List<Car> cars = new List<Car>();

            Console.WriteLine("Välkommen till Racet!");
            Console.WriteLine("\nRacet har startat.");
            // Skapa bilar
            Car car1 = new Car("Aston Martin Valkyrie");
            Car car2 = new Car("Koenigsegg Jesko");
            Car car3 = new Car("Hispano-Suiza");

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);

            // skapa en lista för att hålla trådarna
            List<Thread> threads = new List<Thread>();

            foreach (Car car in cars)
            {
                Thread thread = new Thread(car.Driving);
                threads.Add(thread);
                thread.Start();
            }
            // En till tråd för att hantera statusuppdateringar
            Thread statusThread = new Thread(() =>
            {
                Console.WriteLine("\nTryck på (enter) eller skriv (status) för att få en statusuppdatering.\n");
                while (cars.Any(c => !c.Finished))
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "" || userInput.ToLower() == "status")
                    {
                        Console.WriteLine("--------Status just nu--------");
                        foreach (Car car in cars)
                        {
                            //Console.WriteLine($"{car.Name} har kört {car.Distance} km med en hastighet av {car.Speed} km/h.");
                            car.CheckStatus();
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Kunde inte få fram status, försök igen!");
                    }
                }
            });
            statusThread.IsBackground = true; // Gör status-tråden till en bakgrundstråd så att den inte blockerar programmet
            statusThread.Start();

            // Vänta på att alla trådar ska avslutas
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("\nTävlingen är nu avslutad!");
            Console.WriteLine("Tryck på valfri tangent för att stänga programmet.....");
            Console.ReadKey();



        }
    }
}
