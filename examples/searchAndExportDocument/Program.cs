using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace searchAndExportDocument
{
    public class Programdoc
    {
        readonly revCore.Config _rev;
        readonly MyConfig _myconfig; 

        public Programdoc()
        {
            var builder = new ConfigurationBuilder()

            .AddJsonFile("appsettings.json", true, true);

            var configuration = builder.Build();

            _rev = new revCore.Config();            
            configuration.GetSection("rev").Bind(_rev);

            _myconfig = new MyConfig();
            configuration.GetSection("myconfig").Bind(_myconfig);
        }

        static void Main(string[] args)
        {
            var rr = new Programdoc();
            try
            {             
                var doc = new ExportDoc(
                    revConfig:rr._rev,
                    myConfig: rr._myconfig
                    );
                
                 doc.ExportDocAsync().Wait();

                Console.WriteLine("Documents successfully downloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with exception :{ex}");

                Console.Error.WriteLine($"Exiting with error at {DateTime.Now.ToString("MM/dd HH:mm:ss")} Any key to exit");               
            }

            Console.ReadKey();
        }
      
    }
}
