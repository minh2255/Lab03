using System;
using System.Collections.Generic;
using System.Linq;

namespace NNLTCSharpBai6_2
{
    public class MonHoc
    {
        public string MaMon {get; set;} = "";
        public string TenMon {get; set;} = "";
        public string He {get; set;} = "";
        public byte SoTiet {get; set;}
    }

    public class He
    {
        public string MaHe {get; set;} = "";
        public string TenHe {get; set;} = "";
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
            var dsMon = DuLieu.DS_Mon();
            var dsHe = DuLieu.DS_He();
            //a dùng join liệt kê tên hệ, mã môn, tên môn
            var CauA = from h in dsHe 
            join m in dsMon 
            on h.MaHe equals m.He
            select new {
                h.TenHe, m.MaMon, m.TenMon
            };
            Console.WriteLine("Liet ke ten he, ma mon, ten mon: ");
            foreach (var item in CauA)
            Console.WriteLine($" - [{item.TenHe}] {item.MaMon} {item.TenMon}");
            //b liệt kê hệ chưa có môn học
            var CauB = from h in dsHe 
            join m in dsMon on h.MaHe equals m.He into g 
            from subMon in g.DefaultIfEmpty() 
            select new {
                TenHe = h.TenHe,
                MaMon = subMon != null ? subMon.MaMon : "(Trong)",
                TenMon = subMon != null ? subMon.TenMon : "(Chua co mon)"
            };
            Console.WriteLine("He chua co mon hoc: ");
            foreach (var item in CauB)
            Console.WriteLine($" - [{item.TenHe}] {item.MaMon} - {item.TenMon}");
            //c liệt hệ chưa có môn học và môn chưa khai báo hệ
            var leftJoin = from h in dsHe
            join m in dsMon on h.MaHe equals m.He into g
            from subMon in g.DefaultIfEmpty()
            select new {
                TenHe = h.TenHe, 
                MaMon = subMon?.MaMon,
                TenMon = subMon?.TenMon
            };
            var rightJoin = from m in dsMon
            where !dsHe.Any(h => h.MaHe == m.He)
            select new {
                TenHe = "Chua khai bao",
                MaMon = m.MaMon,
                TenMon = m.TenMon
            };
            var CauC = leftJoin.Concat(rightJoin);
            Console.WriteLine("He chua co mon hon: ");
            foreach (var item in CauC)
            Console.WriteLine($" [{item.TenHe}] {item.MaMon ?? "N/A"} - {item.TenMon ?? "N/A"}");
            //d hệ chưa có môn học và môn chưa khai báo hệ
            var CauD = CauC.Where(x => string.IsNullOrEmpty(x.MaMon) || x.TenHe == "(He chua khai bao)");
            Console.WriteLine("He chua co mon hoac mon chua co he: ");
            foreach (var item in CauD)
            Console.WriteLine($" [{item.TenHe}] {item.MaMon ?? "N/A"} - {item.TenMon ?? "N/A"}");
            //e lấy 5 môn đầu tiên có số tiết giảm dần
            var CauE = (from m in dsMon
            join h in dsHe on m.He equals h.MaHe into g
            from subHe in g.DefaultIfEmpty()
            orderby m.SoTiet descending
            select new {
                TenHe = subHe != null ? subHe.TenHe : "(Khac / Chua phan he)", 
                m.MaMon, 
                m.TenMon,
                m.SoTiet
            }).Take(5);
            Console.WriteLine("5 mon co so tiet giam dan: ");
            foreach (var item in CauE)
            Console.WriteLine($" [{item.TenHe}] | Ma mon: {item.MaMon} | Ten mon: {item.TenMon} | So tiet: {item.SoTiet}");
            //f tổng số môn của mỗi hệ 
            var CauF = from h in dsHe
            join m in dsMon on h.MaHe equals m.He into g
            select new { 
                h.MaHe,
                h.TenHe,
                Tong = g.Count() 
            };
            Console.WriteLine("Tong so mon cua moi he: ");
            foreach (var item in CauF)
            Console.WriteLine($" [{item.MaHe}] {item.TenHe}: {item.Tong} mon");
            // g cho biết số loại số tiết khác nhau
            Console.WriteLine($"Co {dsMon.Select(m => m.SoTiet).Distinct().Count()} loai tiet khac nhau");
            // h môn bắt đầu bằng Lập trình
            var CauH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"Mon bat dau bang Lap trinh: {CauH?.MaMon} - {CauH?.TenMon}");
            //i liệt kê môn theo hệ, đánh stt
            Console.WriteLine("Danh sach mon theo he: ");
            foreach (var g in dsMon.GroupBy(m => m.He))
            {
                string tenHe = dsHe.FirstOrDefault(h => h.MaHe == g.Key)?.TenHe ?? "Chua phan he";
                Console.WriteLine($"[{tenHe}]");
                var list = g.Select((m, index) => new { STT = index + 1, m.MaMon, m.TenMon });
                foreach (var item in list) 
                Console.WriteLine($" {item.STT}. {item.MaMon} - {item.TenMon}");
            }
        }
    }
}
