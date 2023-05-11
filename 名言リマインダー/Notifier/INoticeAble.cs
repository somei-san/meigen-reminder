using System;
using System.Collections.Generic;
using System.Text;
using 名言リマインダー.名言ズ;

namespace 名言リマインダー.Notifier
{
    /// <summary> 通知IF </summary>
    internal interface INoticeAble
    {
        /// <summary> 通知実行 </summary>
        /// <param name="meigen"> 通知したい名言 </param>
        /// <returns> 成功:true,失敗:false </returns>
        bool Notice(名言 meigen);
    }
}
