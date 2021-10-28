using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class RaceConditionAutoReset {

        private const int ManipulationSteps = 1000;
        private const int BufferSize = 10;

        private double[] buffer;

        private AutoResetEvent signalReader;
        private AutoResetEvent signalWriter;

        public void Run() {
            buffer = new double[BufferSize];
            signalReader = new AutoResetEvent(false);
            signalWriter = new AutoResetEvent(true);

            // new threads
            Thread t1 = new Thread(Reader);
            Thread t2 = new Thread(Writer);

            // start threads
            t1.Start();
            t2.Start();

            // wait for finish
            t1.Join();
            t2.Join();
        }

        private void Reader() {
            int readerIndex = 0;
            for (int i = 0; i < ManipulationSteps; i++) {
                signalReader.WaitOne();
                Console.WriteLine($"current read index {buffer[readerIndex]}");
                readerIndex = (readerIndex + 1) % BufferSize;
                signalWriter.Set();
            }
        }

        private void Writer() {
            int writerIndex = 0;
            for (int i = 0; i < ManipulationSteps; i++) {
                signalWriter.WaitOne();
                buffer[writerIndex] = (double)i;
                Console.WriteLine($"current write index {buffer[writerIndex]}");
                writerIndex = (writerIndex + 1) % BufferSize;
                signalReader.Set();
            }
        }
    }
}
