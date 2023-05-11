using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.UniqueException
{
    /// <summary> 設定が不正な場合にスローされる例外です </summary>
    public class InvalidSettingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSettingException"/> class.
        /// </summary>
        /// <param name="massage">メッセージ</param>
        public InvalidSettingException(string? massage) : base(massage)
        {
        }
    }
}
