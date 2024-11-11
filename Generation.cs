using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HillClimbAlgorithm
{
    internal class Generation
    {
        public Generation(int lower, int upper, int exponent, double precision, int number) { 
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            array = new Specimen[exponent + 1];
            array[0] = new Specimen(lower, upper, exponent, precision, rnd.NextDouble());
            bestSpecimen = array[0];
            List<double> yMaxList = new List<double>();
            yMaxList.Add(array[0].y);
            do
            {
                array[0] = bestSpecimen;
                for(int i = 1; i < exponent + 1; ++i)
                {
                    array[i] = new Specimen(array[0], i-1);
                    if (array[i].y > yMaxList[yMaxList.Count - 1])
                    {
                        yMaxList.Add(array[i].y);
                        bestSpecimen = array[i];
                    }
                }
            } while (bestSpecimen.y > array[0].y);

            yMax = yMaxList.ToArray();
            best = yMax[yMax.Length - 1];
            indeces = new double[yMax.Length];
            for (int i = 0; i < yMax.Length; ++i) indeces[i] = i;
            for (int i = 0; i < indeces.Length; ++i) indeces[i] = number + indeces[i] / (indeces.Length - 1);
        }
        public Specimen[] array;
        public double[] yMax;
        public double best;
        public Specimen bestSpecimen;
        public double[] indeces;
    }
}
