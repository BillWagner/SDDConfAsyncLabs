using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;

namespace AsyncPuzzles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var numericTask = Task.Run(() => FinalAnswer());
            var msgTask = DoRemoteWork("a new customer");
            if (msgTask.IsFaulted)
                Console.WriteLine("The task is already faulted");
            Console.WriteLine("Doing remote work");
            var msg = await msgTask;
            Console.WriteLine(msg);
            var n = await numericTask;
            Console.WriteLine(n);
        }

        private static async Task<string> DoRemoteWork(string customer)
        {
            if (string.IsNullOrWhiteSpace(customer))
                throw new ArgumentException(message: "Customer can't be null", paramName: nameof(customer));

            using (var service = new RemoteService())
            {
                return await service.GenerateMessageAsync(customer);
            }
        }

        private static decimal FinalAnswer()
        {
            var r = multiplyRandom();
            var x = multiplyRandom();
            var y = multiplyRandom();
            return r + x + y;
        }

        private static Task<decimal> multiplyRandomAsync()
        {
            return Task.Run(() => multiplyRandom());
        }
        private static decimal multiplyRandom()
        {
            Random r = new Random();

            decimal result = 1m;
            for(int i = 0; i < int.MaxValue; i++)
            {
                result += (decimal)r.Next();
                var next = r.Next();
                result /= (next != 0) ? (decimal)next : (decimal)1;
            }
            return result;
        }
    }
}
