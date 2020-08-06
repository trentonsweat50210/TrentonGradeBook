using System;
using System.Collections.Generic;

namespace GradeBook 
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Trent's Grade Book");
            EnterGrades(book);

            var stats1 = book.GetStats();
            Console.WriteLine($"The result is (avg) {stats1.Average}, (lowestgrade) {stats1.Low}, (highgrade){stats1.High}");



        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;

                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);

                }
                finally
                {
                    System.Console.WriteLine("");

                }



            }
        }

    }
}
