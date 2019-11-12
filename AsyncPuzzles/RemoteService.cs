using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPuzzles
{
    public class RemoteService : IDisposable
    {
        private bool disposed;

        public virtual void Dispose()
        {
            disposed = true;
        }

        public async Task<string> GenerateMessageAsync(string customer)
        {
            await Task.Yield();
            if (disposed)
            {
                throw new ObjectDisposedException("server", "The remote server has been disposed");
            }
            return $"Remote work done asynchronously for {customer}";
        }
    }
}
