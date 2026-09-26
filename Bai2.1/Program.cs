using System;
using System.Linq;

namespace NNLTCSharpBai2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mangSo = {50, 42, 16, 3, 9, 8, 12, 7, 24, 0};
            //a liệt kê chia hết 4 và 3
            var CauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
            Console.WriteLine("Cac phan tu chia het cho 4 va 3: " + string.Join(", ", CauA));
            //b liệt kê nhỏ hơn hoặc bằng 3
            var CauB = mangSo.Where(x => x <= 3);
            Console.WriteLine("Cac phan tu nho hon hoac bang 3: " + string.Join(", ", CauB));
            //c tạo dãy số chẵn chia đôi, số lẻ giữ nguyên
            var CauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
            Console.WriteLine("Day moi(chan chia doi, le giu nguyen): " + string.Join(", ", CauC));
        }
    }
}
