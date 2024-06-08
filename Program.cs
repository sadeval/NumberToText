using System;

namespace NumberToText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int value = Convert.ToInt32(Console.ReadLine());

            string[, ] arOfDigits = {
                { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" },
                { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" },
                { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" }
            };

            string[] arFrom10to19 = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };

            string result = NumberToWords(value, arOfDigits, arFrom10to19);

            Console.WriteLine($"Вы ввели: {result}");
        }

        static string NumberToWords(int value, string[,] arOfDigits, string[] arFrom10to19)
        {
            if (value == 0)
                return "ноль";

            if (value < 0)
                return "минус " + NumberToWords(Math.Abs(value), arOfDigits, arFrom10to19);

            string words = "";

            if ((value / 1000000) > 0)
            {
                words += NumberToWords(value / 1000000, arOfDigits, arFrom10to19) + " миллион ";
                value %= 1000000;
            }

            if ((value / 1000) > 0)
            {
                words += NumberToWords(value / 1000, arOfDigits, arFrom10to19) + " тысяч ";
                value %= 1000;
            }

            if ((value / 100) > 0)
            {
                words += arOfDigits[2, (value / 100) - 1] + " ";
                value %= 100;
            }

            if (value > 0)
            {
                if (words != "")
                    words += "";

                if (value < 10)
                    words += arOfDigits[0, value - 1];
                else if (value < 20)
                    words += arFrom10to19[value - 10];
                else
                {
                    words += arOfDigits[1, (value / 10) - 1];
                    if ((value % 10) > 0)
                        words += " " + arOfDigits[0, (value % 10) - 1];
                }
            }

            return words.Trim();
        }
    }
}
