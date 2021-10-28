using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class RaceCondition {

        private int i = 0;

        public void FirstThread() {
            while(i < 50) {
                Console.WriteLine($"First thread counting from {i} to {++i}");
                Thread.Sleep(100);
            }
        }

        public void SecondThread() {
            while (i < 50) {
                Console.WriteLine($"Second thread counting from {i} to {++i}");
                Thread.Sleep(10);
            }
        }
    }
}
