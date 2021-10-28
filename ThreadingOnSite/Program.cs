using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class Program {
        //static async Task Main(string[] args) {
        static void Main(string[] args) {

            RaceCondition rc = new RaceCondition();

            Thread prgmA = new Thread(new ThreadStart(rc.FirstThread));
            Thread prgmB = new Thread(new ThreadStart(rc.SecondThread));

            prgmA.Start();
            prgmB.Start();

            LimitedConnection lc = new LimitedConnection();
            IEnumerable<string> urls = new List<string>() {
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle"
            };
            lc.DownloadFiles(urls);

            RaceConditionAutoReset rca = new RaceConditionAutoReset();
            rca.Run();

            PollingExample pe = new PollingExample();
            pe.Run();

            //AsyncExample ae = new AsyncExample();
            //await ae.CallingMethod();
        }
    }
}
