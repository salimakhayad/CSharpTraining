using System;

namespace Generic.Tips
{
    public static class StringExtensions
    {
        public static TEnum ParseEnum<TEnum>(this string value)
            where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
    public enum Steps
    {
        Step1,
        Step2,
        Step3
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            var input = "Step1";
            var value = input.ParseEnum<Steps>();
            Console.WriteLine(value);
            Console.ReadLine();

                //(Steps)Enum.Parse(typeof(Steps), input);
        }
    }
}
