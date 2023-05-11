using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace 名言リマインダー.名言ズ.Repository
{
    /// <summary> JSON形式版リポジトリ </summary>
    /// <inheritdoc/>
    public class CsvRepository : IRepository
    {
        /// <summary> ファイル名 </summary>
        private const string FileName = "名言リスト.csv";

        /// <inheritdoc/>
        public 名言たち LoadMeigens()
        {
            名言たち ret;

            try
            {
                // 読み込みたいCSVファイルのパスを指定して開く
                using var sr = new StreamReader(FileName);

                var meigens = new List<名言>();

                // 先頭行は捨てる
                string first = sr.ReadLine() ?? throw new System.IO.FileLoadException("読み込み失敗");

                // 末尾まで繰り返す
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    string line = sr.ReadLine() ?? throw new System.IO.FileLoadException("読み込み失敗");
                    string[] values = line.Split(',');

                    // 空行があればSkip
                    if (string.IsNullOrWhiteSpace(values[0])) continue;

                    // コメント行ならSkip
                    if (values[0].TrimStart(' ').TrimStart('　').First() == '#') continue;

                    // キャストして追加
                    var kotoba = values[0];
                    var source = (values.Length >= 2) ? values[1] : string.Empty;
                    meigens.Add(名言.Create(kotoba, source));
                }

                ret = 名言たち.Create(meigens);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new IOException($"設定ファイル {FileName} の読み込みに失敗しました. " + e.Message);
            }

            return ret;
        }
    }
}
