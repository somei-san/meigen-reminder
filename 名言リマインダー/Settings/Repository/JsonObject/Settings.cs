using System;
using System.Collections.Generic;
using System.Text;
using 名言リマインダー.EventTimeTable;
using 名言リマインダー.UniqueException;

namespace 名言リマインダー.Settings.Repository.JsonObject
{
    /// <summary>
    /// <see cref="名言リマインダー.Settings.Settings"/>のJsonobject
    /// </summary>
    public class Settings
    {
        /// <summary>　全通知時刻の一覧　</summary>
        public List<string> 通知時刻たち { get; init; } = new ();

        /// <summary>
        /// ファクトリ
        /// </summary>
        /// <param name="source"> 元となる<see cref="名言リマインダー.Settings.Settings"/>オブジェクト </param>
        /// <returns><see cref="Settings"/>インスタンス</returns>
        internal static Settings CreateBy(名言リマインダー.Settings.Settings source)
        {
            var tims = new List<string>();
            foreach (var t in source.GetNoriceTimes())
                tims.Add(t.GetValueAsString());

            var ret = new Settings() {
                通知時刻たち = tims,
            };

            return ret;
        }

        /// <summary>
        /// <see cref="名言リマインダー.Settings.Settings"/>を返す
        /// </summary>
        /// <returns>本オブジェクトの値を反映した<see cref="名言リマインダー.Settings.Settings"/>オブジェクト</returns>
        /// <exception cref="InvalidSettingException"/>
        internal 名言リマインダー.Settings.Settings ExportDomainObject()
        {
            var tims = new List<Time>();
            try
            {
                foreach (var t in this.通知時刻たち)
                    tims.Add(Time.CreateBy(t));
                return new 名言リマインダー.Settings.Settings(tims);
            }
            catch (Exception e)
            {
                throw new InvalidSettingException(e.Message);
            }
        }
    }
}
