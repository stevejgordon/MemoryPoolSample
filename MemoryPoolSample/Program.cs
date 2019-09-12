using System;
using System.Buffers;

namespace MemoryPoolSample
{
    class Program
    {
        static void Main()
        {
            var pool = MemoryPool<byte>.Shared;

            using IMemoryOwner<byte> owner = pool.Rent(minBufferSize: 1024);

            DoSomethingWithMemory(owner.Memory); // consumes memory

            // The memory is released back to the pool when the IMemoryOwner is
            // disposed after this method exits.

            var secondOwner = pool.Rent(minBufferSize: 1024);

            TakeOwnershipOfMemory(secondOwner); // transfer ownership
        }

        private static void DoSomethingWithMemory(Memory<byte> someBytes)
        {
            var aSpan = someBytes.Span;

            // do some stuff!
        }

        private static void TakeOwnershipOfMemory(IMemoryOwner<byte> owner)
        {
            DoSomethingWithMemory(owner.Memory); // consume memory

            owner.Dispose(); // release memory
        }
    }
}
