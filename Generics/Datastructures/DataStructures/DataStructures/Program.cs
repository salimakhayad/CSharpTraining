using System;
using static DataStructures.BufferExenstions;

namespace DataStructures
{
    class Program
    {
        static void ConsoleWrite(double data)
        {
            Console.WriteLine(data);
        }
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<double>(capacity:3);
            buffer.ItemDiscarded += ItemDiscarded;
            ProcessInput(buffer);

            Converter<double, DateTime> converter;

            #region EveryDay Delegates

            // // delegates
            // Action<bool> print = d => Console.WriteLine(d);
            // Func<double, double> square = d => d * d;
            // // take double and return double
            // Func<double, double, double> add = (x, y) => x + y;
            // Predicate<double> isLessThanTen = d => d < 10;
            // 
            // var number = square(add(3, 5));
            // print(isLessThanTen(square(add(3, 5))));
            #endregion
            

            buffer.Dump(d=> Console.WriteLine(d));

            ProcessBuffer(buffer);
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full. Discarding {0} New Item is {1}", e.ItemDiscarded,e.NewItem);
           
        }

        private static void Buffer_ItemDiscarded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
            
        }
    }
  
}
