using System;
using System.Linq;

namespace NNLTCSharpBai3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mangSo = {50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85};
            Console.WriteLine($"Tong so phan tu: {mangSo.Count()}, so chan: {mangSo.Count(x => x % 2 == 0)}, so le: {mangSo.Count(x => x % 2 != 0)}");
            Console.WriteLine($"Tong: {mangSo.Sum()}, Max: {mangSo.Max()}, Min: {mangSo.Min()}");
            Console.WriteLine($"So phan tu khac nhau: {mangSo.Distinct().Count()}");
            Console.WriteLine("Phan nhom theo so du chia cho 5: ");
            foreach (var g in mangSo.GroupBy(x => x % 5))
            {
                Console.WriteLine($" - Du {g.Key}: {string.Join(", ", g)}");
            }
        }

    }
}
