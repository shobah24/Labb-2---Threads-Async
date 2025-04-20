﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace Labb_2___Threads___Async
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Välkommen till Racet!");

            // kalla på car klassen och manageRace klassen
            ManageRace manageRace = new ManageRace();
            manageRace.StartRace();







            //I denna labb ska du bygga ett program som simulerar en biltävling där två
            //(eller fler) bilar tävlar mot varandra. Programmet körs i konsolen utan grafik,
            //och varje bil körs i en egen tråd så att de tävlar mot varandra i realtid.

            //🚘 **Bilarna * *
            //-Varje bil ska vara ett objekt
            // - Varje bil ska ha ett namn
            //- Det ska finnas minst två bilar i tävlingen

            //🏁 **Tävlingen * *
            //-Bilarna ska tävla på en 5 km lång sträcka
            //- Alla bilar ska starta på samma ställe
            //-Alla bilar kör i 120km / h vid start
            //-Bilarna når maxhastighet direkt utan acceleration
            //- Varje bilobjekt ska köras i en egen tråd

            //⚠️ **Problem på vägen**

            //Det ska finnas några slumpmässiga händelser som kan inträffa för en bil

            //Nedan listas möjliga händelser med sannolikhet och effekt.Du får gärna lägga till egna händelser

            //| Händelse | Sannolikhet | Effekt |
            //| --- | --- | --- |
            //| Slut på bensin | 1 / 50 | Behöver tanka, stannar 15 sekunder |
            //| Punktering | 2 / 50 | Behöver byta däck, stannar 10 sekunder |
            //| Fågel på vindrutan | 5 / 50 | Behöver tvätta vindrutan, stannar 5 sekunder |
            //| Motorfel | 10 / 50 | Hastigheten på bilen sänks med 1 km / h |
            //För varje bil ska det var 10:e sekund slumpas fram en händelse. Endast en händelse kan inträffa åt gången.


            //🏎️ **Kör tävlingen! * *
            //- []  Alla bilar ska starta samtidigt.
            //- []  Skriv ut i konsolen när bilarna startar.
            //- []  Skriv ut i konsolen när en bil stöter på problem. Ange både bilens namn och vad som hänt.
            //- []  Skriv ut när en bil når mållinjen.För den första bilen som kommer i mål ska det framgå att den vann tävlingen.
            //- []  Ge användaren möjlighet att när som helst få en statusuppdatering genom att trycka på enter eller skriva "status".
            //Statusen ska visa hur långt varje bil har kommit samt deras aktuella hastighet.




        }
    }
}
