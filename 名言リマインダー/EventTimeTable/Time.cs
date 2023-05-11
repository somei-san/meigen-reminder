using System;
using System.Collections.Generic;
using System.Text;

namespace 名言リマインダー.EventTimeTable
{
    /// <summary> 時刻 </summary>
    public class Time
    {
        /// <summary> <see cref="houer"/>の上限 </summary>
        private const int HouersMax = 23;

        /// <summary> <see cref="minute"/>の上限 </summary>
        private const int MinutesMax = 59;

        /// <summary> 時 </summary>
        private readonly int houer;

        /// <summary> 分 </summary>
        private readonly int minute;

        /// <summary> Initializes a new instance of the <see cref="Time"/> class. </summary>
        /// <param name="houer"> 時 </param>
        /// <param name="minute"> 分 </param>
        /// <exception cref="ArgumentException"/>
        private Time(int houer, int minute)
        {
            if (houer < 0 || houer > HouersMax) throw new ArgumentException($"Must 0 <= {nameof(houer)} <= {HouersMax}");
            if (minute < 0 || minute > MinutesMax) throw new ArgumentException($"Must 0 <= {nameof(minute)} <= {MinutesMax}");

            this.houer = houer;
            this.minute = minute;
        }

        /// <summary> ファクトリ｜文字列 </summary>
        /// <param name="sorceText"> hh:mm 型の文字列 </param>
        /// <returns><see cref="Time"/>インスタンス</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public static Time CreateBy(string sorceText)
        {
            if (sorceText == null) throw new ArgumentNullException(nameof(sorceText));

            var splited = sorceText.Split(":");

            int hh;
            int mm;
            try
            {
                if (splited.Length != 2) throw new Exception();
                hh = int.Parse(splited[0]);
                mm = int.Parse(splited[1]);
            }
            catch
            {
                throw new ArgumentException($"{nameof(sorceText)} はhh:mmの形式でないといけません");
            }

            return new Time(hh, mm);
        }

        /// <summary> ファクトリ｜Datetime </summary>
        /// <param name="sorce"> こいつの時刻をもとにインスタンス化する </param>
        /// <returns><see cref="Time"/>インスタンス</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public static Time CrateBy(DateTime sorce)
        {
            return new Time(sorce.Hour, sorce.Minute);
        }

        /// <summary> 渡した時刻より早い時間ならTrueを返します。</summary>
        /// <param name="criteria">　基準時間　</param>
        /// <returns> 本インスタンスの時刻より渡された基準時間がお底ればTrue。同時刻でもTrueを返します。 </returns>
        public bool IsPassed(DateTime criteria)
        {
            if (this.houer < criteria.Hour)
                return true;
            if (this.houer > criteria.Hour)
                return false;

            // HHが一緒ならここまでくる
            if (this.minute <= criteria.Minute)
                return true;

            return false;
        }

        /// <summary> 今日の日時として値を取得する </summary>
        /// <returns> 日付部が今日 時刻部が本オブジェクトの値 になっている<see cref="DateTime"/>オブジェクト </returns>
        public DateTime GetValueAsTodaysDT()
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, this.houer, this.minute, 00, 00);
        }

        /// <summary> 文字列として値を取得する </summary>
        /// <returns> hh:mmの形式に整えられた値 </returns>
        public string GetValueAsString()
            => $"{this.houer:D2}:{this.minute:D2}";
    }
}
