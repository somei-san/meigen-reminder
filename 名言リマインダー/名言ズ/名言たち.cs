using System;
using System.Collections.Generic;
using System.Linq;
using 名言リマインダー.UniqueException;

namespace 名言リマインダー.名言ズ
{
    /// <summary> 名言たち </summary>
    /// <remarks>ファーストコレクションデザインパターン</remarks>
    public class 名言たち
    {
        /// <summary> 名言リスト </summary>
        private readonly List<名言> meigens;

        /// <summary> Initializes a new instance of the <see cref="名言たち"/> class.</summary>
        /// <param name="meigens"> 名言たち </param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        private 名言たち(List<名言> meigens)
        {
            this.meigens = meigens;
        }

        /// <summary> ファクトリ </summary>
        /// <param name="meigens">名言のリスト</param>
        /// <returns><see cref="名言たち"/>のインスタンス</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public static 名言たち Create(List<名言> meigens)
            => new 名言たち(meigens);

        /// <summary> ランダムに１つ<see cref="名言"/>を返します </summary>
        /// <returns> 名言 </returns>
        /// <exception cref="DataEmptyException"> 名言が一つもない場合にスローされます </exception>
        public 名言 GetMeigenByRandom()
        {
            if (!this.meigens.Any()) throw new DataEmptyException($"{nameof(this.meigens)} is empty");

            var randamIndex = new Random().Next(this.meigens.Count);

            return this.meigens[randamIndex];
        }

        /// <summary> 名言の一覧を返します </summary>
        /// <returns>名言の一覧(ハードコピー)</returns>
        public List<名言> GetAll名言s()
        {
            var ret = new List<名言>();

            foreach (var m in this.meigens)
                ret.Add(m.GetHardCoppy());

            return ret;
        }
    }
}
