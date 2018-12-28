using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKS
{
    class Book
    {
        private string name;
        private double count;
        private string autor;
        private int year;
        public Book()
        {
            this.name = "";
            this.count = 0;
            this.autor = "";
            this.year = 0;
        }
        public Book(string name, double count, string autor, int year)
        {
            this.name = name;
            this.count = count;
            this.autor = autor;
            this.year = year;
        }
        public override string ToString()
        {
            return "name=" + name + "count=" + count + "autor=" + autor + "year=" + year;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = "inkognito";
            }
        }
        public double Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        public string Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
       
        public double Money(double p)
        {
            if (count > p)
            {
                return count * 10;
            }
            else
            {
                return 0;
            }

        }
        public void BookFromString(string s)
        {
            string[] mas = s.Split('"');
            name = mas[1];
            string[] array = mas[2].Split(' ');
            count = Convert.ToDouble(array[1]);
            autor = array[2];
            year = Convert.ToInt32(array[3]);
        }
    }
}
