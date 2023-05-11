using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.UniqueException
{
    /// <summary> データが空の場合にスローされる例外です </summary>
    public class DataEmptyException : Exception
    {
        /// <summary> Initializes a new instance of the <see cref="DataEmptyException"/> class. </summary>
        /// <param name="message">メッセージ</param>
        public DataEmptyException(string? message) : base(message)
        {
        }
    }
}
