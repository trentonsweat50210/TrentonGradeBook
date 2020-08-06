using System;
using System.Collections.Generic;
using GradeBook;
using System.IO;

namespace GradeBook 
{

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;

        }
    }

        public interface IBook
        {
            void AddGrade(double grade);
            Stats GetStats();
            string Name   {get;}

        }
    
        public abstract class Book : NamedObject, IBook
        {
            public Book(string name) : base(name)
            {
            }
            public abstract void AddGrade(double grade);
            public abstract Stats GetStats();

 
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
        }

        public override Stats GetStats()
        {
            throw new NotImplementedException();
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
            Name = name;
        }

          public void AddGrade(char letter)
       {
           switch(letter)
           {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                AddGrade(0);
                    break;
           }
         
       }


       public override void AddGrade(double grade)
       {
           if (grade <= 100 && grade >=0)
           {
               Grades.Add(grade);
           }
           else
           {
               throw new ArgumentException($"Invalid {nameof(grade)}");
           }
         
       }

        public override Stats GetStats()
        {
            var result = new Stats();
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in Grades)
            {
                
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                
                result.Average += grade;
            }  
            
            result.Average /= Grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                 case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                 case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                 case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                  default:
                    result.Letter = 'F';
                    break;        
            }
            
           return result;
        }


       public static List<double> Grades;

       public const string CATEGORY = "Science";
        
    }
    
}