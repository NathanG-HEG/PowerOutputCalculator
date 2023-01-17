namespace PowerOutputCalculator
{
    public abstract class ConsumptionCalculator
    {
        // Parameters
        static int HorsePower = 28;
        static int EngineEfficiencyPercent = 33;
        static string TypeOfFuel = "95";

        static void EditParameters()
        {
            bool exit = false;
            Console.WriteLine("EDIT PARAMETERS MENU");
            do
            {
                Console.WriteLine("\t1. Edit Horse power (current: " + HorsePower + "hp)");
                Console.WriteLine("\t2. Edit Engine efficiency (current: " + EngineEfficiencyPercent + "%)");
                Console.WriteLine("\t3. Edit Type of fuel (current: " + TypeOfFuel + ')');
                Console.WriteLine("\t4. Previous menu");
                string? ans = Console.ReadLine();
                if (ans == null) throw new IOException();
                try
                {
                    int choice = Int32.Parse(ans);
                    switch (choice)
                    {
                        case 1:
                            SetHorsePower();
                            break;
                        case 2:
                            SetEngineEfficency();
                            break;
                        case 3:
                            SetTypeOfFuel();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            throw new IOException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine('\t' + ans + " is not a correct parameter");
                }
            } while (!exit);
        }

        static void SetTypeOfFuel()
        {
            Console.WriteLine("SET TYPE OF FUEL - CURRENT: " + TypeOfFuel);
            Console.WriteLine("\t Enter the type of fuel (only 95, 98, diesel and ethanol are supported).");
            string? ans = Console.ReadLine();
            if (ans != null) TypeOfFuel = ans;
        }

        static void SetEngineEfficency()
        {
            Console.WriteLine("SET ENGINE EFFICENCY - CURRENT: " + EngineEfficiencyPercent + '%');
            Console.WriteLine("\t Enter the engine efficiency percent.");
            string? ans = Console.ReadLine();
            try
            {
                if (ans == null) throw new IOException();
                int value = Int32.Parse(ans);
                if (value < 0) throw new IOException();
                EngineEfficiencyPercent = value;
            }
            catch (Exception)
            {
                Console.WriteLine("\t Incorrect parameter. Could not set engine efficency.");
            }
        }

        static void SetHorsePower()
        {
            Console.WriteLine("SET HORSE POWER - CURRENT: " + HorsePower + "hp");
            Console.WriteLine("\t Enter the fuel consumption");
            string? ans = Console.ReadLine();
            try
            {
                if (ans == null) throw new IOException();
                int value = Convert.ToInt32(ans);
                if (value < 0) throw new IOException();
                HorsePower = value;
            }
            catch (Exception)
            {
                Console.WriteLine("\t Incorrect parameter. Could not set horse power.");
            }
        }


        static void CalculateConsumption()
        {
            float wattToHorsepowerRatio = 1.3404825737f;
            int whPerLiter;
            int co2Grams;
            //source https://chemistry.beloit.edu/edetc/SlideShow/slides/energy/density.html
            switch (TypeOfFuel)
            {
                case "95":
                    co2Grams = 2300;
                    whPerLiter = 9700;
                    break;
                case "98":
                    co2Grams = 2300;
                    whPerLiter = 9800;
                    break;
                case "diesel":
                    co2Grams = 2700;
                    whPerLiter = 10700;
                    break;
                case "ethanol":
                    co2Grams = 2270;
                    whPerLiter = 6100;
                    break;
                default:
                    Console.WriteLine("\tUnknown fuel, efficiency of Unleaded 95 chosen");
                    co2Grams = 9700;
                    whPerLiter = 9700;
                    break;
            }

            float kiloWatt = HorsePower / wattToHorsepowerRatio;
            float consumption = (kiloWatt * 100 * 1000) / (whPerLiter * EngineEfficiencyPercent);
            co2Grams = (co2Grams * (int)consumption) / 100;
            Console.WriteLine("\tThe engine is consuming " + consumption + "l/100km and emit " + co2Grams +
                              " grams of co2 per km.");
        }

        public static void CalculateConsumptionMenu()
        {
            Console.WriteLine("CALCULATE POWER OUTPUT MENU");
            bool exit;
            do
            {
                exit = false;
                Console.WriteLine("\t1. Show/Edit current parameters");
                Console.WriteLine("\t2. Show current consumption");
                Console.WriteLine("\t3. Back to main menu");
                string? ans = Console.ReadLine();
                if (ans == null)
                {
                    throw new IOException();
                }

                try
                {
                    int choice = Int32.Parse(ans);
                    switch (choice)
                    {
                        case 1:
                            EditParameters();
                            break;
                        case 2:
                            CalculateConsumption();
                            break;
                        case 3:
                            exit = true;
                            break;
                        default:
                            throw new IOException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine('\t' + ans + " is not a correct parameter");
                }
            } while (!exit);

            Program.ShowMenu();
        }
    }
}