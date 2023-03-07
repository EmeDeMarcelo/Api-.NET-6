using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Seat Ibiza",
                "Seat León"
            };
            // Select * of cars
            var carList = from car in cars select car;

            foreach(var car in carList)
            {
                Console.WriteLine(car);
            }
            // select where car is Audi

            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach( var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }
        // Number Examplse
        static public void LinqqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }

        static public void SearchEamples()
        {
            List<string> textList = new List<string> {
            "a",
            "bx", 
            "c",
            "d",
            "e",
            "cj",
            "f",
            "c"
            };
            // fisrt of all elements
            var first = textList.First();

            //first element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //first element that contains "j"
            var jText = textList.First(text => text.Contains("j"));
            
            // First element that contains "z" or default(empty element)
            var firstOrDefault = textList.FirstOrDefault(text => text.Contains("z"));
            
            // First element that contains "z" or default(empty element)
            var lastOrDefault = textList.LastOrDefault(text => text.Contains("z"));
            
            //Single Values
            var uniqueText = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4,8}
            var myEvenNumbers =evenNumbers.Except(otherEvenNumbers);//{4,8}



        }
        static public void MultipleSelects()
        {
            // select many
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",

            };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 1",
                    Employees= new[]
                    {
                        new Employee()
                        {
                            Id=1,
                            Name="Martín",
                            Email="martin@imaginegroup.com",
                            Salary=3000
                        },
                        new Employee()
                        {
                            Id=2,
                            Name="Pepe",
                            Email="pepe@imaginegroup.com",
                            Salary=1000
                        },
                        new Employee()
                        {
                            Id=3,
                            Name="Juajo",
                            Email="juanjo@imaginegroup.com",
                            Salary=2000
                        }

                    }

                },
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 2",
                    Employees= new[]
                    {
                        new Employee()
                        {
                            Id=4,
                            Name="Ana",
                            Email="Ana@imaginegroup.com",
                            Salary=2500
                        },
                        new Employee()
                        {
                            Id=5,
                            Name="Maria",
                            Email="maria@imaginegroup.com",
                            Salary=1000
                        },
                        new Employee()
                        {
                            Id=6,
                            Name="Marta",
                            Email="marta@imaginegroup.com",
                            Salary=1500
                        }

                    }

                }
            };
            // Obtain All employees of all Enterprise
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // know if a list is empty
            bool hasEnterpises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());
            
            // All enterprise at least employees with more than 1000 of salary
            bool hasEmployeeWithSalaryMoreThan1000=
                enterprises.Any(enterprise => 
                enterprise.Employees.Any(employee => employee.Salary >= 1000));
             
        }
        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };
            var commonResul2 = firstList.Join(
                               secondList,
                               element => element,
                               secondElement => secondElement,
                               (element, secondElement) => new { element,secondElement}
                    );
            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };
            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s=>s== element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };
            // OUTER JOIN - RIGTH
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };
            //Union
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }
        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            var skipTwoFirstValues = myList.Skip(2);//{3,4,5,6,7,8,9,10}
            var skipLastTwoValues = myList.SkipLast(2);//{1,2,3,4,5,6,7,8}
            var skipWhileSmalleThan4 = myList.SkipWhile(num => num < 4);//{4,5,6,7,8}
        }


    }
}