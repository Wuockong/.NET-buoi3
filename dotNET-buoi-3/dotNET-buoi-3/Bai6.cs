using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace dotNET_buoi_3
{
    class Account
    {
        private long accNum;
        private string name;
        private double balance;
        private double RATE = 0.035;

        public Account()
        {
            accNum = 999999;
            name = "chua xac đinh";
            balance = 50000;
        }

        public Account(long accNum, string name, double balance)
        {
            if (accNum > 0)
                this.accNum = accNum;
            else
                this.accNum = 999999;

            if (!string.IsNullOrWhiteSpace(name))
                this.name = name;
            else
                this.name = "chua xac đinh";

            if (balance >= 50000)
                this.balance = balance;
            else
                this.balance = 50000;
        }

        public Account(long accNum, string name)
            : this(accNum, name, 50000)
        {
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount, double fee)
        {
            if (amount > 0 && amount + fee <= balance)
            {
                balance -= (amount + fee);
                return true;
            }
            return false;
        }

        public void AddInterest()
        {
            balance += balance * RATE;
        }

        public bool Transfer(Account acc2, double amount)
        {
            if (amount > 0 && Withdraw(amount, 0))
            {
                acc2.Deposit(amount);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            CultureInfo local = new CultureInfo("vi-VN");
            NumberFormatInfo formatter = (NumberFormatInfo)local.NumberFormat.Clone();
            formatter.CurrencySymbol = "đ";

            return "So tai khoan: " + accNum + ", Ten tai khoan: " + name + ", So du: " + balance.ToString("C", formatter);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account(72354, "Ted Murphy", 102.56);
            Account acc2 = new Account(69713, "Jane Smith", 40.00);
            Account acc3 = new Account(93757, "Edward Demsey", 759.32);

            acc1.Deposit(25.85);
            acc2.Deposit(500.00);

            acc2.Withdraw(430.75, 1.50);

            acc3.AddInterest();

            Console.WriteLine("Thong tin acc1: " + acc1);
            Console.WriteLine("Thong tin acc2: " + acc2);
            Console.WriteLine("Thong tin acc3: " + acc3);

            acc2.Transfer(acc1, 100.00);

            Console.WriteLine("Thong tin acc1 sau chuyen tien: " + acc1);
            Console.WriteLine("Thong tin acc2 sau chuyen tien: " + acc2);

            Console.ReadKey();
        }
    }
}