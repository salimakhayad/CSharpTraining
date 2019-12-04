using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        internal static Car ParseFromCsv(string line)
        {
            var colums = line.Split(',');
            return new Car
            {
                Year = int.Parse(colums[0]),
                Manufacturer = colums[1],
                Name = colums[2],
                Displacement = double.Parse(colums[3]),
                Cylinders = int.Parse(colums[4]),
                City = int.Parse(colums[5]),
                Highway = int.Parse(colums[6]),
                Combined = int.Parse(colums[7])
            };
        }
    }

}
