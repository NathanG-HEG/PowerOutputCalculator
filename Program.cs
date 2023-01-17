namespace PowerOutputCalculator
{
    class Program
    {
        static void Exit()
        {
            Environment.Exit(0);
        }

        public static void ShowMenu()
        {
            Console.WriteLine("MAIN MENU");
            bool incorrect;
            do{
                incorrect = false;
                Console.WriteLine("\t1. Calculate Power output");
                Console.WriteLine("\t2. Calculate Fuel consumption");
                Console.WriteLine("\t3. Exit program");
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
                            PowerCalculator.CalculatePowerMenu();
                            break;
                        case 2:
                            ConsumptionCalculator.CalculateConsumptionMenu();
                            break;
                        case 3: Exit();
                            break;
                        default:
                            throw new IOException();
                    }

                }catch(Exception)
                {
                    Console.WriteLine('\t'+ans + " is not a correct parameter");
                    incorrect = true;
                }
            }while(incorrect);
        }

        static void Main(string[] args)
        {
            ShowMenu();
        }
    }
}


