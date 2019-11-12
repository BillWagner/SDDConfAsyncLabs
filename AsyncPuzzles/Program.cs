using System;
using System.Threading.Tasks;

namespace AsyncPuzzles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var msgTask = DoRemoteWork("a new customer");
            Console.WriteLine("Doing remote work");
            var msg = await msgTask;
            Console.WriteLine(msg);

        }

        private static Task<string> DoRemoteWork(string customer)
        {
            using (var service = new RemoteService())
            {
                return service.GenerateMessageAsync(customer);
            }
        }
    }
}
