﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class PollingExample {

        private const int MaxResult = 10;
        private volatile string[] results;
        private volatile int resultsFinished;
        private Object resultsLocker = new Object();

        public void Run() {
            results = new string[MaxResult];
            resultsFinished = 0;

            // start tasks
            for (int i = 0; i < MaxResult; i++) {
                Task t = new Task((counter) => {
                    int _i = (int)counter;
                    string _m = Magic(_i);
                    results[_i] = _m;
                    lock(resultsLocker) {
                        resultsFinished++;
                    }
                }, i);

                t.Start();
            }

            while (resultsFinished < MaxResult) {
                Thread.Sleep(50);
            }

            for (int i = 0; i < MaxResult; i++) {
                Console.WriteLine(results[i]);
            }
        }

        private string Magic(int value) {
            return $"converted to {value}";
        }
    }
}
