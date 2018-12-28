using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHugeProgram
{
  public  class Student
    {
        private string surname;
        private string name;
       private string group;
        private double everageMark;

        public Student(string surname = "", string name="", string group="", double everageMark=0)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.EverageMark = everageMark;
        }
        public override string ToString()
        {
            return "\"" + surname + "\";\"" + name + "\";\"" + group + "\";\"" + everageMark + "\"";
        }
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
              
                surname = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public double EverageMark
        {
            get
            {
                return everageMark; 
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("videmne zznachenn9");
                }
                else
                {
                    everageMark = value;
                }
                if(value>100)
                {
                    throw new Exception("100 бальна система числення");
                }
            }
        }
        public void Parse(string s)
        {
            string[] mas = s.Split(';');
            surname= mas[0].Substring(1, mas[0].Length - 2);
            name = mas[1].Substring(1, mas[1].Length - 2);
            group= mas[2].Substring(1, mas[2].Length - 2);
            everageMark=double.Parse( mas[3].Substring(1, mas[3].Length - 2));

        }
    }
}
