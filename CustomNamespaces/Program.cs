using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
using Chapter14.My3DShapes;
// Resolve the ambiguity using a custom alias.
using The3DHexagon = Chapter14.My3DShapes.Hexagon;
//One of the longer namespaces in the base class library is System.Runtime.Serialization
using bfHome = System.Runtime.Serialization.Formatters.Binary;
namespace CustomNaMymespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is really creating a My3DShapes.Hexagon class.
            The3DHexagon h2 = new The3DHexagon();
            bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
          
        }
    }
}
