using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Encode;

namespace EncodeTest
{
    [TestClass]
    public class HuffmanTest
    {
        [TestMethod]
        public void Execute0()
        {
            #region Init

            var coefs = Huffman.GetCoefs("ABCACDGDGG", 5);
            var result = Huffman.Execute(coefs, 5);

            #endregion
            

            #region Bytes

            var bytes = result.Bytes;

            var bytes3 = bytes[3];
            StringSameBytes("0", bytes3[0]);
            StringSameBytes("1", bytes3[1]);

            var bytes2 = bytes[2];
            StringSameBytes("1", bytes2[0]);
            StringSameBytes("00", bytes2[1]);
            StringSameBytes("01", bytes2[2]);

            var bytes1 = bytes[1];
            StringSameBytes("00", bytes1[0]);
            StringSameBytes("01", bytes1[1]);
            StringSameBytes("10", bytes1[2]);
            StringSameBytes("11", bytes1[3]);

            var bytes0 = bytes[0];
            StringSameBytes("00", bytes0[0]);
            StringSameBytes("10", bytes0[1]);
            StringSameBytes("11", bytes0[2]);
            StringSameBytes("010", bytes0[3]);
            StringSameBytes("011", bytes0[4]);

            #endregion


            #region Bytes.Length

            Assert.AreEqual(4, bytes.Length);

            #endregion


            #region Bytes[i].Length

            Assert.AreEqual(2, bytes3.Length);
            Assert.AreEqual(3, bytes2.Length);
            Assert.AreEqual(4, bytes1.Length);
            Assert.AreEqual(5, bytes0.Length);

            #endregion
        }

        [TestMethod]
        public void Execute1()
        {
            var coefs = Huffman.GetCoefs("AAABBC", 5);
            var result = Huffman.Execute(coefs, 5);

            Assert.IsTrue(2 == result.Bytes.Length);

            var bytes1 = result.Bytes[1];
            StringSameBytes("0", bytes1[0]);
            StringSameBytes("1", bytes1[1]);
            Assert.IsTrue(2 == bytes1.Length);

            var bytes0 = result.Bytes[0];
            StringSameBytes("0", bytes0[0]);
            StringSameBytes("10", bytes0[1]);
            StringSameBytes("11", bytes0[2]);
            Assert.IsTrue(3 == bytes0.Length);
        }

        [TestMethod]
        public void Coef0()
        {
            var coefs = Huffman.GetCoefs("ABCACDGDGG", 5);

            Assert.AreEqual(Math.Round(2.0 / 10.0, 5), coefs['A']);
            Assert.AreEqual(Math.Round(1.0 / 10.0, 5), coefs['B']);
            Assert.AreEqual(Math.Round(2.0 / 10.0, 5), coefs['C']);
            Assert.AreEqual(Math.Round(2.0 / 10.0, 5), coefs['D']);
            Assert.AreEqual(Math.Round(3.0 / 10.0, 5), coefs['G']);
        }

        [TestMethod]
        public void Coef1()
        {
            var coefs = Huffman.GetCoefs("AAABBC", 5);

            Assert.AreEqual(Math.Round(3.0 / 6.0, 5), coefs['A']);
            Assert.AreEqual(Math.Round(2.0 / 6.0, 5), coefs['B']);
            Assert.AreEqual(Math.Round(1.0 / 6.0, 5), coefs['C']);
        }


        static void StringSameBytes(string text, byte[] bytes)
        {
            Assert.AreEqual(text, string.Join("", bytes));
        }
    }
}
