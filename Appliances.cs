namespace Labb_2
{
    internal class Appliances
    {
        public interface IKitchenAppliance
        {
            string Type { get; set; }
            string Brand { get; set; }
            public bool IsFunctioning { get; set; }
            void Use();
            Appliance createAppliance();
        }

        public abstract class baseAppliance : IKitchenAppliance
        {
            public string Type { get; set; }
            public string Brand { get; set; }
            public bool IsFunctioning { get; set; }
            public abstract void Use();
            public abstract Appliance createAppliance();
        }


        public class Appliance : baseAppliance
        {
            public Appliance(string type, string brand, bool functioning)
            {
                this.Type = type;
                this.Brand = brand;
                this.IsFunctioning = functioning;
            }

            public override void Use() //Kollar om apparaten är trasig eller inte och skriver ut ett meddelande beroende på resultatet.
            {
                if (IsFunctioning)
                {
                    Console.WriteLine($"Använder {Type}({Brand}).");
                }
                else
                {
                    Console.WriteLine($"{Type}({Brand}) är trasig och kan inte användas.");
                }
            }

            public override Appliance createAppliance() //Låter användaren skapa en ny köksapparat
            {
                string märke;
                string typ;
                bool fungerar = true;
                bool loop = true;

                Console.WriteLine("Märke:");
                märke = Console.ReadLine();
                Console.WriteLine("Typ:");
                typ = Console.ReadLine();
                Console.WriteLine("Fungerar den?(j = Ja, n = Nej)");

                while (loop)                            // Sätter isFunctionng till true eller false om man skriver in j eller n.
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "j")
                    {
                        fungerar = true;
                        loop = false;
                    }
                    else if (input.ToLower() == "n")
                    {
                        fungerar = false;
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Bara j och n godtas.");
                    }
                }

                Appliance nyAppliance = new Appliance(märke, typ, fungerar);
                return nyAppliance;
            }

        }
    }
}

