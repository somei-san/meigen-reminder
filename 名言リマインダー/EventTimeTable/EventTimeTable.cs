using System;
using System.Collections.Immutable;
using System.Linq;

namespace 名言リマインダー.EventTimeTable
{
    /// <summary> イベントのタイムテーブル </summary>
    public class EventTimeTable
    {
        /// <summary> タイムテーブル </summary>
        private readonly ImmutableList<EventTime> timeTable;

        /// <summary> 最後にタイムテーブルをリフレッシュした日時 </summary>
        private DateTime lastRefleshDt = DateTime.MinValue;

        /// <summary> Initializes a new instance of the <see cref="EventTimeTable"/> class. </summary>
        /// <param name="eventTimes">イベント時刻。</param>
        public EventTimeTable(Time[] eventTimes)
        {
            var table = ImmutableList.CreateBuilder<EventTime>();
            foreach (var t in eventTimes)
                table.Add(new EventTime(t));
            this.timeTable = table.ToImmutable();

            // 生成時に一度リフレッシュ
            this.RefleshIfNeeded();

            // 生成日時より前のイベントは実行済みとしておく
            this.RegistEvnetDone();
        }

        /// <summary> イベントを実行する時間だったらTrueを返す </summary>
        /// <returns>　イベントを実行する必要がある:true,必要ない:false </returns>
        public bool IsTimeToDo()
        {
            // リフレッシュ確認しておく
            this.RefleshIfNeeded();

            // 未実行で実行時刻が過去のイベントがあればTrue
            var now = DateTime.Now;
            var unexecuted = this.timeTable.Where(x => x.Executed == false);
            var passed = unexecuted.Any(x => x.TriggerTime.IsPassed(now));
            return passed;
        }

        /// <summary> イベントを完了したことを登録する。現時刻より前のイベントはすべて実行済みとみなす </summary>
        public void RegistEvnetDone()
        {
            var now = DateTime.Now;

            this.timeTable.Where(x => x.TriggerTime.IsPassed(now)).ToList().ForEach(x => x.Executed = true);
        }

        /// <summary> 必要ならタイムテーブルをリフレッシュする </summary>
        private void RefleshIfNeeded()
        {
            var now = DateTime.Now;

            if (now.Date > this.lastRefleshDt.Date)
            {
                this.timeTable.ForEach(x => x.Executed = false);
                this.lastRefleshDt = now;
            }
        }
    }
}
