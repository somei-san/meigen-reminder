using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ.Repository
{
    /// <summary> 名言ズリポジトリ </summary>
    internal interface IRepository
    {
        /// <summary>
        /// <see cref="名言"/>をロードする
        /// </summary>
        /// <returns>　名言集　</returns>
        名言たち LoadMeigens();
    }
}
