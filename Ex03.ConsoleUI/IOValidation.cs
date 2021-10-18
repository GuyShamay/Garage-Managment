using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class IOValidation
    {
        public static bool RangeCheck(int i_Input, int i_Start, int i_End)
        {
            return (i_Input >= i_Start) && (i_Input <= i_End);
        }

        public static bool ParseStrToInt(string i_Str, ref int io_ConvertedInt)
        {
            bool parseSuccess = int.TryParse(i_Str, out io_ConvertedInt);

            if (!parseSuccess)
            {
                throw new FormatException("Converting string to number failed");
            }

            return parseSuccess;
        }

        public static bool StringConvertionWithRange(string i_Str, ref int io_ConvertedInt, int i_Start, int i_End)
        {
            bool validInput = false;

            if (ParseStrToInt(i_Str, ref io_ConvertedInt))
            {
                validInput = RangeCheck(io_ConvertedInt, i_Start, i_End);
            }
            
            if (!validInput)
            {
                throw new ValueOutOfRangeException(i_Start, i_End);
            }

            return validInput;
        }

        private static void isDigitAndLetters(string i_Str)
        {
            foreach (var note in i_Str)
            {
                if (!char.IsDigit(note) && !char.IsLetter(note))
                {
                    throw new ArgumentException("Unvalid Input");
                }
            }
        }

        public static bool ValidLicensePlate(string i_LicensePlate)
        {
            bool validInput = true;

            if (i_LicensePlate.Length != 8)
            {
                throw new ArgumentException("The License Number is not in the right length");
            }
            else
            {
                isDigitAndLetters(i_LicensePlate);
            }

            return validInput;
        }

        public static bool ValidName(string i_Name)
        {
            bool validInput = true;

            foreach (var note in i_Name)
            {
                isDigitAndLetters(i_Name);
            }

            return validInput;
        }

        public static bool ValidNumber(string i_Num)
        {
            bool validInput = true;

            foreach (var note in i_Num)
            {
                if (!char.IsNumber(note))
                {
                    throw new ArgumentException("The Number is not valid");
                }
            }

            return validInput;
        }

        public static bool StringToFloat(string i_InputStr, out float io_Power)
        {
            bool validInput = float.TryParse(i_InputStr, out io_Power);
            if (!validInput)
            {
                throw new FormatException("Invalid number of minutes, please try again");
            }

            if (io_Power < 0)
            {
                validInput = false;
            }

            return validInput;
        }
    }
}
