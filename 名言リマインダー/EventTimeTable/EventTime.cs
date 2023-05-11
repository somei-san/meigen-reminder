using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.EventTimeTable
{
    /// <summary> イベント時刻 </summary>
    public class EventTime
    {
        /// <summary> イベントを実行しないといけない時刻 </summary>
        public Time TriggerTime { get; }

        /// <summary> イベントが実行済みならTrue </summary>
        public bool Executed { get; set; }

        /// <summary> Initializes a new instance of the <see cref="EventTime"/> class.  </summary>
        /// <param name="time">イベントを実行しないといけない時刻</param>
        /// <exception cref="ArgumentNullException"></exception>>
        public EventTime(Time time)
        {
            this.TriggerTime = time;
            this.Executed = false;
        }
    }
}
