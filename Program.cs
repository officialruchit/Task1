using System;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("|===============================================|");
            Console.WriteLine("  printer status check");
            Console.WriteLine("|===============================================|");
            int paperCount = GetValidateCount();
            PrintStatus printMessage = CheckStatusForPrinter(paperCount);
            Console.WriteLine(GetStatusMessage(printMessage));
        }

        public static int GetValidateCount()
        {
            while (true)
            {
                Console.Write($"{Environment.NewLine}  Enter the Paper Count[Range: 0 to 2147483647]: ");
                string count = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(count))
                {
                    Console.WriteLine($"{Environment.NewLine}  Priner Status:[Error]Entered Paper count is invalid.");
                    continue;
                }
                if (!int.TryParse(count, out int PaperCount))
                {
                    Console.WriteLine($"{Environment.NewLine}  Priner Status:[Error]Entered Paper count is invalid.");
                    continue;
                }
                if (!CheckRangeForCount(PaperCount))
                {
                    Console.WriteLine($"{Environment.NewLine}  Priner Status:[Error]Entered Paper count is invalid.");
                    continue;
                }
                return PaperCount;
            }
        }

        public static bool CheckRangeForCount(int paperCount)
        {
            if (paperCount < 0 || paperCount > 2147483647)
            {
                return false;
            }
            return true;
        }

        public static PrintStatus CheckStatusForPrinter(int paperCount)
        {
            if (paperCount == 0)
            {
                return PrintStatus.NotReady;
            }
            if (paperCount > 0 && paperCount < 10)
            {
                return PrintStatus.PaperLow;
            }
            if (paperCount > 10)
            {
                return PrintStatus.PrinterReady;
            }
            else
            {
                return PrintStatus.Error;
            }
        }

        public static string GetStatusMessage(PrintStatus status)
        {
            switch (status)
            {
                case PrintStatus.NotReady:
                    return $"{Environment.NewLine}  \"not ready\"";
                case PrintStatus.PrinterReady:
                    return ($"{Environment.NewLine}  \"printer is ready\"");
                case PrintStatus.PaperLow:
                    return ($"{Environment.NewLine}  \"paper is low\"");
                case PrintStatus.Error:
                    return ($"{Environment.NewLine}  \"Printer Status: [Error] Entered Paper count is invalid.\"");
                default:
                    return ($"{Environment.NewLine}  \"Printer Status: [Error] Entered Paper count is invalid.\"");
            }
        }
    }
}
