using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;// For Context type.
using System.Threading; //For threading types
// SportsCar has no special contextual
// needs and will be loaded into the
// default context of the AppDomain.

namespace ObjectContextApp
{
    public class SportsCar
    {
        public SportsCar()
        {
            //Get context information and print out Context ID
            Context context = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), context.ContextID);
            foreach (IContextProperty itfCtxProp in context.ContextProperties)
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
           
        }
    }
}
