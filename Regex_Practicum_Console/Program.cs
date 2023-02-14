using System;
using System.Text.RegularExpressions;

namespace Regex_Practicum
{
    /*
           ///////////////////////////////Квантифікатори вказують на вказання кількості/////////////////////////////////////////

           ^: відповідність повинна починатися на початку рядка (наприклад, вираз @"^пр\w*" відповідає слову "привіт" у рядку "привіт світ")

           $: кінець рядка(наприклад, вираз @"\w*іт$" відповідає слову "світ" у рядку "привіт світ", тому що частина "іт" знаходиться в самому кінці)

           *: попередній символ повторюється 0 і більше разів

           +: попередній символ повторюється 1 і більше разів

           ?: попередній символ повторюється 0 або 1 раз

           |: варіанти АБО

           ///////////////////////////////Мета символи (вказують на заміну якого небудь символу)///////////////////////////////

           \s: відповідає будь-якому символу пробілу (табуляції, пепреносу)

           \S: відповідає будь-якому символу, що не є пробілом

           \w: відповідає будь-якому алфавітно-цифровому символу

           \W: відповідає будь-якому не алфавітно-цифровому символу

           \d: відповідає будь-якій цифрі

           \D: відповідає будь-якому символу, що не є цифрою

           .: знак точки визначає будь-який одиночний символ (наприклад, вираз "м.р" відповідає слову "мир" чи "мор")

           \. це символ точки

           Сам по собі \ це екран який відмежовує символ від комамнди для парсера

            */
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("\t\t\tRevert Month And Day:");
            RevertMonthAndDay();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\tImplement int namber To String:");
            ImplementToString();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\tReturned Words Who Started In \"m\":");
            ReturnedWordsWhoStartedInM();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t\t\tMobail Phone Variant 1:");
            MobailPhoneVariant1();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t\tMobail Phone Variant 2:");
            MobailPhoneVariant2();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\t\tMobail Phone Variant 3:");
            MobailPhoneVariant3("067-456-7890");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\tConvert To Phone Number only number:");
            ConvertToPhoneNumber();
            Console.ResetColor();

            for (int i = 0; i < typeof(PhoneNumberType).GetEnumValues().Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\tFinal Phone Number Convertion:");
                FinalPhoneNumberConvertion("+38(098)-32-23-984", (PhoneNumberType)i);
                Console.ResetColor();
            }
            

            Console.ReadKey();
        }

        private static void RevertMonthAndDay(string input = "02/05/1997")
        {
            string patern = @"(?<mounth>\d{1,2})\/(?<day>\d{1,2})\/(?<year>\d{1,2})";
            string use = "${day}-${mounth}-${year}";

            var result = Regex.Replace(input!, patern, use);

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void ImplementToString(string input = "123")
        {
            string patern = @"\d";

            var result = Regex.Replace(input!, patern, set =>
            (int.Parse(set.Value) + 1).ToString());

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void ReturnedWordsWhoStartedInM(string input = "Sometimes i like working at my mobile phone")
        {
            string pattern = @"\b[m]\w+";
            var reg = new Regex(pattern);

            var result = reg.Matches(input);

            Console.WriteLine($"input= {input}");

            Console.WriteLine("foreach");
            foreach (var item in result)
            {
                Console.Write($"\t{item}");
            }

            Console.WriteLine("\nfor");
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write($"\t{result[i].Value}");
            }
        }

        private static void MobailPhoneVariant1(string input = "123-456-7890")
        {
            string pattern = @"\d{3}-\d{3}-\d{4}";
            var reg = new Regex(pattern);

            var result = reg.IsMatch(input);

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void MobailPhoneVariant2(string input = "123-456-7890")
        {
            string pattern = "[0-9]{3}-[0-9]{3}-[0-9]{4}";
            var reg = new Regex(pattern);

            var result = reg.IsMatch(input);

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void MobailPhoneVariant3(string input = "098-456-7890")
        {
            string pattern = @"(098|067|065)-[0-9]{3}-\d{4}";
            var reg = new Regex(pattern);

            var result = reg.IsMatch(input);

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void ConvertToPhoneNumber(string input = "+1(876)-234-12-98")
        {
            string pattern = @"\D";
            string target = ""; 
            var reg = new Regex(pattern);

            var result = reg.Replace(input, target);

            Console.WriteLine($"input= {input}\t\t result = {result}");
        }

        private static void FinalPhoneNumberConvertion(string input = "+38(098)-32-23-984", PhoneNumberType phoneNumberType = PhoneNumberType.Unknown)
        {
            string pattern1 = @"\D";
            string target1 = "";
            var reg1 = new Regex(pattern1);

            var resultCleaning = reg1.Replace(input, target1);

            string result = null!;
            
            switch (phoneNumberType)
            {
                case PhoneNumberType.Unknown:
                    result = input;
                    break;
                case PhoneNumberType.NoCountryCode:
                    string pattern2 = @"^[3]";
                    var reg2 = new Regex(pattern2);

                    var isTrue = reg2.IsMatch(resultCleaning);
                    if (isTrue)
                    {
                        string pattern3 = @"^\d{2}";
                        string target3 = "";
                        var reg3 = new Regex(pattern3);

                        result = reg3.Replace(resultCleaning, target3);
                    }

                    else
                    {
                        result = resultCleaning;
                    }
                    break;
                case PhoneNumberType.NoCharacters:
                    result = resultCleaning;
                    break;
                default:
                    result = input;
                    break;
            }

            Console.WriteLine($"input= {input}\t\t type= {phoneNumberType} \t\t result = {result}");
        }
    }
}
