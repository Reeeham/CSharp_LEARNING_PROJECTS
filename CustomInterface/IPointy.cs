using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // This interface defines the behavior of "having points."
    interface IPointy
    {
        // read-only property
        byte Points { get; }
        // Implicitly public and abstract.Interfaces are pure protocol and
        byte NumberOfPoints { get; }
    }
}
