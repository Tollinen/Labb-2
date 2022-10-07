using static Labb_2.Appliances;

bool menyLoop = true;
List<IKitchenAppliance> applianceList = new List<IKitchenAppliance>() { new Appliance("Ugn", "Electrolux", true), new Appliance("Mikrovågsugn", "Fimbaldvi", false) };

while (menyLoop)
{
    Console.Clear();
    Console.WriteLine(
        "[1] Använd köksapparat\n" +
        "[2] Lägg till köksapparat\n" +
        "[3] Lista köksapparater\n" +
        "[4] Ta bort köksapparat\n" +
        "[5] Avsluta");


    switch (MenyVal(5))
    {
        case 1:         //Använd köksapparat
            Console.Clear();
            if (applianceList.Count <= 0)       // Körs om Köksapparatlistan är tom
            {
                Console.WriteLine("Det finns inga köksapparater. Lägg till några.\n" +
                                  "[Enter] för att gå tillbaka till menyn.");
                Console.ReadLine();
            }
            else   //Körs om det finns någonting i Köksapparatlistan
            {
                Console.WriteLine("##### Använd köksapparat #####");
                for (int i = 0; i < applianceList.Count; i++)            //Skriver ut alla köksapparater
                {
                    Console.WriteLine($"[{(i + 1)}] {applianceList[i].Type}, {applianceList[i].Brand}");
                }
                applianceList[(MenyVal((applianceList.Count())) - 1)].Use();
                Console.WriteLine("[Enter] för att gå tillbaka till menyn.");
                Console.ReadLine();
            }
            break;

        case 2:         // Lägg till köksapparat
            Console.Clear();
            Console.WriteLine("##### Lägg till köksapparat #####");
            applianceList.Add(new Appliance("", "", true).createAppliance()); // Skapar en ny köksapparat som läggs till i listan
            Console.WriteLine("Apparaten har lagts till!");
            Console.WriteLine("[Enter] för att gå tillbaka till menyn.");
            Console.ReadLine();

            break;

        case 3:         // Lista köksapparater
            Console.Clear();
            Console.WriteLine("-------------------");
            foreach (var item in applianceList)
            {
                Console.WriteLine($"Typ: {item.Type}\n" +
                    $"Märke: {item.Brand}\n" +
                    $"Skick: {item.IsFunctioning}");
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("[Enter] för att gå tillbaka till menyn.");
            Console.ReadLine();
            break;

        case 4:         // Ta bort köksapparat
            Console.Clear();
            if (applianceList.Count <= 0)       // Körs om Köksapparatlistan är tom
            {
                Console.WriteLine("Det finns inga köksapparater. Lägg till några.\n" +
                                  "[Enter] för att gå tillbaka till menyn.");
                Console.ReadLine();
            }
            else   //Körs om det finns någonting i Köksapparatlistan
            {
                Console.WriteLine("##### Ta bort köksapparat #####");
                for (int i = 0; i < applianceList.Count; i++)            //Skriver ut alla köksapparater
                {
                    Console.WriteLine($"[{(i + 1)}] {applianceList[i].Type}, {applianceList[i].Brand}");
                }
                applianceList.RemoveAt((MenyVal((applianceList.Count())) - 1)); // Tar bort köksapparaten
                Console.WriteLine("Köksapparaten har tagits bort.");
                Console.WriteLine("[Enter] för att gå tillbaka till menyn.");
                Console.ReadLine();
            }
            break;

        case 5:         // Avsluta
            menyLoop = false;
            break;

        default:
            break;
    }

}





//##### Metoder #####
int MenyVal(int valMängd) //Används för menyval. valmängd används för att skriva ut max värdet som godtas.
{
    bool valLoop = false;
    var menyval = 0;
    do
    {
        try
        {
            
            menyval = Convert.ToInt32(Console.ReadLine());
            if (menyval < 1 || menyval > valMängd)
            {
                Console.WriteLine($"Bara nummer mellan 1-{valMängd} godtas");
                valLoop = true;
            }
            else
            {
                valLoop = false;
            }
        }
        catch
        {
            Console.WriteLine($"Bara nummer mellan 1-{valMängd} godtas");
            valLoop = true;
        }
    }
    while (valLoop);

    return menyval;
}