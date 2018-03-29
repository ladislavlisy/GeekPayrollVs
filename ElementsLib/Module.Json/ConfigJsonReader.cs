using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Json
{
    public class ConfigJsonReader
    {
        public static IList<T> ReadJsonData<T>(string configFilePath) where T : new()
        {
            string configContent = "";

            try
            {
                StreamReader readerFile = new StreamReader(configFilePath, Encoding.GetEncoding("windows-1250"));

                configContent = readerFile.ReadToEnd();

                readerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
            return JsonConvert.DeserializeObject<List<T>>(configContent);
        }
        public static void SaveJsonData<T>(string configFilePath, IList<T> configData) where T : new()
        {
            string configContent = JsonConvert.SerializeObject(configData, Formatting.Indented);

            try
            {
                StreamWriter writerFile = new StreamWriter(configFilePath, false, Encoding.GetEncoding("windows-1250"));

                writerFile.Write(configContent);

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }
    }
}
