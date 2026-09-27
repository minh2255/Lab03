using System;
using System.Collections.Generic;

namespace NNLTCSharpBai6_1
{
    public class He
    {
        public string MaHe {get; set;} = "";
        public string TenHe {get; set;} = "";
    }
    public class DuLieu
    {
        public static List<He> DS_He() => new List<He>
        {
            new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
            new He { MaHe = "CD", TenHe = "Chuyên đề" },
            new He { MaHe = "QT", TenHe = "Chứng chỉ quốc tế" }
        }; 
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<He> ds = DuLieu.DS_He();
            foreach (He he in ds)
            {
                Console.WriteLine($"{he.MaHe} {he.TenHe}");
            }
        }
    }
}
