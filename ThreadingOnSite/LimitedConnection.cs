using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class LimitedConnection {

        private Semaphore sem = new Semaphore(5, 5);
        private Random rand = new Random();

        public void DownloadFiles(IEnumerable<string> urls) {
            Thread[] tArray = new Thread[urls.Count()];
            int counter = 0;

            foreach (var url in urls) {
                Thread t = new Thread(DownloadFile);
                t.Name = "Thread " + counter;
                t.Start(url);
                tArray[counter] = t;
                counter++;
            }

            // waiting (for godot?)
            for (int i = 0; i < tArray.Length; i++) {
                tArray[i].Join();
            }

            // possible notification
        }

        private void DownloadFile(object url) {
            Console.WriteLine(Thread.CurrentThread.Name + " is waiting.");
            sem.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + " is downloading.");
            Thread.Sleep(1000 * rand.Next(5));
            Console.WriteLine(Thread.CurrentThread.Name + " finished downloading.");
            sem.Release();
        }
    }
}
