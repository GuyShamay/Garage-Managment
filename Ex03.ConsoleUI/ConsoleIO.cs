using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleIO
    {
        public static void PrintStr(string i_StrToPrint)
        {
            Console.WriteLine(i_StrToPrint);
        }

        public static void Clear()
        {
            Console.Clear();
        }
        
        public static void Pause()
        {
            Console.Write("Press 'Enter' to go back to Garage Menu ");
            Console.ReadLine();
            Console.Clear();
        }

        public static int GetChoiceWithRange(int i_start, int i_end)
        {
            bool validInput = false;
            string inputStr;
            int choice = 0;

            while (!validInput)
            {
                ConsoleIO.PrintStr("Select your choice:");
                inputStr = Console.ReadLine();
                try
                {
                    validInput = IOValidation.StringConvertionWithRange(inputStr, ref choice, i_start, i_end);
                }
                catch (ValueOutOfRangeException vorex)
                {
                    Console.WriteLine(vorex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            return choice;
        }

        public static bool GetBooleanChoice()
        { 
            int answerAsInt = GetChoiceWithRange(0, 1);
            const bool v_answer = true;

            return (answerAsInt == 1 ? v_answer : !v_answer);
        }
        
        public static string GetLicensePlate()
        {
            string licensePlate = null;
            bool validInput = false;

            while (!validInput)
            {
                licensePlate = Console.ReadLine();
                try
                {
                    validInput = IOValidation.ValidLicensePlate(licensePlate);
                }
                catch (ArgumentException aex)
                {
                    ConsoleIO.PrintStr(aex.Message);
                }
            }

            return licensePlate;
        }

        public static int ChooseEnum(Type i_EType)
        {
            int choice, enumCount;

            enumCount = showEnumNames(i_EType);
            choice = GetChoiceWithRange(1, enumCount);

            return choice;
        }

        private static int showEnumNames(Type i_EType)
        {
            int numOfObjects = 1;

            foreach (string myEnum in Enum.GetNames(i_EType))
            {
                Console.WriteLine(string.Format("{0}. {1}", numOfObjects++, myEnum));
            }

            return numOfObjects - 1;
        }

        public static string GetName()
        {
            string name = null;
            bool validInput = false;

            while (!validInput)
            {
                name = Console.ReadLine();
                try
                {
                    validInput = IOValidation.ValidName(name);
                }
                catch (ArgumentException aex)
                {
                    ConsoleIO.PrintStr(aex.Message);
                }
            }

            return name;
        }

        public static string GetNumberAsString()
        {
            string number = null;
            bool validInput = false;

            while (!validInput)
            {
                number = Console.ReadLine();
                try
                {
                    validInput = IOValidation.ValidNumber(number);
                }
                catch (ArgumentException aex)
                {
                    ConsoleIO.PrintStr(aex.Message);
                }
            }

            return number;
        }

        public static int StringToInt()
        {
            int number = 0;
            bool validInput = false;
            string numStr = GetNumberAsString();

            while (!validInput)
            {
                try
                {
                    validInput = IOValidation.ParseStrToInt(numStr, ref number);
                }
                catch (FormatException fex)
                {
                    ConsoleIO.PrintStr(fex.Message);
                }
            }

            return number;
        }

        public static float GetFloat() 
        {
            float energy = 0;
            bool validInput = false;

            while (!validInput)
            {
                string inputStr = Console.ReadLine();
                try
                {
                    validInput = IOValidation.StringToFloat(inputStr, out energy);
                }
                catch (FormatException fex)
                {
                    ConsoleIO.PrintStr(fex.Message);
                }
            }

            return energy;
        }
      
        public static float MinutesToHours(float i_minutes)
        {
            return i_minutes / 60;
        }
    }
}
