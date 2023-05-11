using System;
using System.Windows;

namespace 名言リマインダー
{
    /// <summary>
    /// プログラムのエントリポイント
    /// </summary>
    internal class Program
    {
#pragma warning disable IDE0060 // 未使用のパラメーターを削除します
        private static void Main(string[] args)
#pragma warning restore IDE0060 // 未使用のパラメーターを削除します
        {
            Reminder reminder;

            var errMsg = string.Empty;
            var notifier = new Notifier.WinTostNotifier();
            try
            {
                errMsg = "名言リマンダーの起動に失敗しました！";
                var setting = new Settings.Repository.JsonRepository().LoadSettings();
                var repo = new 名言ズ.Repository.CsvRepository();
                reminder = new Reminder(setting, repo, notifier);

                errMsg = "名言リマンダーの処理中に例外が発生しました！";
                reminder.StartProcess();
            }
            catch (Exception e)
            {
                notifier.Notice(名言ズ.名言.Create(errMsg + "例外：" + e.Message));
            }
        }
    }
}
