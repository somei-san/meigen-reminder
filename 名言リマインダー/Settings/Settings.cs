using System;
using System.Collections.Generic;
using System.Text;
using 名言リマインダー.EventTimeTable;

namespace 名言リマインダー.Settings
{
    /// <summary> 設定 </summary>
    internal class Settings
    {
        /// <summary> 通知時間一覧 </summary>
        private readonly List<Time> norticeTimes;

        /// <summary> Initializes a new instance of the <see cref="Settings"/> class. </summary>
        /// <param name="norticeTimes"> 通知時間一覧 </param>
        public Settings(List<Time> norticeTimes)
        {
            this.norticeTimes = norticeTimes;
        }

        /// <summary> 通知時刻を取得する </summary>
        /// <returns>通知時刻たち</returns>
        public Time[] GetNoriceTimes() => this.norticeTimes.ToArray();
    }
}
