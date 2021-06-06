using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class MyResourceWrapper : IDisposable
    {
        // The object user should call this method
        // when they finish with the object.
        //when the object user calls this method, the object is still living a productive life on the managed
        //heap and has access to all other heap-allocated objects.
        public void Dispose()
        {
            // Clean up unmanaged resources...
            // Dispose other contained disposable objects...
            // Just for a test.
            Console.WriteLine("***** In Dispose! *****");
        }
    }
}
