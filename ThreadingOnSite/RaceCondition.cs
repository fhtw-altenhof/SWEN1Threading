using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class RaceCondition {

        private int i = 0;

        private Object lockObject = new Object();

        public void FirstThread() {
            while(i < 50) {
                lock(lockObject) {
                    Console.WriteLine($"First thread counting from {i} to {++i}");
                    Thread.Sleep(100);
                }
            }
        }

        public void SecondThread() {
            while (i < 50) {
                lock (lockObject) {
                    Console.WriteLine($"Second thread counting from {i} to {++i}");
                    Thread.Sleep(10);
                }
            }
        }
    }
}
