using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HillClimbAlgorithm
{
    internal class Specimen
    {
        public Specimen(int lower, int upper, int exp, double precision, double randomDouble)
        {
            a = lower;
            b = upper;
            l = exp;
            d = precision;
            xReal1 = Newreal(a, b, d, randomDouble);
            xInt1 = Realtoint(a, b, l, xReal1);
            xBin = Inttobin(xInt1, l);
            xInt2 = Bintoint(xBin);
            xReal2 = Inttoreal(a, b, xInt2, l, d);
            y = ((xReal2 % 1) * (Math.Cos(20 * Math.PI * xReal2) - Math.Sin(xReal2)));
        }
        public Specimen(Specimen original, int i)
        {
            this.a = original.a;
            this.b = original.b;
            this.d = original.d;
            this.l = original.l;
            StringBuilder sb = new StringBuilder(original.xBin);
            if (sb[i] == '0') sb[i] = '1';
            else if (sb[i] == '1') sb[i] = '0';
            this.xBin = sb.ToString();
            this.FromBinCalcIntRealY();
        }
        public int a;
        public int b;
        public int l;
        public double d;
        public double xReal1;
        public int xInt1;
        public string xBin;
        public int xInt2;
        public double xReal2;
        public double y;

        private static double Newreal(int a, int b, double d, double rand)
        {
            return Math.Round(rand * (b - a) + a, (int)((-1) * Math.Log10(d)));
        }
        private static int Realtoint(int a, int b, int l, double xreal)
        {
            return (int)((1 / (double)(b - a)) * (xreal - a) * (Math.Pow(2, l) - 1));
        }
        private static string Inttobin(int xint, int l)
        {
            return Convert.ToString(xint, 2).PadLeft(l, '0');
        }
        private static int Bintoint(string xbin)
        {
            return Convert.ToInt32(xbin, 2);
        }
        private static double Inttoreal(int a, int b, int xint, int l, double d)
        {
            return Math.Round((xint * (b - a)) / (Math.Pow(2, l)) + a, (int)((-1) * Math.Log10(d)));
        }
        public void FromBinCalcIntRealY()
        {
            this.xInt2 = Bintoint(this.xBin);
            this.xReal2 = Inttoreal(this.a, this.b, this.xInt2, this.l, this.d);
            this.y = ((this.xReal2 % 1) * (Math.Cos(20 * Math.PI * this.xReal2) - Math.Sin(this.xReal2)));
        }
    }
}
