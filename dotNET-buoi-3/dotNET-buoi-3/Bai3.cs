using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_buoi_3
{
    class TamGiac
    {
        private double ma;
        private double mb;
        private double mc;

        public TamGiac()
        {
            ma = 0;
            mb = 0;
            mc = 0;
        }

        public TamGiac(double ma, double mb, double mc)
        {
            if (ma <= 0 || mb <= 0 || mc <= 0 || ma + mb <= mc || ma + mc <= mb || mb + mc <= ma)
            {
                this.ma = 0;
                this.mb = 0;
                this.mc = 0;
            }
            else
            {
                this.ma = ma;
                this.mb = mb;
                this.mc = mc;
            }
        }

        public double Ma
        {
            get { return ma; }
            set
            {
                if (value > 0)
                {
                    ma = value;
                }
            }
        }

        public double Mb
        {
            get { return mb; }
            set
            {
                if (value > 0)
                {
                    mb = value;
                }
            }
        }

        public double Mc
        {
            get { return mc; }
            set
            {
                if (value > 0)
                {
                    mc = value;
                }
            }
        }

        public double ChuVi()
        {
            return ma + mb + mc;
        }

        public double DienTich()
        {
            double s = ChuVi() / 2;
            return Math.Sqrt(s * (s - ma) * (s - mb) * (s - mc));
        }

        public string Type()
        {
            if (ma == mb && mb == mc)
            {
                return "Đeu";
            }
            else if (ma == mb || mb == mc || ma == mc)
            {
                return "Can";
            }
            else
            {
                return "Thuong";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TamGiac[] TamGiacs = new TamGiac[5];
            TamGiacs[0] = new TamGiac(3, 4, 10); // Không là tam giác
            TamGiacs[1] = new TamGiac(-1, 2, 3); // Không là tam giác
            TamGiacs[2] = new TamGiac(5, 5, 5); // Tam giác đều
            TamGiacs[3] = new TamGiac(5, 5, 6); // Tam giác cân
            TamGiacs[4] = new TamGiac(3, 4, 5); // Tam giác thường

            Console.WriteLine("Thông tin các hình tam giác:");
            Console.WriteLine("| STT |   Canh ma  |   Canh mb  |   Canh mc  |    Kieu    |   Chu vi    |  Dien tich  |");
            Console.WriteLine("|-----|------------|------------|------------|------------|-------------|-------------|");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("|  {0}  |    {1,-4:F2}    |    {2,-4:F2}    |    {3,-4:F2}    |  {4,-8}  |    {5,-5:F2}    |    {6,-5:F2}    |",
                    i + 1, TamGiacs[i].Ma, TamGiacs[i].Mb, TamGiacs[i].Mc, TamGiacs[i].Type(), TamGiacs[i].ChuVi(), TamGiacs[i].DienTich());
            }
            Console.ReadKey();
        }
    }
}

