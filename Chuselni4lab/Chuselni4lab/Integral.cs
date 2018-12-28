using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuselni4lab
{
   public class Integral
    {
        private double a;
        private double b;
        private double eps;
        private int n;
        private int countOfFunction;
        public double F(double x)
        {
            countOfFunction++;
            return x*x* Math.Cos(x + 1);
          //  return x * x;
            
        }

        public Integral(double a = 0, double b = 2, double eps = 0.01)
        {
            this.a = a;
            this.b = b;
            this.eps = eps;
            n = 0;
            countOfFunction = 0;

        }
        public int N
        {
            get
            {
                return n;
            }
        }
        public int CountOfFunction
        {
            get
            {
                return countOfFunction;
            }
        }

        //public double Pervisna(double x)
        //{
        //    return x * x * Math.Sin(x + 1) + 2 * x * Math.Cos(x + 1) - 2 * Math.Sin(x + 1);
        //}
        //public double IntegralFunc()
        //{
        //    return Pervisna(b) - Pervisna(a);
        //}
        public double MethodLeftRectangle()
        {
            countOfFunction = 0;
            double s1 = 0;
            n = 2;
            double s2 = 0;
            s2 = F(a) * (b - a) + F((a + b) / 2) * (a + b) / 2;
            // MessageBox.Show("s2=" + s2);
            double h = (b - a) / n;
           while (Math.Abs(s2 - s1) > eps)
           
       //  while(h*h>eps)
            {
                s1 = s2;
                n++;
                 h = (b - a) / n;
                s2 = 0;
                for (int i = 0; i < n; i++)
                {
                    s2 += F(a + i * h) * h;
                }
            }


            return s2;
        }
        public double MethodTrapeciy()
        {
            countOfFunction = 0;
            double s1 = 0;
            n = 1;
            double s2 = 0;
            s2 = (b - a) / 2 * (F(a) + F(b));
            //   MessageBox.Show("s2=" + s2);
            double h = (b - a) / n;

            while (Math.Abs(s2 - s1) > eps)
            {
                s1 = s2;
                n++;
                 h = (b - a) / n;
                s2 = h/2*(F(a)+F(b));
                for (int i = 1; i < n-1; i++)
                {
                    s2 += F(a + i * h) * h;
                }
            }


            return s2;
        }
        public double MethodParabol()
        {
            countOfFunction = 0;
            double s1 = 0;
            n = 1;
            double s2 = 0;
            s2 = (b - a) / 6 * (F(a) + F(b)+4*F((a+b)/2));
           // MessageBox.Show("s2=" + s2);
            while (Math.Abs(s2 - s1) > eps)
            {
                s1 = s2;
                n++;
                double h = (b - a) / n;
               s2 =(F(a) + F(b));
                for (int i = 1; i < n - 1; i++)
                {
                    s2 += 2 *F(a + i * h);
                }
                for (int i = 1; i < n; i++)
                {
                    s2 += 4 * F(a + i*h+h/2);
                }
                s2 *= h / 6;
            }


            return s2;
        }
        public double MethodGaus()
        {
            countOfFunction = 0;
            double s1 = 0;
            n = 1;
            double s2 = 0;
            s2 = (b - a) / 2 * (F(a) + F(b));
            //   MessageBox.Show("s2=" + s2);
            while (Math.Abs(s2 - s1) > eps)
            {
                s1 = s2;
                n++;
              switch(n)
                {
                    case 1:
                        {
                            
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = 0;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 2;
                            s2 = 0;
                            for(int i=0;i<n;i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                    case 2:
                        {
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = -0.57735;
                            xGausVuzol[1] = +0.57735;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 1;
                            cGausConstant[1] = 1;
                            s2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                    case 3:
                        {
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = -0.774597;
                            xGausVuzol[1] = 0;
                            xGausVuzol[2] = 0.774597;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 5.0/9;
                            cGausConstant[0] = 8.0/9;
                            cGausConstant[0] = 5.0/9;
                            s2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                    case 4:
                        {
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = -0.339981;
                            xGausVuzol[1] = -0.339981;
                            xGausVuzol[2] = 0.339981;
                            xGausVuzol[3] = 0.339981;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 0.347855;
                            cGausConstant[1] = 0.652145;
                            cGausConstant[2] = 0.652145;
                            cGausConstant[3] = 0.347855;
                            s2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                    case 5:
                        {
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = -0.90618;
                            xGausVuzol[1] = -0.538469;
                            xGausVuzol[2] = 0;
                            xGausVuzol[3] = 0.538469;
                            xGausVuzol[4] = 0.90618;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 0.23693;
                            cGausConstant[1] = 0.47863;
                            cGausConstant[2] = 0.56889;
                            cGausConstant[3] = 0.47863;
                            cGausConstant[4] = 0.23693;
                            s2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                    default:
                        {
                            double[] xGausVuzol = new double[n];
                            xGausVuzol[0] = -0.90618;
                            xGausVuzol[1] = -0.538469;
                            xGausVuzol[2] = 0;
                            xGausVuzol[3] = 0.538469;
                            xGausVuzol[4] = 0.90618;
                            double[] cGausConstant = new double[n];
                            cGausConstant[0] = 0.23693;
                            cGausConstant[1] = 0.47863;
                            cGausConstant[2] = 0.56889;
                            cGausConstant[3] = 0.47863;
                            cGausConstant[4] = 0.23693;
                            s2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                double x = (b + a) / 2 + (b - a) / 2 * xGausVuzol[i];
                                s2 += cGausConstant[i] * F(x);
                            }
                            s2 *= (b - a) / 2;
                        }
                        break;
                }
            }


            return s2;
        }
    }
}
