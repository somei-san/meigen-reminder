using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ
{
    /// <summary> 名言ID </summary>
    public class ID
    {
        /// <summary> 値　</summary>
        public int Value { get; }

        /// <summary> Initializes a new instance of the <see cref="ID"/> class.</summary>
        /// <param name="value">値</param>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public ID(int value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException($"{nameof(value)} is {value}");

            this.Value = value;
        }
    }
}
