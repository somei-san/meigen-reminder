using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ.Repository
{
    /// <summary>　テスト用リポジトリ　</summary>
    /// <inheritdoc/>
    internal class TestRepo : IRepository
    {
        /// <inheritdoc/>
        public 名言たち LoadMeigens()
        {
            var meigens = new List<名言>();

            for (int i = 1; i < 10; i++)
            {
                var meigen = 名言.Create("テスト用名言" + i.ToString());
                meigens.Add(meigen);
            }

            return 名言たち.Create(meigens);
        }
    }
}
