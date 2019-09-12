using System;
using System.Buffers;

namespace MemoryPoolSample
{
    class Program
    {
        static void Main()
        {
            var pool = MemoryPool<byte>.Shared;

            using IMemoryOwner<byte> rental = pool.Rent(minBufferSize: 1024);

            DoSomethingWithMemory(rental.Memory);

            // The memory is released back to the pool when the IMemoryOwner is
            // disposed after this method exits.
        }

        private static void DoSomethingWithMemory(Memory<byte> someBytes)
        {
            // do some stuff!
        }
    }
}
