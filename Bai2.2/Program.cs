using System;
using System.Linq;

namespace NNLTCSharpBai2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân"};
            //a liệt kê có 4 ký tự và sắp xếp tăng dần theo ký tự đầu
            var CauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
            Console.WriteLine("Chuoi 4 ky tu: " + string.Join(", ", CauA));
            //b biến chữ thường thành chữ hoa
            var CauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            Console.WriteLine("Bien chu thuong thanh chu hoa: ");
            foreach (var item in CauB)
            Console.WriteLine(" " + item);
            //c liệt kê có chữ u
            var CauC = mangChuoi.Where(s => s.Contains("u"));
            Console.WriteLine("Phan tu chua u: " + string.Join(", ", CauC));
            //d liệt kê các chữ bắt đầu in hoa
            var CauD = mangChuoi.Where(s => s.Length > 0 && char.IsUpper(s[0]));
            Console.WriteLine("Tu bat dau bang viet hoa: " + string.Join(", ", CauD));
        }
    }
}