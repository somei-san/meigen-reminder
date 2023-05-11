using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using 名言リマインダー.UniqueException;

namespace 名言リマインダー.Settings.Repository
{
    /// <summary>
    /// JSON形式版リポジトリ
    /// </summary>
    internal class JsonRepository
    {
        /// <summary> ファイル名 </summary>
        private const string FileName = "設定.json";

        /// <summary> 設定を読み込む </summary>
        /// <returns> 読み込んだ設定 </returns>
        public Settings LoadSettings()
        {
            Settings ret;

            JsonObject.Settings jsonObj;
            try
            {
                // ファイル読み込み
                var jsonString = File.ReadAllText(FileName);

                // デシリアライズ
                jsonObj = JsonSerializer.Deserialize<JsonObject.Settings>(jsonString) ?? throw new Exception("失敗");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new IOException($"設定ファイル {FileName} の読み込みに失敗しました.");
            }

            // ドメインモデル化
            try
            {
                ret = jsonObj.ExportDomainObject();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidSettingException($"設定ファイル {FileName} の値に不正なものがあります. {e.Message}");
            }

            return ret;
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        /// <param name="settings">保存したい設定</param>
        /// <returns>成功:true、失敗:false</returns>
        public bool SaveSettings(Settings settings)
        {
            try
            {
                // json化
                var jsonObj = JsonObject.Settings.CreateBy(settings);
                var options = new JsonSerializerOptions() {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true,
                };
                string jsonString = JsonSerializer.Serialize(jsonObj, options);

                // ファイル書き込み
                File.WriteAllText(FileName, jsonString);
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
