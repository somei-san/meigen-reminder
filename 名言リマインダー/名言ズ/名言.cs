using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.名言ズ
{
    /// <summary>
    /// 名言
    /// </summary>
    public class 名言
    {
        /// <summary> お言葉 </summary>
        public 言葉 Kotoba { get; }

        /// <summary> 出典 </summary>
        public 出典 Source { get; }

        /// <summary>　Initializes a new instance of the <see cref="名言"/> class.</summary>
        /// <param name="id">管理ID</param>
        /// <param name="kotoba">名言！</param>
        /// <exception cref="ArgumentNullException"/>
        private 名言(言葉 kotoba, 出典 source)
        {
            this.Kotoba = kotoba;
            this.Source = source;
        }

        /// <summary> ファクトリ </summary>
        /// <param name="kotoba">名言！</param>
        /// <param name="source">出典！</param>
        /// <returns><see cref="名言"/>のインスタンス</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static 名言 Create(string kotoba, string source = "")
             => new 名言(new 言葉(kotoba), new 出典(source));

        /// <summary> ハードコピーを返します </summary>
        /// <returns>ハードコピーしたインスタンス</returns>
        public 名言 GetHardCoppy()
        => new 名言(new 言葉(this.Kotoba.Value), new 出典(this.Source.Value));

        /// <summary>
        /// 統合されたテキストを返す
        /// </summary>
        /// <returns> 統合されたテキスト </returns>
        public string GetMatomeText()
        {
            var ret = this.Kotoba.Value;
            if (this.Source.HasValue()) ret = ret + "｜" + this.Source.Value;
            return ret;
        }
    }
}
