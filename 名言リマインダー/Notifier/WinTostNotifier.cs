using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Notifications;
using 名言リマインダー.名言ズ;

namespace 名言リマインダー.Notifier
{
    /// <summary> Windows通知センターで通知する君 </summary>
    /// <inheritdoc/>
    public class WinTostNotifier : INoticeAble
    {
        /// <inheritdoc/>
        /// <remarks> 参考 https://peta.okechan.net/blog/archives/4045 </remarks>
        public bool Notice(名言 meigen)
        {
            try
            {
                var tmpl = ToastTemplateType.ToastText01;
                var xml = ToastNotificationManager.GetTemplateContent(tmpl);

                // 通知内容を設定
                var texts = xml.GetElementsByTagName("text");
                texts[0].AppendChild(xml.CreateTextNode(meigen.GetMatomeText()));

                Console.WriteLine(xml.GetXml());

                // 通知イベントを生成して発火
                var toast = new ToastNotification(xml);
                ToastNotificationManager.CreateToastNotifier("NotificationTest").Show(toast);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
