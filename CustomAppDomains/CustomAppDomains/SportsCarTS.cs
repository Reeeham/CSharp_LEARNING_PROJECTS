using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
namespace CustomAppDomains
{
    // This context-bound type will only be loaded into a
    // synchronized (hence thread-safe) context.
    //To ensure the CLR does not move SportsCarTS objects outside a synchronized context
        [Synchronization]
    public class SportsCarTS : ContextBoundObject
    {

    }
}
