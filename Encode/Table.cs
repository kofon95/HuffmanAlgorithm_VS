using System.Collections.Generic;

namespace Encode
{
    internal class SimpleTable : ITable
    {
        public SimpleTable(IList<double>[] coefs, byte[][][] bytes)
        {
            Coefs = coefs;
            Bytes = bytes;
        }

        public IList<double>[] Coefs { get; }
        public byte[][][] Bytes { get; }
    }
}
