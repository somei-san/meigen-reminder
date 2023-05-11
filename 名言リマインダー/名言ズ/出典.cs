using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ
{
    /// <summary> 出典 </summary>
    public class 出典
    {
        /// <summary> 値。空文字を許容する </summary>
        public string Value { get; }

        /// <summary> Initializes a new instance of the <see cref="出典"/> class.</summary>
        /// <param name="value"> 値 </param>
        /// <exception cref="ArgumentNullException"/>
        public 出典(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 値をもっていればTrueを返す
        /// </summary>
        /// <returns>ある:true,ない：false</returns>
        internal bool HasValue()
            => this.Value != string.Empty;
    }
}
