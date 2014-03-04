using System;

namespace l4
{

class Program
{
    /**
    * This method can go wrong in a number of ways. Catch the appro-
    priate exception and instead throw a new ArgumentException with the caught
    exception as an inner exception:
    * 1) If the string is not a valid int - throw an ArgumentException.
    * 2) If the string is null - throw an ArgumentNullException.
    * 3) If the number is too big to be represented in an int -throw an ArgumentOutOfRangeException
    */
    public static int GetNumber(string s)
    {
        try {
            return checked(int.Parse(s)); //A checked context will yield an exception when an overflow occurs.
        }
        catch (FormatException ex) {
            throw new ArgumentException("tekst er ikke en valid int", ex);
        }
        catch (ArgumentNullException ex) {
            throw new ArgumentNullException("Virker ikke med null", ex);
        }
        catch (ArgumentOutOfRangeException ex) {
            throw new ArgumentOutOfRangeException("to big for int", ex);
        }
    }

    static void Main(string[] args)
    {
        while (true) {
            Console.Write("Giv mig et tal: ");
            try {
                int tal = GetNumber(Console.ReadLine());
                Console.WriteLine("Kvadratroden er {0}", Math.Sqrt(tal));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }



        /*
        try {
            int num0 = GetNumber("22");
            Console.WriteLine(num0);

            //Examples that will throw an exception:
            //int num1 = GetNumber("9999999999999999");
            //Console.WriteLine(num1);

            //int num2 = GetNumber(null);
            //Console.WriteLine(num2);

            int num3 = GetNumber("4.5");
            Console.WriteLine(num3);

        }
        catch (Exception ex) {
            Console.Write("Der er sket en fejl: ");
            Console.WriteLine(ex.Message);
            
        }*/
    }
}


}// namespace