using System;
using System.Collections.Generic;
using System.Linq;

namespace NNLTCSharpBai5_2
{
    public class MonHoc
    {
        public string MaMon {get; set;} = "";
        public string TenMon {get; set;} = "";
        public string He {get; set;} = "";
        public byte SoTiet {get; set;}
    }
    public class DuLieu
    {
        public static List<MonHoc> DS_Mon() => new List<MonHoc>
        {
            new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
            new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
            new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
            new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
            new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
        };
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dsMon = DuLieu.DS_Mon();
            //a Cho biết tổng số môn
            Console.WriteLine($"Tong so mon: {dsMon.Count()}");
            //b đếm số môn bắt đầu bằng Lập trình
            Console.WriteLine($"So mon bat dau bang Lap trinh: {dsMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");
            //c Tổng số tiết thuộc hệ KTV
            Console.WriteLine($"Tong so tiet he KTV: {dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet)}");
            //d cho biết tổng số môn của mỗi hệ
            Console.WriteLine("Tong so mon cua moi he: ");
            foreach (var g in dsMon.GroupBy(m => m.He))
            Console.WriteLine($"He [{(string.IsNullOrEmpty(g.Key) ? "chua ro" : g.Key)}]: {g.Count()} mon");
            //e Nhóm theo số tiết, in số tiết và tổng số môn, sắp xếp dần theo số tiết
            Console.WriteLine("Nhom theo so tiet (giam dan): ");
            foreach (var g in dsMon.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key))
            Console.WriteLine($"{g.Key} tiet: {g.Count()} mon");
            //f cho biết môn có số tiết cao nhất
            byte maxTiet = dsMon.Max(m => m.SoTiet);
            Console.WriteLine($"Mon co so tiet cao nhat ({maxTiet} tiet)");
            foreach (var m in dsMon.Where(m => m.SoTiet == maxTiet))
            Console.WriteLine($"- {m.MaMon}: {m.TenMon}");
            //g thống kê theo Hệ
            Console.WriteLine("Thong ke theo he: ");
            foreach (var g in dsMon.GroupBy(m => m.He))
            {
                string he = string.IsNullOrEmpty(g.Key) ? "chua ro" : g.Key;
                Console.WriteLine($" he [{he}]: {g.Count()} mon, Tong tiet: {g.Sum(x => (int)x.SoTiet)} | Max: {g.Max(x => x.SoTiet)} | Min: {g.Min(x => x.SoTiet)}");
            }
            //h liệt kê môn phân nhóm theo hệ
            Console.WriteLine("Cac mon phan nhom theo he: ");
            foreach (var g in dsMon.GroupBy(m => m.He))
            {
                Console.WriteLine($" + he [{(string.IsNullOrEmpty(g.Key) ? "Khac" : g.Key)}]:");
                foreach (var m in g)
                Console.WriteLine($" - {m.MaMon}: {m.TenMon}");
            }
            //i liêt kê môn theo phân nhóm theo số tiết và tăng dần theo số tiết
            Console.WriteLine("Phan nhom theo so tiet (tang dan): ");
            foreach (var g in dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
            {
                Console.WriteLine($" + nhom {g.Key} tiet:");
                foreach (var m in g)
                Console.WriteLine($" - {m.MaMon}: {m.TenMon}");
            }
            //j hệ KTV phân nhóm theo học phần, sắp xếp theo mã môn
            Console.WriteLine("He KTV phan nhom theo hoc phan: ");
            foreach (var g in dsMon.Where(m => m.He == "KTV").GroupBy(m => m.MaMon.Split(' ')[0]).OrderBy(g => g.Key))
            {
                Console.WriteLine($" + hoc phan {g.Key}:");
                foreach (var m in g.OrderBy(x => x.MaMon))
                Console.WriteLine($" - {m.MaMon}: {m.TenMon}");
            }
            //k phân nhóm theo hệ, chỉ lấy môn có số tiết > 40, sắp xếp theo mã môn
            Console.WriteLine("Phan nhom theo he (so tiet > 40): ");
            foreach (var g in dsMon.Where(m => m.SoTiet > 40).GroupBy(m => m.He))
            {
                Console.WriteLine($" + he [{g.Key}]:");
                foreach (var m in g.OrderBy(x => x.MaMon))
                Console.WriteLine($" - {m.MaMon}: {m.TenMon} ({m.SoTiet}) tiet");
            }
        }
    }
}
