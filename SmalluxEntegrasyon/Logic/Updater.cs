using System;
using System.IO;
using System.Web;

namespace SmalluxEntegrasyon.Logic
{
    public class Updater
    {
        private static IDisposable _handle;
        private static readonly object _lockObject = new object();

        public static void Start(int delay)
        {
            _handle = Timer.SetInterval(() => {
                GenerateOnce();
            }, delay);
        }

        public static void Stop()
        {
            _handle.Dispose();
        }

        public static void GenerateOnce()
        {
            try
            {
                lock (_lockObject)
                {
                    string settingsFile = Path.Combine(HttpRuntime.AppDomainAppPath, "suppliers.xml");
                    string xml = XmlBuilder.Build(1, settingsFile);
                    string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Services/toptanciniz/products.xml");
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    using (var sw = new StreamWriter(path))
                    {
                        sw.Write(xml);
                    }
                }
            }
            catch (Exception ex)
            {
                var i = 1;
            }
        }
    }
}
