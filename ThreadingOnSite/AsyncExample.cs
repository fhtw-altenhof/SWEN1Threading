using System;
using System.Threading.Tasks;

namespace ThreadingOnSite {
    class AsyncExample {
        public async Task CallingMethod() {
            // async task creation
            Task<object> task = DoAsync();

            Method1();

            // async task await
            object result = await task;
            Console.WriteLine(result);
        }

        private async Task<object> DoAsync() {
            Method2();
            object result = await GetAsync();
            Method3();
            return result;
        }

        private async Task<string> GetAsync() {
            return await Task.Run(() => {
                Task.Delay(5000).Wait();
                return "test object";
            });
        }

        private void Method1() {
            Console.WriteLine("Method1 called");
        }

        private void Method2() {
            Console.WriteLine("Method2 called");

        }

        private void Method3() {
            Console.WriteLine("Method3 called");
        }
    }
}
