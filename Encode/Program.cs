using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ABCACDGDGG";
            var symbolsCoefs = GetCoefs(text);
            var result = Algorithm(symbolsCoefs);

            int i = 0;
            foreach (var symbolsCoef in symbolsCoefs)
            {
                Console.WriteLine("{0}({1}) = {2}", symbolsCoef.Key, symbolsCoef.Value, string.Join("", result[i]));
                ++i;
            }

            Console.ReadKey();
        }

        static Dictionary<char, double> GetCoefs(string text)
        {
            var symbols = new Dictionary<char, int>(text.Length);
            foreach (var s in text)
            {
                if (!symbols.ContainsKey(s)) symbols[s] = 0;
                symbols[s]++;
            }

            var symbolsCoefs = new Dictionary<char, double>();
            double count = text.Length;
            foreach (var item in symbols)
            {
                symbolsCoefs[item.Key] = Round(item.Value / count);
            }
            return (Dictionary<char, double>)SortDictionary(symbolsCoefs, true);
        }

        static double Round(double value) => Math.Round(value, 5);

        static List<byte>[] Algorithm(Dictionary<char,double> dictCoefs)
        {
            List<double>[] pp = new List<double>[dictCoefs.Values.Count - 1];
            pp[0] = dictCoefs.Values.ToList();
            for (int i = 1; i < pp.Length; i++)
            {
                var last = pp[i-1].ToList();
                double sum = Round(last[last.Count - 1] + last[last.Count - 2]);
                last.RemoveAt(last.Count - 1);
                last[last.Count - 1] = sum;
                last.Sort((i1, i2) => i2.CompareTo(i1));
                pp[i] = last;
            }

            List<byte>[][] gg = new List<byte>[pp.Length][];
            for (int i = 0; i < gg.Length-1; i++)
            {
                gg[i] = new List<byte>[pp.Length + 1 - i];
                for (int j = 0; j < gg[i].Length; j++)
                {
                    gg[i][j] = new List<byte>();
                }
            }
            var g = gg[gg.Length - 1] = new List<byte>[2];
            g[0] = new List<byte>(new byte[] { 0 });
            g[1] = new List<byte>(new byte[] { 1 });
            for (int i = pp.Length - 2; i >= 0; i--)
            {
                var last = pp[i+1];
                double sum = Round(pp[i][pp[i].Count - 1] + pp[i][pp[i].Count - 2]);
                int sumIndex = last.LastIndexOf(sum);
                for (int j = 0, k = 0; j < last.Count; j++)
                {
                    if (sumIndex == j)
                    {
                        var one = new List<byte>(gg[i + 1][j]);
                        one.Add(0);
                        var two = new List<byte>(gg[i + 1][j]);
                        two.Add(1);

                        gg[i][gg[i].Length - 2] = one;
                        gg[i][gg[i].Length - 1] = two;
                    }
                    else
                    {
                        gg[i][k++] = gg[i + 1][j];
                    }
                }
            }

            return gg[0];
        }

        static IDictionary<TKey, TValue> SortDictionary<TKey, TValue>(IDictionary<TKey, TValue> dict, bool desc = false) where TValue:IComparable
        {
            var list = dict.ToList();
            if (!desc)  list.Sort((i1, i2) => i1.Value.CompareTo(i2.Value));
            else        list.Sort((i1, i2) => i2.Value.CompareTo(i1.Value));

            IDictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            foreach (var item in list)
            {
                result[item.Key] = item.Value;
            }

            return result;
        }
    }
}
