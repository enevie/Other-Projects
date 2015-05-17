namespace NacataProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(@"
Enter the operation you will proceed:
1 for Start program with random numbers from 1-10000
2 for Enter your own collection of numbers");

            int parsedLogic;

            CheckingValidStartInput(out parsedLogic);

            if (parsedLogic == 1)
            {
                SampleFromOneToTenThousand();
            }
            else if (parsedLogic == 2)
            {
                SampleFromInput();
            }
        }


        private static void SampleFromOneToTenThousand()
        {
            Console.WriteLine("Count of numbers: ");
            int numbersToChose = int.Parse(Console.ReadLine());

            Console.WriteLine("How many samples: ");
            int samples = int.Parse(Console.ReadLine());

            var samplesSelected = new List<List<double>>();
            Random random = new Random();

            for (int i = 0; i < samples; i++)
            {
                var selectedNumbers = new List<double>();

                for (int j = 0; j < numbersToChose; j++)
                {
                    int randomNumberToChose = random.Next(1, 10000);
                    selectedNumbers.Add(randomNumberToChose);
                }
                samplesSelected.Add(selectedNumbers);
            }
            PrintCollections(samplesSelected);
        }

        private static void PrintCollections(List<List<double>> samplesSelected)
        {
            double avarage = 0;
            Console.WriteLine("Enter the name of the output document: ");

            string nameOfTheFileSave = Console.ReadLine();
            for (int i = 0; i < samplesSelected.Count; i++)
            {
                avarage = 0;
                Console.WriteLine("{0} collection", i + 1);
                Console.WriteLine(string.Join(", ", samplesSelected[i]));

                for (int j = 0; j < samplesSelected[i].Count; j++)
                {
                    avarage += samplesSelected[i][j] / samplesSelected[i].Count;
                }

                Console.WriteLine("The average is: {0:F4}", avarage);
                Console.WriteLine(new string('-', 200));

                using (StreamWriter writer = new StreamWriter(nameOfTheFileSave + ".xls", true))
                {
                    writer.WriteLine(avarage);
                }
            }
        }

        private static void SampleFromInput()
        {
            var inputNumbers = new List<double>();
            Console.WriteLine("Enter the numbers and type END to finish: ");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToUpper() == "END")
                {
                    break;
                }
                if (CheckingParsingPositiveNumber(input))
                {
                    inputNumbers.Add(double.Parse(input));
                }
                else
                {
                    Console.WriteLine("Incorrect value of number, skipping...");
                }
            }

            Console.WriteLine("Count of numbers (with replacement): ");
            int numbersToChose = int.Parse(Console.ReadLine());

            Console.WriteLine("How many samples: ");
            int samples = int.Parse(Console.ReadLine());

            var samplesSelected = new List<List<double>>();
            Random random = new Random();

            for (int i = 0; i < samples; i++)
            {
                var selectedNumbers = new List<double>();

                for (int j = 0; j < numbersToChose; j++)
                {
                    double randomNumberToChose = inputNumbers[random.Next(inputNumbers.Count)];
                    selectedNumbers.Add(randomNumberToChose);
                }
                samplesSelected.Add(selectedNumbers);
            }
            PrintCollections(samplesSelected);
        }

        private static bool CheckingParsingPositiveNumber(string number)
        {
            foreach (var digit in number)
            {
                if (digit < '0' || digit > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckingValidStartInput(out int result)
        {
            string programLogic;
            result = 0;
        m1:
            programLogic = Console.ReadLine();
            try
            {
                result = int.Parse(programLogic);
                if (result == 1 || result == 2)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please enter number 1 or 2, incorrect value");
                    goto m1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter number 1 or 2, incorrect value");
                goto m1;
            }
        }
    }
}
