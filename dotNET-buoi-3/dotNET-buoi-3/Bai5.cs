using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_buoi_3
{
    class HangThucPham
    {
        private string maHang;
        private string tenHang = "xxx";
        private double donGia;
        private DateTime ngaySanXuat = DateTime.Now;
        private DateTime ngayHetHan = DateTime.Now;

        public string MaHang
        {
            get { return maHang; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    maHang = value;
                }
                else
                {
                    throw new ArgumentException("Mã hàng không được để trống");
                }
            }
        }

        public string TenHang
        {
            get { return tenHang; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tenHang = value;
                }
            }
        }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (value >= 0)
                {
                    donGia = value;
                }
            }
        }

        public DateTime NgaySanXuat
        {
            get { return ngaySanXuat; }
            set
            {
                if (value <= DateTime.Now)
                {
                    ngaySanXuat = value;
                }
            }
        }

        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
            set
            {
                if (value > ngaySanXuat)
                {
                    ngayHetHan = value;
                }
            }
        }

        public HangThucPham(string maHang, string tenHang, double donGia, DateTime ngaySanXuat, DateTime ngayHetHan)
        {
            MaHang = maHang;
            TenHang = tenHang;
            DonGia = donGia;
            NgaySanXuat = ngaySanXuat;
            NgayHetHan = ngayHetHan;
        }

        public HangThucPham(string maHang)
            : this(maHang, "xxx", 0, DateTime.Now, DateTime.Now)
        {
        }

        public bool KiemTraDaHetHan()
        {
            return DateTime.Now > ngayHetHan;
        }

        public override string ToString()
        {
            return "Ma hang: " + MaHang + ", Ten hang: " + TenHang + ", Đon gia: " + DonGia.ToString("N0")
                + ", Ngay san xuat: " + NgaySanXuat.ToString("dd/MM/yyyy") + ", Ngay het han: "
                + NgayHetHan.ToString("dd/MM/yyyy") + ", Đa het han: " + KiemTraDaHetHan();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HangThucPham hang1 = new HangThucPham("MH001", "Banh quy", 15000, new DateTime(2023, 8, 1), new DateTime(2024, 8, 1));
                HangThucPham hang2 = new HangThucPham("MH002");
                HangThucPham hang3 = new HangThucPham("MH003", "Nuoc ngot", 10000, new DateTime(2023, 7, 1), new DateTime(2023, 8, 1));

                Console.WriteLine(hang1);
                Console.WriteLine(hang2);
                Console.WriteLine(hang3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
