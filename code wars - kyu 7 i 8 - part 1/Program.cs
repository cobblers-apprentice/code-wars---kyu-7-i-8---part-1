using System;

namespace code_wars___kyu_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your task is to write a function maskify, which changes all but the last four characters into '#'.

            Console.WriteLine("unesi broj, text, rec ili sta god drugo hoces:");
            Console.WriteLine(Maskfy(Console.ReadLine()));
            dalje();

            //Basic regex tasks. Write a function that takes in a numeric code of any length. The function should
            //check if the code begins with 1, 2, or 3 and return true if so. Return false otherwise.

            Console.WriteLine("unesi broj");
            Console.WriteLine(ValidateCode(Console.ReadLine()));
            dalje();

            // ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
            // If the function is passed a valid PIN string, return true, else return false.

            Console.WriteLine("unesi pin");
            Console.WriteLine(ValidatePin(Console.ReadLine()));
            dalje();

            // Given a list lst and a number N, create a new list that contains each number of lst at most N times without reordering.
            // For example if N = 2, and the input is [1,2,3,1,2,1,2,3], you take [1,2,3,1,2],
            // drop the next [1,2] since this would lead to 1 and 2 being in the result 3 times, and then take 3, which leads to [1,2,3,1,2,3].

            Console.WriteLine("data je lista, unesi koliko puta brojevi mogu da se ponavljaju");
            Console.WriteLine();
            dalje();

            // Your task is to make a function that can take any non-negative integer as an argument and return it with its digits in descending order.
            // Essentially, rearrange the digits to create the highest possible number.

            Console.WriteLine("unesi pozitivan broj");
            Console.WriteLine(DescendingOrder(int.Parse(Console.ReadLine())));
            dalje();

            // Simple, given a string of words, return the length of the shortest word(s).
            // String will never be empty and you do not need to account for different data types.

            Console.WriteLine("unesi recenicu");
            Console.WriteLine(FindShort(Console.ReadLine()));
            dalje();

            //Take 2 strings s1 and s2 including only letters from ato z.
            //Return a new sorted string, the longest possible, containing distinct letters -each taken only once - coming from s1 or s2.

            Console.WriteLine("unesi dve recenice");
            Console.WriteLine(Longest(Console.ReadLine(), Console.ReadLine()));
            dalje();


        }
        static void dalje()
        {
            Console.WriteLine("dalje?");
            Console.ReadKey();
            Console.Clear();
        }

        static string Maskfy(string cc)
        {
            int a = 0;
            string kucica = "";


            foreach (char c in cc)
            {
                a++;
            }

            foreach (char c in cc)
            {
                if (a <= 4)
                    kucica += c;
                else if (a > 4)
                {
                    kucica += "#";
                    a--;
                }
            }

            return $"{kucica}";
        }

        static bool ValidateCode(string code)
        {
            int brojac = 0;
            foreach (char item in code)
            {
                brojac++;
                if (brojac == 1)
                    if (item == '1' || item == '2' || item == '3')
                        return true;
            }
            return false;
        }

        static bool ValidatePin(string pin)
        {
            // ovde ce proci samo ako string ima tacno 4 ili 6 clanova, u suprotnom ce biti false
            if (pin.Length != 4 && pin.Length != 6)
                return false;
            // ovo pokupi slucaj plusa i minusa
            int kucica;
            foreach (char item in pin)
            {
                if (item == '+' || item == '-')
                    return false;
                if (item == '\n')
                    return false;
                //if ( e.Key == Key.Ente)
            }
            // ovo pokupi slucaje da u unetom pinu ima nesto osim brojeva
            try
            {
                kucica = Int32.Parse(pin);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        //public static int[] DeleteNth(int[] arr, int x)
        //{
        //    int brojac = arr[0];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] > brojac)
        //            brojac = arr[i];
        //    }
        //    int[] proba = new int[brojac + 1];

        //    for (int i = 0; i < proba.Length; i++)
        //    {
        //        proba[arr[i]]++;
        //    }
        //    int brojacJedan = 0;

        //    for (int i = 0; i < proba.Length; i++)
        //    {
        //        if (proba[i] > x)
        //            brojacJedan++;
        //    }
        //    int[] probaJedan = new int[brojacJedan];
        //    int brojacDva = 0;

        //    for (int i = 0; i < proba.Length; i++)
        //    {
        //        while(proba[i] > x)
        //        {
        //            probaJedan[brojacDva] = 
        //        }
        //    }
        //}

        public static int DescendingOrder(int num)
        {
            string proba = $"{num}", probaJedan = "";
            char kucicaJedan;
            int brojac = 0, brojacJedan = 0;
            char[] nizProba = new char[proba.Length];

            foreach (char item in proba)
            {
                nizProba[brojac] = item;
                brojac++;
            }

            for (int i = 0; i < nizProba.Length - 1; i++)
            {
                for (int j = i + 1; j < nizProba.Length; j++)
                {
                    if (nizProba[i] < nizProba[j])
                    {
                        kucicaJedan = nizProba[i];
                        nizProba[i] = nizProba[j];
                        nizProba[j] = kucicaJedan;
                    }
                }
            }

            for (int i = 0; i < nizProba.Length; i++)
            {
                probaJedan += nizProba[i];
            }

            brojacJedan = int.Parse(probaJedan);

            return brojacJedan;

        }

        public static int FindShort(string s)
        {
            int brojac = 0, min = 0, brojacJedan = 0;
            bool proba = true;

            foreach (char item in s)
            {
                brojacJedan++;
                if (item != ' ')
                    brojac++;

                if (item == ' ' && proba)
                {
                    min = brojac;
                    // brojacJedan = min;
                    brojac = 0;
                    proba = false;
                }
                else if (item == ' ')
                {
                    if (min > brojac)
                        min = brojac;
                    brojac = 0;
                }
                if (brojacJedan == s.Length)
                    if (brojac < min)
                        min = brojac;
            }
            return min;
        }

        public static string Longest(string s1, string s2)
        {
            string kucica = s1 + s2;

            for (int i = 0; i < kucica.Length; i++)
            {
                for (int j = 0; j < kucica.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (kucica[0] == kucica[1])
                        kucica = kucica.Remove(0, 1);
                    else if (kucica[j] == kucica[i])
                    {
                        kucica = kucica.Remove(j, 1);
                        j--;
                    }
                }
            }

            char[] proba = new char[kucica.Length];
            char kucicaJedan;

            for (int i = 0; i < kucica.Length; i++)
            {
                proba[i] = kucica[i];
            }

            for (int i = 0; i < proba.Length - 1; i++)
            {
                for (int j = i + 1; j < proba.Length; j++)
                {
                    if (proba[i] > proba[j])
                    {
                        kucicaJedan = proba[i];
                        proba[i] = proba[j];
                        proba[j] = kucicaJedan;
                    }

                }
            }
            kucica = "";
            for (int i = 0; i < proba.Length; i++)
            {
                kucica += proba[i];
            }

            return kucica;
        }
    }
}