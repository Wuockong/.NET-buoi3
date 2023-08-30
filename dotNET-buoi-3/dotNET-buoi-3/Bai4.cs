using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_buoi_3
{
    class Vehicle
    {
        private string owner;
        private string type;
        private double value;
        private double engineCapacity;

        public Vehicle(string owner, string type, double value, double engineCapacity)
        {
            this.owner = owner;
            this.type = type;
            Value = value; // Using the property to ensure constraints are applied
            EngineCapacity = engineCapacity; // Using the property to ensure constraints are applied
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Value
        {
            get { return value; }
            set
            {
                if (value >= 0)
                {
                    this.value = value;
                }
                else
                {
                    Console.WriteLine("Trị giá xe không hợp lệ!");
                }
            }
        }

        public double EngineCapacity
        {
            get { return engineCapacity; }
            set
            {
                if (value >= 0)
                {
                    engineCapacity = value;
                }
                else
                {
                    Console.WriteLine("Dung tích xylanh không hợp lệ!");
                }
            }
        }

        public double CalculateTax()
        {
            if (engineCapacity < 100)
            {
                return value * 0.01;
            }
            else if (engineCapacity >= 100 && engineCapacity <= 200)
            {
                return value * 0.03;
            }
            else
            {
                return value * 0.05;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle xe1 = new Vehicle("Nguyen Van A", "Sedan", 150000, 120);
            Vehicle xe2 = new Vehicle("Tran Thi B", "SUV", 220000, 180);

            Console.WriteLine("Nhap thong tin xe 3:");
            Console.Write("Chu xe: ");
            string owner = Console.ReadLine();
            Console.Write("Loai xe: ");
            string type = Console.ReadLine();
            Console.Write("Tri gia xe: ");
            double value = double.Parse(Console.ReadLine());
            Console.Write("Dung tich xylanh: ");
            double engineCapacity = double.Parse(Console.ReadLine());

            Vehicle xe3 = new Vehicle(owner, type, value, engineCapacity);

            Console.WriteLine("Thong tin xe 1:");
            Console.WriteLine("Chu xe: {0}, Loai xe: {1}, Tri gia xe: {2}, Dung tich xylanh: {3}",
                                xe1.Owner, xe1.Type, xe1.Value, xe1.EngineCapacity);
            Console.WriteLine("Thuế trước bạ: {0}", xe1.CalculateTax());

            Console.WriteLine("Thong tin xe 2:");
            Console.WriteLine("Chu xe: {0}, Loai xe: {1}, Tri gia xe: {2}, Dung tich xylanh: {3}",
                                xe2.Owner, xe2.Type, xe2.Value, xe2.EngineCapacity);
            Console.WriteLine("Thuế trước bạ: {0}", xe2.CalculateTax());

            Console.WriteLine("Thong tin xe 3:");
            Console.WriteLine("Chu xe: {0}, Loai xe: {1}, Tri gia xe: {2}, Dung tich xylanh: {3}",
                                xe3.Owner, xe3.Type, xe3.Value, xe3.EngineCapacity);
            Console.WriteLine("Thuế trước bạ: {0}", xe3.CalculateTax());

            Console.ReadKey();
        }
    }
}
