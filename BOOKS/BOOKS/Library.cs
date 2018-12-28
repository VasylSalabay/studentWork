using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // dly file

namespace BOOKS
{
    class Library
    {
        private Book[] lib;

   public Library(int n=3)
        {
            Book[] lib = new Book[n];
            for(int i=0;i<n;i++)
            {
                lib[i] = new Book();
            }
        }
        public void ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName); // stvorye potik
            int countBook = Convert.ToInt32(sr.ReadLine());// chutae strichky
            lib = new Book[countBook];
            for (int i = 0; i < countBook; i++)
            {
                lib[i] = new Book();
                string s = sr.ReadLine();
                lib[i].BookFromString(s);
            }
            sr.Close();

        }
        public void printBooks()
        {
            for(int i=0;i<lib.Length;i++)
            {
                Console.WriteLine(lib[i]);
            }
        }
        public void PrintCheckYear(int n)
        {
            bool isBooks = false;
            for (int i = 0; i < lib.Length; i++)
            {
                if(lib[i].Year < n)
                {
                    isBooks = true;
                    Console.WriteLine(lib[i]);
                }
                
            }
            if(!isBooks)
            {
                Console.WriteLine("Isn't Books!");
            }
        }
        public string MaxBonusAutor(int p)
        {
            
            string maxAutor = "incognito";
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            for (int i = 0; i < lib.Length; i++)
            {
                if (lib[i].Count > p)
                {
                    if (myDictionary.ContainsKey(lib[i].Autor)) // chu ye takuy klych
                    {
                        myDictionary[lib[i].Autor] += 10;
                    }
                    else
                    {
                        myDictionary.Add(lib[i].Autor, 10);
                    }
                }
            }
            int maxPrice = 0;
           
            foreach(KeyValuePair<string, int> pair in myDictionary)
            {
                if(pair.Value>maxPrice)
                {
                    maxAutor = pair.Key;
                }
            }

            //rozdryk autor sho mayt bonusy
            foreach (KeyValuePair<string, int> pair in myDictionary)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }


                return maxAutor;

        }
    }
}
