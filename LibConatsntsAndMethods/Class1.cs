using System;
using static System.Console;
using System.Linq;

namespace LibConatsntsAndMethods
{
    public class Class1
    {
        /*public static decimal[] purchaseCost = { 0, 0, 0, 0, 0, 0 };
        public static decimal[] purchaseCostWithProviding = { 0, 0, 0, 0, 0, 0 };*/
        public static int[,] costForStations = {{ 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }
        };
        public static int[,] deliveryCostStations = { { 803, 952, 997, 931 },
            { 967, 1012, 848, 1200 },
            { 825, 945, 777, 848 },
            { 1024, 1800, 931, 999 },
            { 754, 817, 531, 628 },
            { 911, 668, 865, 1526 }
        }; // для вывода ответа в таблицу

        static readonly int[] max = { 600, 420, 360, 250, 700, 390 };
        const int sumMaxes = 2720;

        public static readonly decimal[] costFor1_1 = { 5.2m, 4.5m, 6.1m, 3.8m, 6.4m, 5.6m } ;
        public static readonly int[] costOfDelivery_1 = { 803, 952, 997, 931 };
        public static readonly int[] costOfDelivery_2 = { 967, 1012, 848, 1200 };
        public static readonly int[] costOfDelivery_3 = { 825, 945, 777, 848 };
        public static readonly int[] costOfDelivery_4 = { 1024, 1800, 931, 999 };
        public static readonly int[] costOfDelivery_5 = { 754, 817, 531, 628 };
        public static readonly int[] costOfDelivery_6 = { 911, 668, 865, 1526 }; // константы

        public static int[] providerRemainds = { max[0], max[1], max[2], max[3], max[4], max[5] };
        public static int[] valueRemainds = { 0, 0, 0, 0 };

        public static decimal[] costForFindMin = { 0, 0, 0, 0, 0, 0 };
        public static int[] costForFindMin_1 = { 0, 0, 0, 0 };
        public static int[] costForFindMin_2 = { 0, 0, 0, 0 };
        public static int[] costForFindMin_3 = { 0, 0, 0, 0 };
        public static int[] costForFindMin_4 = { 0, 0, 0, 0 };
        public static int[] costForFindMin_5 = { 0, 0, 0, 0 };
        public static int[] costForFindMin_6 = { 0, 0, 0, 0 };

        public static int currProviderIndex = Array.IndexOf(costFor1_1, costFor1_1.Min());
        public static int currStationIndex = 2; // для подсчётов

        public static void Algorythm()
        {
            Array.Copy(costFor1_1, 0, costForFindMin, 0, 6);
            Array.Copy(costOfDelivery_1, 0, costForFindMin_1, 0, 4);
            Array.Copy(costOfDelivery_2, 0, costForFindMin_2, 0, 4);
            Array.Copy(costOfDelivery_3, 0, costForFindMin_3, 0, 4);
            Array.Copy(costOfDelivery_4, 0, costForFindMin_4, 0, 4);
            Array.Copy(costOfDelivery_5, 0, costForFindMin_5, 0, 4);
            Array.Copy(costOfDelivery_6, 0, costForFindMin_6, 0, 4);

            valueRemainds[0] = ReadValue_A();
            valueRemainds[1] = ReadValue_Б();
            valueRemainds[2] = ReadValue_В();
            valueRemainds[3] = ReadValue_Г();


            while(SumValueRemainds(valueRemainds) > 0)
            {
                Count(valueRemainds[currStationIndex]);
            }

            PrintAnswer(costForStations);
        }

        static int Count(int value)
        {
            int index = currProviderIndex;
            if (value - providerRemainds[currProviderIndex] > 0)
            {
                valueRemainds[currStationIndex] -= providerRemainds[currProviderIndex];
                costForStations[currStationIndex, currProviderIndex] = providerRemainds[currProviderIndex];
                providerRemainds[currProviderIndex] = 0;
                MakeDecimalMaxForCountMin(currProviderIndex);
                currProviderIndex = FindProviderIndex(currProviderIndex);
                currStationIndex = FindStationIndex(currProviderIndex);
            }
            else
            {
                valueRemainds[currStationIndex] = 0;
                providerRemainds[currProviderIndex] -= value;
                costForStations[currStationIndex, currProviderIndex] = value;
                MakeDecimalMaxForCountMin(currProviderIndex);
                currStationIndex = FindStationIndex(currProviderIndex);
            }
            return providerRemainds[index];
        }

        static int FindProviderIndex(int index)
        {
            costForFindMin[currProviderIndex] = decimal.MaxValue;
            index = Array.IndexOf(costForFindMin, costForFindMin.Min());
            return index;
        }

