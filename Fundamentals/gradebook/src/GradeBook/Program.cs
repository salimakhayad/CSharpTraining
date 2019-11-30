using System;
using System.Collections.Generic;
using GradeBook;

namespace GradeBook {
    public class Program {

        // entrypoint app
        static void Main (string[] args) {
            // ctrl K+C/K+U comment/uncomment
            Book book = new DiskBook("");
            
            book.GradeAdded += OnGradeAdded;

            EnterGrades (book); //  ref types non nullable / ?

            var stats = book.GetStats ();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine ($"Lowest grade is {stats.Low}");
            Console.WriteLine ($"Highest grade is {stats.High}");
            Console.WriteLine ($"Average grade is {stats.Average:N1}");
            Console.WriteLine ($"The letter grade is {stats.Letter}");
        }
        private static void EnterGrades(IBook? book) 
        {
            while (true) {
                System.Console.WriteLine ("Enter a grade or 'q' to quit");
                var input = Console.ReadLine ();

                if (input == "q") {
                    break;
                }
                try {
                    var grade = double.Parse (input);
                    book.AddGrade (grade);
                } catch (ArgumentException ex) {
                    Console.WriteLine (ex.Message);
                } catch (FormatException ex) {
                    Console.WriteLine (ex.Message);
                } finally {
                    // properly clean things up when there is an exception
                    Console.WriteLine ("**");
                }

            }
        }
        static void OnGradeAdded (Object sender, EventArgs e) {
            Console.WriteLine ("A grade was added");
        }
    }
}