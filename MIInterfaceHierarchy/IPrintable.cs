using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHierarchy
{
    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Note possible name clash here!
    }
}
