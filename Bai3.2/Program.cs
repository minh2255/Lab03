using System;
using System.Linq;

namespace NNLTCSharpBai3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] monAn = { "Bún bò Huế", "Hủ tiếu Heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"};
            //a các phần tử ngắn nhất, dài nhất
            int MinLen = monAn.Min(s => s.Length);
            int MaxLen = monAn.Max(s => s.Length);
            Console.WriteLine("Ngan nhat: " + string.Join(", ", monAn.Where(s => s.Length == MinLen)));
            Console.WriteLine("Dai nhat: " + string.Join(", ", monAn.Where(s => s.Length == MaxLen)));
            //b phân nhóm từ đầu tiên và liệt kê các phần tử trong nhóm
            Console.WriteLine("Phan nhom tu dau tien: ");
            foreach (var g in monAn.GroupBy(s => s.Split(' ')[0]))
            {
                Console.WriteLine($" - Tu [{g.Key}]: " + string.Join(", ",g));
            }
            //c đếm phần tử có từ đầu tiên "Bánh"
            Console.WriteLine($"Cac phan tu co tu Banh dau tien: {monAn.Count(s => s.StartsWith("Bánh"))}");
        }
    }
}