        static void MakeDecimalMaxForCountMin(int index)
        {
            switch (index)
            {
                case 0:
                    costForFindMin_1[currStationIndex] = int.MaxValue;
                    break;
                case 1:
                    costForFindMin_2[currStationIndex] = int.MaxValue;
                    break;
                case 2:
                    costForFindMin_3[currStationIndex] = int.MaxValue;
                    break;
                case 3:
                    costForFindMin_4[currStationIndex] = int.MaxValue;
                    break;
                case 4:
                    costForFindMin_5[currStationIndex] = int.MaxValue;
                    break;
                default:
                    costForFindMin_6[currStationIndex] = int.MaxValue;
                    break;
            }
        }

        static int FindStationIndex(int index)
        {
            switch (index)
            {
                case 0:
                    currStationIndex = Array.IndexOf(costForFindMin_1, costForFindMin_1.Min());
                    break;
                case 1:               
                    currStationIndex = Array.IndexOf(costForFindMin_2, costForFindMin_2.Min());
                    break;
                case 2:
                    currStationIndex = Array.IndexOf(costForFindMin_3, costForFindMin_3.Min());
                    break;
                case 3:
                    currStationIndex = Array.IndexOf(costForFindMin_4, costForFindMin_4.Min());
                    break;
                case 4:
                    currStationIndex = Array.IndexOf(costForFindMin_5, costForFindMin_5.Min());
                    break;
                default:
                    currStationIndex = Array.IndexOf(costForFindMin_6, costForFindMin_6.Min());
                    break;
            }
            return currStationIndex;
        }

        public static int ReadValue_A()
        {
            WriteLine("Введите объём закупки топлива на АЗС 'А'(целое положительное число): ");
            int value;
            while (!int.TryParse(ReadLine(), out value) || value > sumMaxes)
            {
                Error.WriteLine("Неверный ввод или общий объём закупок превышает допустимое значение");
                Write("Введите объём закупки топлива на АЗС 'А': ");
            }
            return value;
        }

        public static int ReadValue_Б()
        {
            WriteLine("Введите объём закупки топлива на АЗС 'Б'(целое положительное число): ");
            int value;
            while (!int.TryParse(ReadLine(), out value) || SumValueRemainds(valueRemainds) > sumMaxes)
            {
                Error.WriteLine("Неверный ввод или общий объём закупок превышает допустимое значение");
                Write("Введите объём закупки топлива на АЗС 'Б': ");
            }
            return value;
        }

        public static int ReadValue_В()
        {
            WriteLine("Введите объём закупки топлива на АЗС 'В'(целое положительное число): ");
            int value;
            while (!int.TryParse(ReadLine(), out value) || SumValueRemainds(valueRemainds) > sumMaxes)
            {
                Error.WriteLine("Неверный ввод или общий объём закупок превышает допустимое значение");
                Write("Введите объём закупки топлива на АЗС 'В': ");
            }
            return value;
        }

        public static int ReadValue_Г()
        {
            WriteLine("Введите объём закупки топлива на АЗС 'Г'(целое положительное число): ");
            int value;
            while (!int.TryParse(ReadLine(), out value) || SumValueRemainds(valueRemainds) > sumMaxes)
            {
                Error.WriteLine("Неверный ввод или общий объём закупок превышает допустимое значение");
                Write("Введите объём закупки топлива на АЗС 'Г': ");
            }
            return value;
        }

        static int SumValueRemainds(int[] values)
        {
            int sum = 0;
            for(int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        static void PrintAnswer(int[,] AnswerValues)
        {
            decimal petrolCost = 0.0m;
            decimal providingCost = 0.0m;
            decimal sumWithProviding = 0.0m;
            WriteLine();
            WriteLine("Поставщики \t АЗС А \t АЗС Б \t АЗС В \t АЗС Г \t Стоимость закупки \t С учетом доставки");
            for (int i = 0; i < 6; i++)
            {
                petrolCost = CountStationExpenses(i);
                providingCost = CountStationExpensesProviding(i);
                sumWithProviding += providingCost + petrolCost;
                Write("{0, 10}", i + 1);
                for (int j = 0; j < 4; j++)
                {
                    Write(" \t {0, 5}", AnswerValues[j, i]);
                }
                Write("\t {0, 17:F2} \t", petrolCost);
                Write("{0, 18:F2}", petrolCost + providingCost);
                WriteLine();
            }
            WriteLine("ИТОГО: {0:# ##0.00##}", sumWithProviding);
        }

        static decimal CountStationExpenses(int indexProvider)
        {
            decimal sum = 0.0m;
            for (int i = 0; i < 4; i++)
            {
                sum += (costFor1_1[indexProvider] * costForStations[i,indexProvider]);
            }
            return sum;
        }

        static decimal CountStationExpensesProviding(int indexProvider)
        {
            decimal sumProvide = 0.0m;
            for (int i = 0; i < 4; i++)
            {
                if (costForStations[i, indexProvider] > 0)
                {
                    sumProvide += deliveryCostStations[indexProvider, i];
                }
            }
            return sumProvide;
        }

        /* static void PrintTable()
         {
             Write(' ');
             for(int i = 0; i < ; i++)
             {
                 Write('_');
             }
             WriteLine();
         }*/ // символы вида "⎤" он выводит как "?" 
    }
}
