using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKS
{
    class Program
    {
        static void Main(string[] args)
        {
            // masuv knug vuvestu vsi knugu yaki ix avtoru napusalu menge n kilkist rokiv
            // 2 zav dly kognoi knugu bilse za p storinok avtor otrumye bonus 10 baksiv za kogny storinky, i avtor z naibilsoy vunagorodyy
            //klas matruca nXn n- rozmirnist matruci, vnytrishniy masiv dly zberejenn9 danuh matruci(elementiv)
            Library librar = new Library();
            librar.ReadFromFile("Lib.txt");
            librar.printBooks();
            Console.WriteLine("Input year:");
            int year = Convert.ToInt32(Console.ReadLine());
            librar.PrintCheckYear(year);
            Console.WriteLine("Input count Page:");
            int page = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine( "autor with max bonus is:" +  librar.MaxBonusAutor(page));
            Console.ReadKey();
        }
    }
}
