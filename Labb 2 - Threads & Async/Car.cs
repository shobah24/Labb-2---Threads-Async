namespace Labb_2___Threads___Async
{
    public class Car
    {
        // i den här klassen hanteras allt om själva bilen och händelser som kan ske
        public string Name { get; set; }
        public double Distance { get; set; } = 0.0; // km
        public double MaxDistance { get; set; } = 5.0; // 5 km
        public double Speed { get; set; } = 120.0; // km/h
        public bool Finished { get; set; } = false;

        private static readonly Random _random = new Random();

        // skapas till för att hålla koll på om någon har vunnit racet
        private static bool _winner = false;
        private static object _lock = new object(); 

        public Car(string name)
        {
            Name = name;
        }
        public void Driving()
        {
            
            // används till att hålla koll på tiden 
            DateTime time = DateTime.Now;

            while (Distance < MaxDistance)
            {
                Distance += Speed / 36000.0; // Konvertera hastighet från km/h till km/s 0,0333km/s... 

                // Kolla om det har gått 10 sekunder
                if ((DateTime.Now - time).TotalSeconds >= 10)
                {
                    RandomEventHandler();
                    time = DateTime.Now; 
                }
                Thread.Sleep(100); // vänta 0,5 sekund innan nästa händelse kan ske
            }

            lock (_lock) // låser så att bara en bil kan komma åt koden 
            { 
                if (!Finished)
                {
                    Finished = true; // sätter Finished till true för att visa att en bil har gått i mål
                    if (!_winner)
                    {
                        _winner = true; // sätt vinnaren till true om det inte finns någon vinnare
                        Console.WriteLine($"\n{Name} har vunnit racet!");
                    }
                    else  
                    {
                        Console.WriteLine($"\n{Name} har gått i mål!");
                    }
                }
            }
        }
        // slumpmässiga händelser som ska ske var 10e sekund
        public void RandomEventHandler()
        {
            // sannolikhet 1-50
            int rndEvent = _random.Next(1, 51); 
            if(rndEvent == 1)
            {
                Console.WriteLine($"{Name} har slut på bensin, tankar i 15 sekunder...");
                Thread.Sleep(15000);
            }
            else if (rndEvent <= 3) // sannolikhet 2-3
            {
                Console.WriteLine($"{Name} har fått punktering, byter däck i 10 sekunder...");
                Thread.Sleep(10000);
            }
            else if (rndEvent <= 8) // sannolikhet 4-8
            {
                Console.WriteLine($"{Name} har fått en fågel på vindrutan, tvättar vindrutan i 5 sekunder...");
                Thread.Sleep(5000);
            }
            else if (rndEvent <= 18) // sannolikhet 9-18
            {
                //Speed -= 1; // hastighet - 1
                Speed = Math.Max(1, Speed - 1);
                Console.WriteLine($"{Name} har fått motorfel, hastigheten sänks till {Speed} Km/h!");
            }
        }
        // status på bilarna
        public void CheckStatus()
        {
            Console.WriteLine($"{Name}: {Distance:f2} km - {Speed} km/h");
        }
    }
}
