using System;
using System.Threading.Tasks;

namespace MLS.Agent.Tools
{
    public class AsyncLazy<T>
    {
        private readonly Lazy<Task<T>> lazy;

        public AsyncLazy(Func<Task<T>> initialize)
        {
            if (initialize == null)
            {
                throw new ArgumentNullException(nameof(initialize));
            }

            lazy = new Lazy<Task<T>>(initialize);
        }

        public Task<T> ValueAsync() => lazy.Value;
    }
}