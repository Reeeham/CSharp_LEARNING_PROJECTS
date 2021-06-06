using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{

    [Synchronization]
    public class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        {
            // Get context information and print out context ID.
            Context context = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}",this.ToString(), context.ContextID);
            foreach (IContextProperty itfCtxProp in context.ContextProperties)
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
        }
    }
}
