using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {


            #region EF
          // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
          // InsertData();
          // QueryData();

            #endregion
            #region Democode
            //

            Func<int, int> square = x => x * x;
            Expression<Func<int, int, int>> add = (x, y) => x + y;

            Func<int, int, int> addI = add.Compile();
            // returns datastructure - body of the expression

            var result = addI(3, 5);

            Console.WriteLine(result);
            Console.WriteLine(add);

            //
            #endregion
            #region Query and Create Xml
            // CreateXml();
            // QueryXml();
            #endregion
            #region More Efficient Aggregation
            //var manufacturers = ProcessManufacturers("manufacturers.csv");
            //
            //var query =
            //    from car in records
            //    group car by car.Manufacturer into carGroup
            //    select new
            //    {
            //        Name = carGroup.Key,
            //        Max = carGroup.Max(c => c.Combined),
            //        Min = carGroup.Min(c => c.Combined),
            //        Avg = carGroup.Average(c => c.Combined)
            //    } into result /**/
            //    orderby result.Max descending
            //    select result;
            //
            //
            //var query2 =
            //    records.GroupBy(c => c.Manufacturer)
            //        .Select(g =>
            //        {
            //            var results = g.Aggregate(new CarStatistics(),
            //                               (acc, c) => acc.Accumulate(c),
            //                               acc => acc.Compute());
            //            return new
            //            {
            //                Name = g.Key,
            //                Avg = results.Average,
            //                Min = results.Min,
            //                Max = results.Max
            //            };
            //        })
            //        .OrderByDescending(r => r.Max);
            //
            //foreach (var result in query)
            //{
            //    Console.WriteLine($"{result.Name}");
            //    Console.WriteLine($"\t Max:{result.Max}");
            //    Console.WriteLine($"\t Min:{result.Min}");
            //    Console.WriteLine($"\t Avg:{result.Avg}");
            //
            //
            //}
            //
            #endregion
            #region Aggregation


            //  var query =
            //      from car in cars
            //      group car by car.Manufacturer into carGroup
            //      select new
            //      {
            //          Name = carGroup.Key,
            //          Max = carGroup.Max(c => c.Combined),
            //          Min = carGroup.Min(c => c.Combined),
            //          Avg = carGroup.Average(c => c.Combined)
            //      } into result /**/
            //      orderby result.Max descending
            //      select result;
            //  
            //
            //  // extensionmethod Syntax vs Sql Syntax
            //
            //  var query2 =
            //      manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
            //            new
            //            {
            //                Manufacturer = m,
            //                Cars = g
            //            })
            //      .GroupBy(m => m.Manufacturer.Headquarters)
            //      .Take(3);
            //
            //  foreach (var result in query)
            //  {
            //      Console.WriteLine($"{result.Name}");
            //      Console.WriteLine($"\t Max:{result.Max}");
            //      Console.WriteLine($"\t Min:{result.Min}");
            //      Console.WriteLine($"\t Avg:{result.Avg}");
            //
            //
            //  }
            //
            #endregion
            #region Top 3 efficient cars per Manufacturer
            // var query =
            //     from manufacturer in manufacturers
            //     join car in cars on manufacturer.Name equals car.Manufacturer
            //     into carGroup
            //     orderby manufacturer.Name
            //     select new
            //     {
            //         Manufacturer = manufacturer,
            //         Cars = carGroup
            //     } into result
            //     group result by result.Manufacturer.Headquarters;
            //
            //
            // // extensionmethod Syntax vs Sql Syntax
            //
            // var query2 =
            //     manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
            //           new
            //           {
            //               Manufacturer = m,
            //               Cars = g
            //           })
            //     .GroupBy(m => m.Manufacturer.Headquarters)
            //     .Take(3);
            #endregion
            #region Grouping Data Manufacturer - Country


            // 
            // var query =
            //     from manufacturer in manufacturers
            //     join car in cars on manufacturer.Name equals car.Manufacturer
            //     into carGroup
            //     select new
            //     {
            //         Manufacturer = manufacturer,
            //         Cars = carGroup
            //     };
            // 
            // 
            // 
            //         // var query =
            //         //     from car in cars
            //         //     group car by car.Manufacturer.ToUpper() into manufacturer
            //         //     orderby manufacturer.Key
            //         //     select manufacturer;
            // 
            //         // - Group Query
            //         // var v2query =
            //         //     cars.GroupBy(c => c.Manufacturer.ToUpper())
            //         //     .OrderBy(g => g.Key);
            // 
            //  foreach (var group in query)
            // {
            //     Console.WriteLine($"{group.Key}");
            //     foreach (var car in group.SelectMany(g=>g.Cars)
            //          .OrderByDescending(c => c.Combined).Take(3))
            //     {
            //         Console.WriteLine($"\t{car.Name}:{car.Combined}");
            //     }
            // }


            #endregion
            #region Grouping Data 

            //   var cars = ProcessCars("fuel.csv");
            //   var manufacturers = ProcessManufacturers("manufacturers.csv");
            // 
            //   var query =
            //       from car in cars
            //       group car by car.Manufacturer;

            // ex: Tesla has 5 cars etc
            // foreach (var result in query)
            // {
            //     Console.WriteLine($"{result.Key} has {result.Count()} cars");
            //     // Key Property represents @ what u grouped on
            // }
            #endregion - Manufacturer
            #region Anonymous Types queries
            //  var query = from car in cars
            //                  // where car.Manufacturer == "BMW" && car.Year == 2016
            //              join manufacturer in manufacturers
            //                  on new { car.Manufacturer, car.Year } 
            //                  equals 
            //                  new { Manufacturer = manufacturer.Name, manufacturer.Year }
            //              orderby car.Combined descending, car.Name ascending
            //              select new
            //              {
            //                  manufacturer.Headquarters,
            //                  car.Name,
            //                  car.Combined
            //              };
            //  
            //  var query2 = cars.Join(manufacturers,
            //      /*outer key selector -
            //       - Lambda expressions always single character*/
            //                             c => new { c.Manufacturer, c.Year },
            //                             m => new { Manufacturer = m.Name, m.Year }, 
            //                             (c, m) => new
            //                             {
            //                                 m.Headquarters,
            //                                 c.Name,
            //                                 c.Combined
            //                             })
            //                      .OrderByDescending(c => c.Combined)
            //                      .ThenBy(c => c.Name)
            //                      .Select(c => new
            //                      {
            //                          c.Headquarters,
            //                          c.Name,
            //                          c.Combined
            //                      });
            //                       //.Select(c => new
            //                       //{
            //                       //  c.Manufacturer.Headquarters,
            //                       //c.Car.Name,
            //                       //c.Car.Combined
            //                       //});
            // 
            // 
            //  var top = cars
            //                  .OrderByDescending(c => c.Combined)
            //                  .ThenBy(c => c.Name)
            //                  .Select(c => c)
            //                  .First();
            #endregion
            #region Projection Operators
            //  var result = cars.Select(c => new { c.Manufacturer, c.Name, c.Combined });
            //
            //  var InnerResult = cars.SelectMany(c => c.Name)
            //                      .OrderBy(c => c);
            //  #endregion

            // foreach (var character in result)
            // {
            //     Console.WriteLine(character);
            // }

            // Console.WriteLine(result);

            // foreach (var car in query2.Take(10))
            // {
            //     Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            // }
            #endregion

            Console.ReadLine();
        }

        private static void QueryData()
        {
            var db = new CarDb();

            db.Database.Log = Console.WriteLine;
            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;



            var query2 = db.Cars.OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Take(10)
                                .Select(c => new { Name = c.Name.ToUpper() })
                                .ToList();

            // extension method syntax

            var query3 = from car in db.Cars
                         group car by car.Manufacturer into manufacturer
                         select new
                         {
                             Name = manufacturer.Key,
                             Cars = (from car in manufacturer
                                     orderby car.Combined descending
                                     select car).Take(2)
                         };

            // query syntax

               //  db.Cars.GroupBy(c => c.Manufacturer)
               //          .Select(g => new
               //          {
               //              Name = g.Key,
               //              Cars = g.OrderByDescending(c => c.Combined).Take(2)
               //          });

            foreach (var group in query3)
            {
                Console.WriteLine($"{group.Name}");
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}:{car.Combined}");
                }
            }
            foreach (Car car in query)
            {
                Console.WriteLine($"{car.Name}:{car.Combined}");
            }

            Console.ReadLine();
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();


            if (db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static void QueryXml()
        {
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var ns = (XNamespace)"http://pluralsight.com/cars/2016";

            var document = XDocument.Load("fuel.xml");
            var query = from element in document.Element(ns + "Cars").Elements(ex + "Car")
                                                            ?? Enumerable.Empty<XElement>()
                        where element.Attribute("Manufacturer")?.Value == "BWM"  // "?" makes it nullable // "??" isNull?
                        select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var ns = (XNamespace)"http://pluralsight.com/cars/2016";

            var document = new XDocument();
            var cars = new XElement(ns + "Cars",

                from record in records
                select new XElement(ns + "Car",
                            new XAttribute("Name", record.Name),
                            new XAttribute("Combined", record.Combined),
                            new XAttribute("Manufacturer", record.Manufacturer))

                );

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
            document.Add(cars);
            document.Save("fuel.xml");
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

              File.ReadAllLines(path)
                  .Skip(1)
                  .Where(l => l.Length > 1)
                  .ToCar();

            return query.ToList();
            // maps to car


        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }
    public class CarStatistics
    {

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Math.Max(Max, car.Combined);
            Math.Min(Min, car.Combined);

            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                // projection with deferred execution
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
