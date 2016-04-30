using System.Collections.Generic;

namespace Encode
{
    public interface ITable
    {
        byte[][][] Bytes { get; }
        IList<double>[] Coefs { get; }
    }
}