using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            // cars by most fuel efficient 
            // var query = cars.OrderByDescending(c => c.Combined)
            //     .ThenBy(c => c.Name);

            var query = from car in cars
                      orderby car.Combined ascending, car.Name ascending
                      select car;
           
                foreach (var car in query.Take(10))
                {
                    Console.WriteLine($"{car.Name} : {car.Combined}");
                }
            Console.ReadLine();
        }
        
        private static List<Car> ProcessCars(string path)
        {
            return File.ReadAllLines(path)
                    .Skip(1) // avoid headerline
                    .Where(l => l.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
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

    public static class CarExtensions
    {        
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

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
