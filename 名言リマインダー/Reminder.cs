using System;
using System.Threading;
using 名言リマインダー.Notifier;
using 名言リマインダー.Settings;
using 名言リマインダー.名言ズ;
using 名言リマインダー.名言ズ.Repository;

namespace 名言リマインダー
{
    /// <summary> リマインダー </summary>
    internal class Reminder
    {
        /// <summary> 名言たち </summary>
        private readonly 名言たち meigens;

        /// <summary> <see cref="meigens"/>リポジトリ </summary>
        private readonly IRepository repository;

        /// <summary> 通知実行君 </summary>
        private readonly INoticeAble notifier;

        /// <summary> イベントタイムテーブル </summary>
        private readonly EventTimeTable.EventTimeTable eventTimeTable;

        /// <summary> Initializes a new instance of the <see cref="Reminder"/> class.</summary>
        /// <param name="settings">設定</param>
        /// <param name="repository">リポジトリ</param>
        /// <param name="notifier">通知実行君</param>
        /// <exception cref="ArgumentNullException"/>
        public Reminder(Settings.Settings settings, IRepository repository, INoticeAble notifier)
        {
            this.repository = repository;
            this.meigens = this.repository.LoadMeigens();
            this.notifier = notifier;

            this.eventTimeTable = new EventTimeTable.EventTimeTable(settings.GetNoriceTimes());
        }

        /// <summary>　処理を開始する　</summary>
        public void StartProcess()
        {
            this.notifier.Notice(名言.Create("名言リマインドを開始しました"));

            while (true)
            {
                this.リマインド名言();

                Thread.Sleep(30000);
            }
        }

        /// <summary> 名言をリマインドする </summary>
        private void リマインド名言()
        {
            if (this.eventTimeTable.IsTimeToDo())
            {
                this.notifier.Notice(this.meigens.GetMeigenByRandom());
                this.eventTimeTable.RegistEvnetDone();
            }
        }
    }
}
