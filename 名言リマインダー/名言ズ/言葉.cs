using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ
{
    /// <summary> 言葉 </summary>
    public class 言葉
    {
        /// <summary> 値 </summary>
        public string Value { get; }

        /// <summary> Initializes a new instance of the <see cref="言葉"/> class.</summary>
        /// <param name="value"> 値 </param>
        /// <exception cref="ArgumentException"/>
        public 言葉(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("引数が空", nameof(value));

            this.Value = value;
        }
    }
}
