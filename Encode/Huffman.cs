using System;
using System.Collections.Generic;
using System.Linq;

namespace Encode
{

    public static class Huffman
    {
        public static Dictionary<char, double> GetCoefs(string text, int round)
        {
            var symbols = new Dictionary<char, int>(text.Length);
            foreach (var s in text)
            {
                if (!symbols.ContainsKey(s))
                    symbols[s] = 1;
                else
                    symbols[s]++;
            }

            var symbolsCoefs = new Dictionary<char, double>();
            double count = text.Length;
            foreach (var item in symbols)
            {
                symbolsCoefs[item.Key] = Math.Round(item.Value / count, round);
            }
            var sorted = SortDictionary<Dictionary<char, double>, char, double>(symbolsCoefs, true);
            return sorted;
        }

        public static ITable Execute(Dictionary<char, double> dictCoefs, int round)
        {
            List<double>[] pp = new List<double>[dictCoefs.Values.Count - 1];
            pp[0] = dictCoefs.Values.ToList();
            for (int i = 1; i < pp.Length; i++)
            {
                var last = pp[i - 1].ToList();
                double sum = Math.Round(last[last.Count - 1] + last[last.Count - 2], round);
                last.RemoveAt(last.Count - 1);
                last[last.Count - 1] = sum;
                last.Sort((i1, i2) => i2.CompareTo(i1));
                pp[i] = last;
            }

            byte[][][] gg = new byte[pp.Length][][];
            for (int i = 0; i < gg.Length - 1; i++)
            {
                gg[i] = new byte[pp.Length + 1 - i][];
            }
            var g = gg[gg.Length - 1] = new byte[2][];
            g[0] = new byte[] { 0 };
            g[1] = new byte[] { 1 };
            for (int i = pp.Length - 2; i >= 0; i--)
            {
                var last = pp[i + 1];
                double sum = Math.Round(pp[i][pp[i].Count - 1] + pp[i][pp[i].Count - 2], round);
                int sumIndex = last.LastIndexOf(sum);
                for (int j = 0, k = 0; j < last.Count; j++)
                {
                    if (sumIndex == j)
                    {
                        var len = gg[i + 1][j].Length;

                        var one = new byte[len + 1];
                        Array.Copy(gg[i + 1][j], one, len);
                        one[one.Length - 1] = 0;

                        var two = new byte[len + 1];
                        Array.Copy(gg[i + 1][j], two, len);
                        two[two.Length - 1] = 1;


                        gg[i][gg[i].Length - 2] = CopyBytes(one);
                        gg[i][gg[i].Length - 1] = CopyBytes(two);
                    }
                    else
                    {
                        gg[i][k++] = CopyBytes(gg[i + 1][j]);
                    }
                }
            }

            return new SimpleTable(pp, gg);
        }

        private static TResult SortDictionary<TResult, TKey, TValue>(TResult dict, bool desc = false)
                    where TValue : IComparable
                    where TResult : ICollection<KeyValuePair<TKey, TValue>>
        {
            var list = dict.ToList();
            if (!desc)
                list.Sort((i1, i2) => i1.Value.CompareTo(i2.Value));
            else
                list.Sort((i1, i2) => i2.Value.CompareTo(i1.Value));

            return
                (TResult)
                (ICollection<KeyValuePair<TKey, TValue>>)
                list.ToDictionary(it => it.Key, it => it.Value);
        }

        private static byte[] CopyBytes(byte[] bytes) => (byte[])bytes.Clone();
    }
}
